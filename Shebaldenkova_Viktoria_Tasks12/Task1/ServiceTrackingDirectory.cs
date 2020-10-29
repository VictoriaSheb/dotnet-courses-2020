using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace Task1
{
    class ServiceTrackingDirectory
    {
        string PathMainCatalog { get; }

        public ServiceTrackingDirectory(string path) 
        {
            PathMainCatalog = path;
        }

        public void AllChangesView(object pathObj) 
        {
            //просмотр в папке изменений(Changes)
            string path = pathObj as string;
            string pathChanges = path + @"\Changes";

            //вывод всех изменений
            DirectoryInfo directoriesForFiles = new DirectoryInfo(pathChanges);
            foreach (var file in directoriesForFiles.GetFiles()) 
            {
                string infoFileName = GetInfoFileName(file);
                string fileName = GetFileName(file);
                Console.Write(@"{0,23}   {1,7}:    ",(path.Replace(Path.GetDirectoryName(PathMainCatalog),"")),infoFileName);
                if (infoFileName.Contains("Renamed"))
                {
                    Console.Write(File.ReadAllLines(file.FullName).Last() + " to ");
                }
                Console.Write(fileName);
                while (Console.CursorLeft != 100) 
                {
                    Console.Write("_");
                }
                Console.WriteLine(file.CreationTime);
            }
            
            //реализация для подпапок
            DirectoryInfo directoriesForDirectories = new DirectoryInfo(path);
            foreach (var directory in directoriesForDirectories.GetDirectories())
            {
                if (Directory.Exists(directory.FullName + @"\Changes"))
                    AllChangesView(directory.FullName);
            }
        }





        public void RollingBackChanges(DateTime dateTime, string path)
        {
            //просмотр в папке изменений(Changes)
            string pathChanges = path + @"\Changes";
            DirectoryInfo directoriesForFiles = new DirectoryInfo(pathChanges);

            //лист из состояний файлов для отката
            List<FileInfo> rollbackFiles = new List<FileInfo>();
            List<string> filesWithOldNames = new List<string>();
            //поиск файлов отката
            foreach (var file in directoriesForFiles.GetFiles())
            {
                if ((file.CreationTime < dateTime)||((file.CreationTime.ToString().Equals(dateTime.ToString())))) 
                {
                    if (GetInfoFileName(file).Contains("Renamed"))
                        filesWithOldNames.Add(LookOldNameForRenamed(file));
                    int indexExist = CheckChangeRecord(rollbackFiles, file);
                    if (indexExist == -1)
                        rollbackFiles.Add(file);
                    else 
                    {
                        if (file.CreationTime > rollbackFiles[indexExist].CreationTime)
                            rollbackFiles[indexExist] = file;
                    }
                }
            }

            //удаление среди файлов отката старых переименованных
            for (int i = 0; i < rollbackFiles.Count; i++)
                for (int j = 0; j < filesWithOldNames.Count; j++)
                    if (GetFileName(rollbackFiles[i]) == filesWithOldNames[j]) 
                    {
                        rollbackFiles.RemoveAt(i);
                        i--;
                        break;
                    }
                        

            //удаление существующих файлов
            DirectoryInfo filesLast = new DirectoryInfo(path);
            foreach (var file in filesLast.GetFiles()) 
            {
                file.Delete();
            }

            //откат
            string pathFile;
            foreach (var file in rollbackFiles) 
            {
                if (!GetInfoFileName(file).Contains("Deleted"))
                {
                    pathFile = path + @"\" + GetFileName(file);
                    File.Copy(file.FullName, pathFile);
                    if (GetInfoFileName(file).Contains("Renamed"))
                    {
                        string[] list = new string[File.ReadAllLines(pathFile).Length];
                        File.ReadAllLines(pathFile).CopyTo(list, 0);
                        Array.Clear(list, list.Length-1,1);
                        File.WriteAllLines(pathFile, list);
                    }
                }
                    
            }

            DirectoryInfo directoriesForDirectories = new DirectoryInfo(path);
            foreach (var directory in directoriesForDirectories.GetDirectories())
            {
                if (Directory.Exists(directory.FullName + @"\Changes"))
                    RollingBackChanges(dateTime, directory.FullName);
            }

        }

        //вывод операции, произведенной с файлом
        private string GetInfoFileName(FileInfo file) 
        {
            Regex regex = new Regex(@"(Created|Changed|Deleted|Renamed)");
            Match match = regex.Match(file.Name);
            return match.Value;
        }

        //вывод настоящего имени файла
        private string GetFileName(FileInfo file)
        {
            Regex regex = new Regex(@"\d+.\d+.\d+_\d+.\d+.\d+_(Created|Changed|Deleted|Renamed)_");
            Match match = regex.Match(file.Name);
            return file.Name.Substring(match.Value.Length);
        }

        //проверка фиксации этого изменения в массиве
        private int CheckChangeRecord(List<FileInfo> filesList, FileInfo thisFile) 
        {
            string thisFileName = LookOldNameForRenamed(thisFile);
            int index = -1;
            for (int i=0;i<filesList.Count;i++)  
            {
                if (GetInfoFileName(thisFile).Contains("Renamed") && (GetFileName(filesList[i]) == thisFile.Name)) 
                {
                    return i;
                }
                if ((GetFileName(filesList[i]) == thisFileName)&&(thisFile.Name != filesList[i].Name)) 
                {
                    index = i;
                }    
            }
            return index;
        }

        //посмотреть старое имя до переименования
        private string LookOldNameForRenamed(FileInfo file) 
        {
            string oldname = GetInfoFileName(file).Contains("Renamed") ? File.ReadAllLines(file.FullName).Last() : GetFileName(file);
            return oldname;
        }

        public void ObservationService(object pathObj) 
        {
            Console.Write("Press <Enter> to exit... ");
            Observation(pathObj);
        }


        private void Observation(object pathObj)
        {
            string path = pathObj as string;
            using (FileSystemWatcher watcher = new FileSystemWatcher(path, "*.txt*"))
            {
                DirectoryInfo directories = new DirectoryInfo(path);
                List<Thread> thisThreads = new List<Thread>();
                foreach (var directory in directories.GetDirectories())
                {
                    if (directory.Name != "Changes")
                    {
                        AddDirectorySecurity(directory.FullName, WindowsIdentity.GetCurrent().Name, 
                                                    FileSystemRights.DeleteSubdirectoriesAndFiles, AccessControlType.Deny);
                        Thread thread = new Thread(Observation);
                        thisThreads.Add(thread);
                        thread.Start(directory.FullName);
                    }
                }

                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName;

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnChanged;

                watcher.EnableRaisingEvents = true;

                while (Console.ReadKey().Key != ConsoleKey.Enter) 
                { 
                    foreach (var thread in thisThreads) 
                    {
                        thread.Abort();
                    }
                    RemovalRestrictionsCatalogs(directories);
                    watcher.Dispose();
                }
            }
        }


        private void RemovalRestrictionsCatalogs(DirectoryInfo directories) 
        {
            foreach (var directory in directories.GetDirectories())
            {
                if (directory.Name == "Changes")
                {
                    RemoveDirectorySecurity(directory.FullName, WindowsIdentity.GetCurrent().Name, FileSystemRights.Modify, AccessControlType.Deny);
                }
                else
                {
                    RemoveDirectorySecurity(directory.FullName, WindowsIdentity.GetCurrent().Name, FileSystemRights.DeleteSubdirectoriesAndFiles, AccessControlType.Deny);
                    RemovalRestrictionsCatalogs(directory);
                }
            }
        }




        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            FileSystemWatcher watcher = source as FileSystemWatcher;
            try
            {
                watcher.EnableRaisingEvents = false;
                string path = FixInControlDirectory(watcher);
                string pathFile = path;
                DateTime dateTime = DateTime.Now;

                pathFile += @"\" + dateTime.ToShortDateString() + "_" + dateTime.ToShortTimeString().Replace(":", ".") +
                "." + dateTime.Second + "_" + e.ChangeType + "_" + e.Name;
                
                if (File.Exists(e.FullPath))
                    File.Copy(e.FullPath, pathFile);
                else
                    File.Create(pathFile);

                CheckingForRename(e, pathFile);


                AddDirectorySecurity(path, WindowsIdentity.GetCurrent().Name, FileSystemRights.Modify, AccessControlType.Deny);
            }
            finally
            {
                watcher.EnableRaisingEvents = true;
            }
        }


        private static void CheckingForRename(FileSystemEventArgs e, string pathFile) 
        {
            if (e.ChangeType.ToString() == "Renamed")
            {
                using (StreamWriter sw = File.AppendText(pathFile)) 
                {
                    sw.WriteLine();
                    sw.Write((e as RenamedEventArgs).OldName);
                }
            }
        }


        private static string FixInControlDirectory(FileSystemWatcher watcher)
        {

            string path = watcher.Path + @"\Changes";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            RemoveDirectorySecurity(path, WindowsIdentity.GetCurrent().Name, FileSystemRights.Modify, AccessControlType.Deny);
            return path;
        }


        private static void AddDirectorySecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            DirectoryInfo dInfo = new DirectoryInfo(FileName);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(Account, Rights, ControlType));
            dInfo.SetAccessControl(dSecurity);
        }

        private static void RemoveDirectorySecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            DirectoryInfo dInfo = new DirectoryInfo(FileName);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.RemoveAccessRule(new FileSystemAccessRule(Account, Rights, ControlType));
            dInfo.SetAccessControl(dSecurity);
        }










































































    }
}

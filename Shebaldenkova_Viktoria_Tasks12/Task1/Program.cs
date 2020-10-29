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


namespace Task1
{
    class Program
    {
        static void Main(string []args)
        {
            //Squared();

            string path = @"C:\Users\79156\Desktop\univer\Courses_Epam\dotnet-курсы-2020\dotnet-курсы-2020\filesForTask12";
            ServiceTrackingDirectory service = new ServiceTrackingDirectory(path);


            Console.WriteLine("Выберете номер операции:");
            Console.WriteLine("1)Наблюдение           2)Откат");

            int operation;
            if (int.TryParse(Console.ReadLine(), out operation))
            {
                switch (operation)
                {
                    case 1:
                        service.ObservationService(path);
                        break;
                    case 2:
                        service.AllChangesView(path);
                        Console.WriteLine("Введите время для отката изменений:");
                        DateTime dateTime;
                        if (DateTime.TryParse(Console.ReadLine(), out dateTime))
                        {
                            service.RollingBackChanges(dateTime, path as string);
                        }
                        else
                            throw new Exception("Введенное значение не дата");
                        break;
                    default:
                        throw new Exception("Не верный номер операции");
                }
            }
            else
                throw new Exception("Введенное значение не число");

            Console.ReadLine();

        }



       

        void Squared()
        {
            string path = @"C:\Users\79156\Desktop\univer\Courses_Epam\dotnet-курсы-2020\dotnet-курсы-2020\disposable_task_file.txt";

            List<string> array = new List<string>();

            int a;
            using (StreamReader sr = new StreamReader(path))
            {

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    a = Convert.ToInt32(line);
                    a = a * a;
                    array.Add(Convert.ToString(a));
                }
                sr.Close();
            }


            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var element in array)
                {
                    sw.WriteLine(element);
                }
            }

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                { Console.WriteLine(line); }
                sr.Close();
            }

            Console.ReadLine();
        }













    }
}

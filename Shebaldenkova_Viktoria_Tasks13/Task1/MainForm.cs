using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class MainForm : Form
    {
        private enum SortMode { Asceding, Desceding };
        string userSortColumn;
        string rewardSortColumn;
        private SortMode sortModeUser = SortMode.Desceding;
        private SortMode sortModeReward = SortMode.Desceding;
        int idRowForComboBox;


        public MainForm()
        {
            InitializeComponent();
            dgvUser.DataSource = DataList.users;
            dgvReward.DataSource = DataList.rewards;
            dgvUser.DataError += new DataGridViewDataErrorEventHandler(dgvUser_DataError);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idRowForComboBox = e.RowIndex;

        }

        
        private void ctAdd_Click(object sender, EventArgs e)
        {
            if (tbControl.SelectedTab.Name == "tbUsers")
                AddUser();
            else
                AddReward();

        }

        private void ctEdit_Click(object sender, EventArgs e)
        {
            if (tbControl.SelectedTab.Name == "tbUsers")
            {
                if (!(СheckEdit(dgvUser) is null))
                {
                    EditUser((int)СheckEdit(dgvUser));
                }
            }
            else
            {
                if (!(СheckEdit(dgvReward) is null))
                {
                    EditReward((int)СheckEdit(dgvReward));
                }
            }
        }


        private int? СheckEdit(DataGridView dataGrid)
        {
            if (dataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выделите строку!");
                return null;
            }
            else
            {
                int index = dataGrid.SelectedRows[0].Cells[1].RowIndex;
                return index;
            }
        }

        private void EditUser(int index) 
        {
            UserForm userForm= new UserForm(index);
            if (userForm.ShowDialog() == DialogResult.OK)
            {
                DataList.users[index].FirstName = userForm.FirstName;
                DataList.users[index].LastName = userForm.LastName;
                DataList.users[index].birthdate = userForm.Bithdate;
                DataList.users[index].RewardsUser = userForm.RewardsUser;
                userForm.Close();
            }
        }

        private void EditReward(int index)
        {
            RewardForm rewardForm = new RewardForm(index);
            if (rewardForm.ShowDialog() == DialogResult.OK)
            {
                DataList.rewards[index].Title = rewardForm.Title;
                DataList.rewards[index].Description = rewardForm.Descriptoin;
                rewardForm.Close();
            }
        }



        private void ctRemove_Click(object sender, EventArgs e)
        {
            if (tbControl.SelectedTab.Name == "tbUsers")
                Remove(dgvUser, DataList.users);
            else
            {
                Remove(dgvReward, DataList.rewards);
            }

        }

        private void Remove<T>(DataGridView view, BindingList<T> list)
        {
            if (view.SelectedRows.Count == 0)
                MessageBox.Show("Строка не выделена.");
            else
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить эти записи?", "Уведомление", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    foreach (DataGridViewRow line in view.SelectedRows)
                    {
                        if (typeof(T).Name == "Reward") 
                        {
                            RemoveRewardsFromUsers<Reward> (view, line.Index, DataList.rewards);
                        }

                        list.RemoveAt(line.Index);
                        if (typeof(T).ToString() == "Reward")
                        {
                           
                        }
                    }
                }
            }
        }


        private void RemoveRewardsFromUsers<T>(DataGridView view, int index, BindingList<T> list) 
            where T: Reward
        {
            for (int i = 0; i < DataList.users.Count; i++)
            {
                if (!(DataList.users[i].RewardsUser is null))
                    for (int j = 0; j < DataList.users[i].RewardsUser.Count; j++)
                    {
                        if (DataList.users[i].RewardsUser[j].Id == list[index].Id) 
                        {
                            DataList.users[i].RewardsUser.RemoveAt(j);
                            break;
                        }
                    }
            }
        }


        private void ctExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void AddUser() 
        {
            UserForm userForm = new UserForm();
            if (userForm.ShowDialog() == DialogResult.OK) 
            {
                DataList.users.Add(new User(((DataList.users.Count - 1 < 0) ? 0 : DataList.users[DataList.users.Count - 1].Id + 1),
                    userForm.FirstName,
                    userForm.LastName,
                    userForm.Bithdate,
                    userForm.RewardsUser));
                userForm.Close();
            }
        }


        private void AddReward() 
        {
            RewardForm rewardForm = new RewardForm();
            if (rewardForm.ShowDialog() == DialogResult.OK) 
            {
                DataList.rewards.Add(new Reward(((DataList.rewards.Count - 1 < 0) ? 0 : DataList.rewards[DataList.rewards.Count - 1].Id + 1),
                rewardForm.Title, 
                rewardForm.Descriptoin));
                rewardForm.Close();
            }
                

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgvUser_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (userSortColumn is null) 
            {
                userSortColumn = dgvUser.Columns[e.ColumnIndex].DataPropertyName;
                sortModeUser = SortMode.Desceding;
            }
            SortByColumn(e.ColumnIndex,  dgvUser, ref sortModeUser, ref userSortColumn);
            switch (dgvUser.Columns[e.ColumnIndex].DataPropertyName) 
            {
                case "FirstName":
                    if (sortModeUser == SortMode.Asceding)
                     {
                        SortFirstNameAsc();
                     }
                    else 
                     {
                        SortFirstNameDesc();
                    }
                    break;
                case "LastName":
                    if (sortModeUser == SortMode.Asceding)
                    {
                        SortLastNameAsc();
                    }
                    else
                    {
                        SortLastNameDesc();
                    }
                    break;
                case "BirthdateShort":
                    if (sortModeUser == SortMode.Asceding)
                    {
                        SortBirthdateAsc();
                    }
                    else
                    {
                        SortBirthdateDesc();
                    }
                    break;
                case "Age":
                    if (sortModeUser == SortMode.Asceding)
                    {
                        SortAgeAsc();
                    }
                    else
                    {
                        SortAgeDesc();
                    }
                    break;

                }
        }


        private void SortFirstNameAsc()
        {
            DataList.users = new BindingList<User>(DataList.users.OrderBy(s => s.FirstName).ToList());
            dgvUser.DataSource = DataList.users;
        }

        private void SortFirstNameDesc()
        {
            DataList.users = new BindingList<User>(DataList.users.OrderByDescending(s => s.FirstName).ToList());
            dgvUser.DataSource = DataList.users;
        }
        private void SortLastNameAsc()
        {
            DataList.users = new BindingList<User>(DataList.users.OrderBy(s => s.LastName).ToList());
            dgvUser.DataSource = DataList.users;
        }

        private void SortLastNameDesc()
        {
            DataList.users = new BindingList<User>(DataList.users.OrderByDescending(s => s.LastName).ToList());
            dgvUser.DataSource = DataList.users;
        }
        private void SortBirthdateAsc()
        {
            DataList.users = new BindingList<User>(DataList.users.OrderBy(s => s.birthdate).ToList());
            dgvUser.DataSource = DataList.users;
        }

        private void SortBirthdateDesc()
        {
            DataList.users = new BindingList<User>(DataList.users.OrderByDescending(s => s.birthdate).ToList());
            dgvUser.DataSource = DataList.users;
        }

        private void SortAgeAsc()
        {
            DataList.users = new BindingList<User>(DataList.users.OrderBy(s => s.Age).ToList());
            dgvUser.DataSource = DataList.users;
        }

        private void SortAgeDesc()
        {
            DataList.users = new BindingList<User>(DataList.users.OrderByDescending(s => s.Age).ToList());
            dgvUser.DataSource = DataList.users;
        }

        private void dgvReward_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (rewardSortColumn is null)
            {
                rewardSortColumn = dgvReward.Columns[e.ColumnIndex].DataPropertyName;
                sortModeReward = SortMode.Desceding;
            }
            SortByColumn(e.ColumnIndex, dgvReward, ref sortModeReward, ref rewardSortColumn);
            switch (dgvReward.Columns[e.ColumnIndex].DataPropertyName)
            {
                case "Title":
                    if (sortModeReward == SortMode.Asceding)
                    {
                        SortTitleAsc();
                    }
                    else
                    {
                        SortTitleDesc();
                    }
                    break;
                case "Description":
                    if (sortModeReward == SortMode.Asceding)
                    {
                        SortDescriptionAsc();
                    }
                    else
                    {
                        SortDescriptionDesc();
                    }
                    break;

            }
        }


        private void SortTitleAsc()
        {
            DataList.rewards = new BindingList<Reward>(DataList.rewards.OrderBy(s => s.Title).ToList());
            dgvReward.DataSource = DataList.rewards;
        }

        private void SortTitleDesc()
        {
            DataList.rewards = new BindingList<Reward>(DataList.rewards.OrderByDescending(s => s.Title).ToList());
            dgvReward.DataSource = DataList.rewards;
        }

        private void SortDescriptionAsc()
        {
            DataList.rewards = new BindingList<Reward>(DataList.rewards.OrderBy(s => s.Description.Length).ToList());
            dgvReward.DataSource = DataList.rewards;
        }

        private void SortDescriptionDesc()
        {
            DataList.rewards = new BindingList<Reward>(DataList.rewards.OrderByDescending(s => s.Description.Length).ToList());
            dgvReward.DataSource = DataList.rewards;
        }



        private void SortByColumn(int index, DataGridView view, ref SortMode  sortMode, ref string sortColumn)
        {
            if ((sortMode == SortMode.Asceding) && (sortColumn == view.Columns[index].DataPropertyName))
            {
                sortMode = SortMode.Desceding;
            }
            else
            {
                sortColumn = view.Columns[index].DataPropertyName;
                sortMode = SortMode.Asceding;
            }
        }

        private void dgvUser_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            dgvUser.Rows[idRowForComboBox].Cells["rewards"].Value = 1;
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                combo.DataSource = DataList.users[idRowForComboBox].RewardsUser;
                combo.DisplayMember = "Title";
            }
        }

        private void dgvUser_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            object value = dgvUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (!((DataGridViewComboBoxColumn)dgvUser.Columns[e.ColumnIndex]).Items.Contains(value))
            {
                //((DataGridViewComboBoxColumn)dgvUser.Columns[e.ColumnIndex]).Items.Add(value);
                e.ThrowException = false;
            }
        }




    }
}

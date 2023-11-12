using Department.BLL;
using Entities;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Task1
{
    public partial class MainForm : Form
    {
        private enum SortMode { Asceding, Desceding };
        string userSortColumnNow;
        string rewardSortColumnNow;
        private SortMode sortModeUser = SortMode.Desceding;
        private SortMode sortModeReward = SortMode.Desceding;
        int idRowForComboBox;

        private UserBLL usersBLL;
        private RewardBLL rewardsBLL;

        public MainForm()
        {
            InitializeComponent();
            usersBLL = new UserBLL();
            dgvUser.DataSource = usersBLL.InitList();
            rewardsBLL = new RewardBLL();
            dgvReward.DataSource = rewardsBLL.InitList();
            dgvUser.DataError += new DataGridViewDataErrorEventHandler(dgvUser_DataError);

        }

        private void UpdateTable() 
        {
            if (tbControl.SelectedTab.Name == "tbUsers")
                dgvUser.DataSource = usersBLL.GetList();
            else
                dgvReward.DataSource = rewardsBLL.GetList();
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
            UpdateTable();
        }

        private void ctEdit_Click(object sender, EventArgs e)
        {
            if (tbControl.SelectedTab.Name == "tbUsers")
            {
                if (!(GetIndexFirstSelectRow(dgvUser) is null))
                {
                    EditUser((int)GetIndexFirstSelectRow(dgvUser));
                }
            }
            else
            {
                if (!(GetIndexFirstSelectRow(dgvReward) is null))
                {
                    EditReward((int)GetIndexFirstSelectRow(dgvReward));
                }
            }
            UpdateTable();
        }

        private void ctRemove_Click(object sender, EventArgs e)
        {
            if (tbControl.SelectedTab.Name == "tbUsers")
                Remove(dgvUser, RemoveUser);
            else 
            {
                Remove(dgvReward, RemoveReward);
            }
                
            UpdateTable();
        }

        private int? GetIndexFirstSelectRow(DataGridView dataGrid)
        {
            if (dataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выделите строку!");
                return null;
            }
            else
            {
                int index = (int)(dataGrid.SelectedRows[0].Cells[dataGrid.Equals(dgvUser)?"IdUser":"IdReward"].Value);
                return index;
            }
        }



        private void EditUser(int index) 
        {
            User user = (User)dgvUser.SelectedCells[0].OwningRow.DataBoundItem;
            UserForm userForm= new UserForm(user, rewardsBLL);
            if (userForm.ShowDialog() == DialogResult.OK)
            {
                usersBLL.Edit(new User(index, userForm.FirstName, userForm.LastName, userForm.Bithdate, userForm.RewardsUser));
                userForm.Close();
            }
            UpdateTable();
        }

        private void EditReward(int index)
        {
            Reward reward = (Reward)dgvReward.SelectedCells[0].OwningRow.DataBoundItem;
            RewardForm rewardForm = new RewardForm(reward);
            if (rewardForm.ShowDialog() == DialogResult.OK)
            {
                rewardsBLL.Edit(new Reward(index, rewardForm.Title, rewardForm.Descriptoin));
                rewardForm.Close();
            }
        }




        private void Remove(DataGridView view, Action<DataGridView> remove)
        {
            if (view.SelectedRows.Count == 0)
                MessageBox.Show("Строка не выделена.");
            else
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить эти записи?", "Уведомление", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    int countSelectedItems = view.SelectedRows.Count;
                    for (int i = 0; i < countSelectedItems; i++) 
                    {
                        remove(view);
                    }
                }
            }
        }
        private void RemoveUser(DataGridView view)
        {
            usersBLL.Remove((User)view.SelectedRows[0].Cells[0].OwningRow.DataBoundItem);
        }
        private void RemoveReward(DataGridView view)
        {
            usersBLL.RemoveReward((Reward)view.SelectedRows[0].Cells[0].OwningRow.DataBoundItem);
            rewardsBLL.Remove((Reward)view.SelectedRows[0].Cells[0].OwningRow.DataBoundItem);
        }



            private void AddUser() 
        {
            UserForm userForm = new UserForm(rewardsBLL);
            if (userForm.ShowDialog() == DialogResult.OK) 
            {
                usersBLL.Add(new UserShort(
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
                rewardsBLL.Add(new RewardShort(rewardForm.Title, rewardForm.Descriptoin));
                rewardForm.Close();
            }
        }

        #region sort
        private void dgvUser_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        { 
            SetSortModeForThisColumn(e.ColumnIndex,  dgvUser, ref sortModeUser, ref userSortColumnNow);
            string propertyName = dgvUser.Columns[e.ColumnIndex].DataPropertyName;
            if (propertyName!="")
                Sort(typeof(User).GetProperty(propertyName), sortModeUser, (BindingList<User>)usersBLL.GetList(), dgvUser);
        }

        private void dgvReward_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetSortModeForThisColumn(e.ColumnIndex, dgvReward, ref sortModeReward, ref rewardSortColumnNow);
            string propertyName = dgvReward.Columns[e.ColumnIndex].DataPropertyName;
            Sort(typeof(Reward).GetProperty(propertyName), sortModeReward, (BindingList<Reward>)rewardsBLL.GetList(), dgvReward);
        }

        private void Sort<T>(PropertyInfo property, SortMode sortMode, BindingList<T> entity, DataGridView gridView)
        {
            entity = (sortMode == SortMode.Asceding) 
                ? new BindingList<T>(entity.OrderBy(ent => property.GetValue(ent)).ToList())
                : new BindingList<T>(entity.OrderByDescending(ent => property.GetValue(ent)).ToList());
            gridView.DataSource = entity;
        }

        private void SetSortModeForThisColumn(int index, DataGridView view, ref SortMode  sortMode, ref string sortColumn)
        {
            sortMode = ((sortMode == SortMode.Asceding) && (sortColumn == view.Columns[index].DataPropertyName)) ?
                SortMode.Desceding
                : SortMode.Asceding;
            sortColumn = view.Columns[index].DataPropertyName;
        }

        #endregion

        private void dgvUser_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                combo.DataSource = usersBLL.GetList().ToList()[idRowForComboBox].RewardsUser;
                combo.DisplayMember = "Title";
            }
            UpdateTable();
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

        private void ctExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

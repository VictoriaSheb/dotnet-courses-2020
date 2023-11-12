using Entities;
using Department.BLL;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Task1
{
    public partial class UserForm : Form
    {
        public string FirstName;
        public string LastName;
        public DateTime Bithdate;
        public BindingList<Reward> RewardsUser;
        public BindingList<Reward> AllRewardsBLL;
        private void LoadForm(RewardBLL rewardsBLL) 
        {
            InitializeComponent();
            AllRewardsBLL = (BindingList<Reward>)rewardsBLL.GetList();
            chbRewards.DataSource = (BindingList<Reward>)rewardsBLL.GetList();
            chbRewards.DisplayMember = "Title";
            chbRewards.ValueMember = "Id";
        }

        public UserForm(RewardBLL rewardsBLL)
        {
            LoadForm(rewardsBLL);
            this.Text = "Добавление нового пользователя";
        }

        public UserForm(User user, RewardBLL rewardsBLL)
        {
            LoadForm(rewardsBLL);
            this.Text = "Изменение пользователя";
            FillingForm(user);
        }


        private void FillingForm(User user)
        {
            tbFirstName.Text = user.FirstName;
            tbLastName.Text = user.LastName;
            dtBith.Value = user.Birthdate;

            if (!(user.RewardsUser is null))
                foreach (var rewrdUser in user.RewardsUser)
                {
                    for (int i = 0; i < chbRewards.Items.Count; i++)
                    {
                        if (((Reward)chbRewards.Items[i]).Id == rewrdUser.Id)
                        {
                            chbRewards.SetItemChecked(i, true);
                        }
                    }
                }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
        }

        #region Validate


        private void FirstName_Validated(object sender, EventArgs e)
        {
            FirstName = tbFirstName.Text.Trim();
        }

        private void FirstName_Validating(object sender, CancelEventArgs e)
        {
            string input = tbFirstName.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(tbFirstName, "Некорректное значение!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbFirstName, String.Empty);
                e.Cancel = false;
            }
        }

        private void LastName_Validated(object sender, EventArgs e)
        {
            LastName = tbLastName.Text.Trim();
        }

        private void LastName_Validating(object sender, CancelEventArgs e)
        {
            string input = tbLastName.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(tbLastName, "Некорректное значение!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbLastName, String.Empty);
                e.Cancel = false;
            }

        }

        private void Bith_Validated(object sender, EventArgs e)
        {
            Bithdate = dtBith.Value;
        }

        private void Bith_Validating(object sender, CancelEventArgs e)
        {
            DateTime input = dtBith.Value;
            if ((DateTime.Now.Year-input.Year)<=10 || (DateTime.Now.Year - input.Year) > 150)
            {
                errorProvider1.SetError(dtBith, "Некорректное значение!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(dtBith, String.Empty);
                e.Cancel = false;
            }
        }

        private void Rewards_Validated(object sender, EventArgs e)
        {
            RewardsUser = new BindingList<Reward>(((chbRewards.CheckedIndices).Cast<int>()).ToList().Select(i => AllRewardsBLL[i]).ToList());
        }

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

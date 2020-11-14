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
    public partial class UserForm : Form
    {
        public int? index;
        public string FirstName;
        public string LastName;
        public DateTime Bithdate;
        public List<Reward> RewardsUser = new List<Reward>();

        private void LoadForm() 
        {
            InitializeComponent();
            chbRewards.DataSource = DataList.rewards;
            chbRewards.DisplayMember = "Title";
            chbRewards.ValueMember = "Id";
        }

        public UserForm()
        {
            this.index = null;
            LoadForm();
            this.Text = "Добавление нового пользователя";
        }

        public UserForm(int index)
        {
            if (index >= 0)
                this.index = index;
            else
                index = 0;
            LoadForm();
            this.Text = "Изменение пользователя";
            FillingList();
        }


        private void FillingList()
        {
            tbFirstName.Text = DataList.users[(int)index].FirstName;
            tbLastName.Text = DataList.users[(int)index].LastName;
            dtBith.Value = DataList.users[(int)index].birthdate;

            if (!(DataList.users[(int)index].RewardsUser is null))
                foreach (var rewrdUser in DataList.users[(int)index].RewardsUser)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
        }

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
            RewardsUser = ((chbRewards.CheckedIndices).Cast<int>()).ToList().Select(i => DataList.rewards[i]).ToList();
        }
    }
}

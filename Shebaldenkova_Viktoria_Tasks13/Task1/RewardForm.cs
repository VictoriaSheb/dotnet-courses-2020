﻿using System;
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
    public partial class RewardForm : Form
    {
        public int? index;
        public string Title;
        public string Descriptoin; 


        public RewardForm()
        {
            InitializeComponent();
            this.index = null;
            this.Text = "Добавление новой награды";
        }

        public RewardForm(int index)
        {
            InitializeComponent();
            this.index = index;
            this.Text = "Изменение награды";
            FillingList();
        }

        private void FillingList()
        {
            tbTitle.Text = DataList.rewards[(int)index].Title;
            rtbDescription.Text = DataList.rewards[(int)index].Description;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;

        }

        private void Title_Validated(object sender, EventArgs e)
        {
            Title = tbTitle.Text.Trim();
        }

        private void Title_Validating(object sender, CancelEventArgs e)
        {
            string input = tbTitle.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(tbTitle, "Некорректное значение!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbTitle, String.Empty);
                e.Cancel = false;
            }
        }

        private void Descriptoin_Validated(object sender, EventArgs e)
        {
            Descriptoin = rtbDescription.Text.Trim();
        }

        private void Descriptoin_Validating(object sender, CancelEventArgs e)
        {
            string input = rtbDescription.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(rtbDescription, "Некорректное значение!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(rtbDescription, String.Empty);
                e.Cancel = false;
            }
        }
    }
}

namespace Task1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbControl = new System.Windows.Forms.TabControl();
            this.tbUsers = new System.Windows.Forms.TabPage();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.tbRewards = new System.Windows.Forms.TabPage();
            this.dgvReward = new System.Windows.Forms.DataGridView();
            this.rewardsUserBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ctEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctExit = new System.Windows.Forms.ToolStripMenuItem();
            this.rewardsUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rewardsUserBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.rewardsUserBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.rewardsUserBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.IdUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bith = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rewards = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbControl.SuspendLayout();
            this.tbUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.tbRewards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardsUserBindingSource4)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rewardsUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardsUserBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardsUserBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardsUserBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbControl
            // 
            this.tbControl.Controls.Add(this.tbUsers);
            this.tbControl.Controls.Add(this.tbRewards);
            this.tbControl.Location = new System.Drawing.Point(0, 54);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(871, 448);
            this.tbControl.TabIndex = 0;
            // 
            // tbUsers
            // 
            this.tbUsers.Controls.Add(this.dgvUser);
            this.tbUsers.Location = new System.Drawing.Point(4, 25);
            this.tbUsers.Name = "tbUsers";
            this.tbUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tbUsers.Size = new System.Drawing.Size(863, 419);
            this.tbUsers.TabIndex = 0;
            this.tbUsers.Text = "Пользователи";
            this.tbUsers.UseVisualStyleBackColor = true;
            // 
            // dgvUser
            // 
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdUser,
            this.name1,
            this.name2,
            this.bith,
            this.age,
            this.rewards});
            this.dgvUser.Location = new System.Drawing.Point(0, 25);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersWidth = 51;
            this.dgvUser.RowTemplate.Height = 24;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(863, 366);
            this.dgvUser.TabIndex = 4;
            this.dgvUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dgvUser.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUser_ColumnHeaderMouseClick);
            this.dgvUser.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvUser_DataError);
            this.dgvUser.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvUser_EditingControlShowing);
            // 
            // tbRewards
            // 
            this.tbRewards.Controls.Add(this.dgvReward);
            this.tbRewards.Location = new System.Drawing.Point(4, 25);
            this.tbRewards.Name = "tbRewards";
            this.tbRewards.Padding = new System.Windows.Forms.Padding(3);
            this.tbRewards.Size = new System.Drawing.Size(863, 419);
            this.tbRewards.TabIndex = 1;
            this.tbRewards.Text = "Награды";
            this.tbRewards.UseVisualStyleBackColor = true;
            // 
            // dgvReward
            // 
            this.dgvReward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReward.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvReward.Location = new System.Drawing.Point(1, 26);
            this.dgvReward.Name = "dgvReward";
            this.dgvReward.RowHeadersWidth = 51;
            this.dgvReward.RowTemplate.Height = 24;
            this.dgvReward.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReward.Size = new System.Drawing.Size(860, 366);
            this.dgvReward.TabIndex = 5;
            this.dgvReward.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReward_ColumnHeaderMouseClick);
            // 
            // rewardsUserBindingSource4
            // 
            this.rewardsUserBindingSource4.DataMember = "RewardsUser";
            this.rewardsUserBindingSource4.DataSource = this.userBindingSource;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(868, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctAdd,
            this.ctEdit,
            this.ctRemove,
            this.toolStripSeparator1,
            this.ctExit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // ctAdd
            // 
            this.ctAdd.Name = "ctAdd";
            this.ctAdd.Size = new System.Drawing.Size(224, 26);
            this.ctAdd.Text = "Зарегистрировать";
            this.ctAdd.Click += new System.EventHandler(this.ctAdd_Click);
            // 
            // ctEdit
            // 
            this.ctEdit.Name = "ctEdit";
            this.ctEdit.Size = new System.Drawing.Size(224, 26);
            this.ctEdit.Text = "Редактировать";
            this.ctEdit.Click += new System.EventHandler(this.ctEdit_Click);
            // 
            // ctRemove
            // 
            this.ctRemove.Name = "ctRemove";
            this.ctRemove.Size = new System.Drawing.Size(224, 26);
            this.ctRemove.Text = "Удалить";
            this.ctRemove.Click += new System.EventHandler(this.ctRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // ctExit
            // 
            this.ctExit.Name = "ctExit";
            this.ctExit.Size = new System.Drawing.Size(224, 26);
            this.ctExit.Text = "Выход";
            this.ctExit.Click += new System.EventHandler(this.ctExit_Click);
            // 
            // rewardsUserBindingSource
            // 
            this.rewardsUserBindingSource.DataMember = "RewardsUser";
            this.rewardsUserBindingSource.DataSource = this.userBindingSource;
            // 
            // rewardsUserBindingSource1
            // 
            this.rewardsUserBindingSource1.DataMember = "RewardsUser";
            this.rewardsUserBindingSource1.DataSource = this.userBindingSource;
            // 
            // rewardsUserBindingSource2
            // 
            this.rewardsUserBindingSource2.DataMember = "RewardsUser";
            this.rewardsUserBindingSource2.DataSource = this.userBindingSource;
            // 
            // rewardsUserBindingSource3
            // 
            this.rewardsUserBindingSource3.DataMember = "RewardsUser";
            this.rewardsUserBindingSource3.DataSource = this.userBindingSource;
            // 
            // IdUser
            // 
            this.IdUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdUser.DataPropertyName = "Id";
            this.IdUser.HeaderText = "Id";
            this.IdUser.MinimumWidth = 6;
            this.IdUser.Name = "IdUser";
            this.IdUser.ReadOnly = true;
            this.IdUser.Visible = false;
            // 
            // name1
            // 
            this.name1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name1.DataPropertyName = "FirstName";
            this.name1.HeaderText = "Имя";
            this.name1.MinimumWidth = 6;
            this.name1.Name = "name1";
            this.name1.ReadOnly = true;
            // 
            // name2
            // 
            this.name2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name2.DataPropertyName = "LastName";
            this.name2.HeaderText = "Фамилия";
            this.name2.MinimumWidth = 6;
            this.name2.Name = "name2";
            this.name2.ReadOnly = true;
            // 
            // bith
            // 
            this.bith.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bith.DataPropertyName = "BirthdateShort";
            this.bith.HeaderText = "Дата рождения";
            this.bith.MinimumWidth = 6;
            this.bith.Name = "bith";
            this.bith.ReadOnly = true;
            // 
            // age
            // 
            this.age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.age.DataPropertyName = "Age";
            this.age.HeaderText = "Возраст";
            this.age.MinimumWidth = 6;
            this.age.Name = "age";
            this.age.ReadOnly = true;
            // 
            // rewards
            // 
            this.rewards.AutoComplete = false;
            this.rewards.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rewards.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.rewards.HeaderText = "Награды";
            this.rewards.MinimumWidth = 6;
            this.rewards.Name = "rewards";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Title";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(Task1.User);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 500);
            this.Controls.Add(this.tbControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи&Награды";
            this.tbControl.ResumeLayout(false);
            this.tbUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.tbRewards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardsUserBindingSource4)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rewardsUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardsUserBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardsUserBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardsUserBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbControl;
        private System.Windows.Forms.TabPage tbUsers;
        private System.Windows.Forms.TabPage tbRewards;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctAdd;
        private System.Windows.Forms.ToolStripMenuItem ctEdit;
        private System.Windows.Forms.ToolStripMenuItem ctRemove;
        private System.Windows.Forms.ToolStripMenuItem ctExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource rewardsUserBindingSource1;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource rewardsUserBindingSource;
        private System.Windows.Forms.BindingSource rewardsUserBindingSource4;
        private System.Windows.Forms.BindingSource rewardsUserBindingSource2;
        private System.Windows.Forms.BindingSource rewardsUserBindingSource3;
        private System.Windows.Forms.DataGridView dgvReward;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn bith;
        private System.Windows.Forms.DataGridViewTextBoxColumn age;
        private System.Windows.Forms.DataGridViewComboBoxColumn rewards;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}


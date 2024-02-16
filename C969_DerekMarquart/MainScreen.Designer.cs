
namespace C969_DerekMarquart
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.dataGridMembers = new System.Windows.Forms.DataGridView();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dataGridAppts = new System.Windows.Forms.DataGridView();
            this.buttonCreateAppt = new System.Windows.Forms.Button();
            this.buttonModAppt = new System.Windows.Forms.Button();
            this.buttonDelAppt = new System.Windows.Forms.Button();
            this.buttonReports = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAppts)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(17, 16);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(112, 17);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Logged in as: ";
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(1349, 927);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(208, 59);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // dataGridMembers
            // 
            this.dataGridMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMembers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridMembers.Location = new System.Drawing.Point(21, 59);
            this.dataGridMembers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridMembers.Name = "dataGridMembers";
            this.dataGridMembers.RowHeadersWidth = 51;
            this.dataGridMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMembers.Size = new System.Drawing.Size(1536, 314);
            this.dataGridMembers.TabIndex = 2;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.Location = new System.Drawing.Point(84, 380);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(208, 59);
            this.buttonCreate.TabIndex = 3;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(388, 380);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(208, 59);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(676, 380);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(208, 59);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // dataGridAppts
            // 
            this.dataGridAppts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAppts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAppts.Location = new System.Drawing.Point(16, 458);
            this.dataGridAppts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridAppts.Name = "dataGridAppts";
            this.dataGridAppts.RowHeadersWidth = 51;
            this.dataGridAppts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAppts.Size = new System.Drawing.Size(1541, 314);
            this.dataGridAppts.TabIndex = 6;
            // 
            // buttonCreateAppt
            // 
            this.buttonCreateAppt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateAppt.Location = new System.Drawing.Point(343, 927);
            this.buttonCreateAppt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCreateAppt.Name = "buttonCreateAppt";
            this.buttonCreateAppt.Size = new System.Drawing.Size(208, 59);
            this.buttonCreateAppt.TabIndex = 7;
            this.buttonCreateAppt.Text = "Create";
            this.buttonCreateAppt.UseVisualStyleBackColor = true;
            this.buttonCreateAppt.Click += new System.EventHandler(this.buttonCreateAppt_Click);
            // 
            // buttonModAppt
            // 
            this.buttonModAppt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModAppt.Location = new System.Drawing.Point(588, 927);
            this.buttonModAppt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonModAppt.Name = "buttonModAppt";
            this.buttonModAppt.Size = new System.Drawing.Size(208, 59);
            this.buttonModAppt.TabIndex = 8;
            this.buttonModAppt.Text = "Update";
            this.buttonModAppt.UseVisualStyleBackColor = true;
            this.buttonModAppt.Click += new System.EventHandler(this.buttonModAppt_Click);
            // 
            // buttonDelAppt
            // 
            this.buttonDelAppt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelAppt.Location = new System.Drawing.Point(840, 927);
            this.buttonDelAppt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDelAppt.Name = "buttonDelAppt";
            this.buttonDelAppt.Size = new System.Drawing.Size(208, 59);
            this.buttonDelAppt.TabIndex = 9;
            this.buttonDelAppt.Text = "Delete";
            this.buttonDelAppt.UseVisualStyleBackColor = true;
            this.buttonDelAppt.Click += new System.EventHandler(this.buttonDelAppt_Click);
            // 
            // buttonReports
            // 
            this.buttonReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReports.Location = new System.Drawing.Point(1103, 927);
            this.buttonReports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(208, 59);
            this.buttonReports.TabIndex = 10;
            this.buttonReports.Text = "Reports";
            this.buttonReports.UseVisualStyleBackColor = true;
            this.buttonReports.Click += new System.EventHandler(this.buttonReports_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(24, 786);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 11;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1573, 1001);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.buttonReports);
            this.Controls.Add(this.buttonDelAppt);
            this.Controls.Add(this.buttonModAppt);
            this.Controls.Add(this.buttonCreateAppt);
            this.Controls.Add(this.dataGridAppts);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.dataGridMembers);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelUsername);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAppts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.DataGridView dataGridMembers;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView dataGridAppts;
        private System.Windows.Forms.Button buttonCreateAppt;
        private System.Windows.Forms.Button buttonModAppt;
        private System.Windows.Forms.Button buttonDelAppt;
        private System.Windows.Forms.Button buttonReports;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}
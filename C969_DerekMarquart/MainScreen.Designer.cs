
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
            this.labelUsername.Location = new System.Drawing.Point(13, 13);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(88, 13);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Logged in as: ";
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(1012, 713);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(156, 48);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // dataGridMembers
            // 
            this.dataGridMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMembers.Location = new System.Drawing.Point(16, 48);
            this.dataGridMembers.Name = "dataGridMembers";
            this.dataGridMembers.Size = new System.Drawing.Size(1152, 255);
            this.dataGridMembers.TabIndex = 2;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.Location = new System.Drawing.Point(63, 309);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(156, 48);
            this.buttonCreate.TabIndex = 3;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(291, 309);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(156, 48);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(507, 309);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(156, 48);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // dataGridAppts
            // 
            this.dataGridAppts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAppts.Location = new System.Drawing.Point(16, 450);
            this.dataGridAppts.Name = "dataGridAppts";
            this.dataGridAppts.Size = new System.Drawing.Size(748, 266);
            this.dataGridAppts.TabIndex = 6;
            // 
            // buttonCreateAppt
            // 
            this.buttonCreateAppt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateAppt.Location = new System.Drawing.Point(1012, 450);
            this.buttonCreateAppt.Name = "buttonCreateAppt";
            this.buttonCreateAppt.Size = new System.Drawing.Size(156, 48);
            this.buttonCreateAppt.TabIndex = 7;
            this.buttonCreateAppt.Text = "Create";
            this.buttonCreateAppt.UseVisualStyleBackColor = true;
            // 
            // buttonModAppt
            // 
            this.buttonModAppt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModAppt.Location = new System.Drawing.Point(1012, 516);
            this.buttonModAppt.Name = "buttonModAppt";
            this.buttonModAppt.Size = new System.Drawing.Size(156, 48);
            this.buttonModAppt.TabIndex = 8;
            this.buttonModAppt.Text = "Update";
            this.buttonModAppt.UseVisualStyleBackColor = true;
            // 
            // buttonDelAppt
            // 
            this.buttonDelAppt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelAppt.Location = new System.Drawing.Point(1012, 581);
            this.buttonDelAppt.Name = "buttonDelAppt";
            this.buttonDelAppt.Size = new System.Drawing.Size(156, 48);
            this.buttonDelAppt.TabIndex = 9;
            this.buttonDelAppt.Text = "Delete";
            this.buttonDelAppt.UseVisualStyleBackColor = true;
            // 
            // buttonReports
            // 
            this.buttonReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReports.Location = new System.Drawing.Point(1012, 645);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(156, 48);
            this.buttonReports.TabIndex = 10;
            this.buttonReports.Text = "Reports";
            this.buttonReports.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(773, 516);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 11;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1180, 773);
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
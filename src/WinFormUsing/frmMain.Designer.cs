namespace WinFormUsing
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grbRegion = new System.Windows.Forms.GroupBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.fldRegion = new System.Windows.Forms.ComboBox();
            this.grbAddresse = new System.Windows.Forms.GroupBox();
            this.fldCity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fldStreet = new System.Windows.Forms.ComboBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.fldTown = new System.Windows.Forms.ComboBox();
            this.lblTown = new System.Windows.Forms.Label();
            this.fldDistrict = new System.Windows.Forms.ComboBox();
            this.ldlDistrict = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.fldTypeReader = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFolderDialog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fldFolderDialog = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.grbRegion.SuspendLayout();
            this.grbAddresse.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbRegion
            // 
            this.grbRegion.Controls.Add(this.lblRegion);
            this.grbRegion.Controls.Add(this.fldRegion);
            this.grbRegion.Location = new System.Drawing.Point(345, 12);
            this.grbRegion.Name = "grbRegion";
            this.grbRegion.Size = new System.Drawing.Size(305, 76);
            this.grbRegion.TabIndex = 1;
            this.grbRegion.TabStop = false;
            this.grbRegion.Text = "Регион";
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(6, 24);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(43, 13);
            this.lblRegion.TabIndex = 1;
            this.lblRegion.Text = "Регион";
            // 
            // fldRegion
            // 
            this.fldRegion.DisplayMember = "Name";
            this.fldRegion.FormattingEnabled = true;
            this.fldRegion.Location = new System.Drawing.Point(6, 40);
            this.fldRegion.Name = "fldRegion";
            this.fldRegion.Size = new System.Drawing.Size(293, 21);
            this.fldRegion.TabIndex = 1;
            this.fldRegion.ValueMember = "Code";
            this.fldRegion.SelectedValueChanged += new System.EventHandler(this.fldRegion_SelectedValueChanged);
            // 
            // grbAddresse
            // 
            this.grbAddresse.Controls.Add(this.fldCity);
            this.grbAddresse.Controls.Add(this.label3);
            this.grbAddresse.Controls.Add(this.fldStreet);
            this.grbAddresse.Controls.Add(this.lblStreet);
            this.grbAddresse.Controls.Add(this.fldTown);
            this.grbAddresse.Controls.Add(this.lblTown);
            this.grbAddresse.Controls.Add(this.fldDistrict);
            this.grbAddresse.Controls.Add(this.ldlDistrict);
            this.grbAddresse.Location = new System.Drawing.Point(339, 94);
            this.grbAddresse.Name = "grbAddresse";
            this.grbAddresse.Size = new System.Drawing.Size(305, 202);
            this.grbAddresse.TabIndex = 2;
            this.grbAddresse.TabStop = false;
            this.grbAddresse.Text = "Полный адрес";
            // 
            // fldCity
            // 
            this.fldCity.DisplayMember = "Name";
            this.fldCity.FormattingEnabled = true;
            this.fldCity.Location = new System.Drawing.Point(6, 87);
            this.fldCity.Name = "fldCity";
            this.fldCity.Size = new System.Drawing.Size(293, 21);
            this.fldCity.TabIndex = 2;
            this.fldCity.ValueMember = "Code";
            this.fldCity.SelectedValueChanged += new System.EventHandler(this.fldCity_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Город";
            // 
            // fldStreet
            // 
            this.fldStreet.DisplayMember = "Name";
            this.fldStreet.FormattingEnabled = true;
            this.fldStreet.Location = new System.Drawing.Point(6, 167);
            this.fldStreet.Name = "fldStreet";
            this.fldStreet.Size = new System.Drawing.Size(293, 21);
            this.fldStreet.TabIndex = 4;
            this.fldStreet.ValueMember = "Code";
            this.fldStreet.SelectedValueChanged += new System.EventHandler(this.fldStreet_SelectedValueChanged);
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(6, 151);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(39, 13);
            this.lblStreet.TabIndex = 4;
            this.lblStreet.Text = "Улица";
            // 
            // fldTown
            // 
            this.fldTown.DisplayMember = "Name";
            this.fldTown.FormattingEnabled = true;
            this.fldTown.Location = new System.Drawing.Point(6, 127);
            this.fldTown.Name = "fldTown";
            this.fldTown.Size = new System.Drawing.Size(293, 21);
            this.fldTown.TabIndex = 3;
            this.fldTown.ValueMember = "Code";
            this.fldTown.SelectedValueChanged += new System.EventHandler(this.fldTown_SelectedValueChanged);
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.Location = new System.Drawing.Point(3, 111);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(269, 13);
            this.lblTown.TabIndex = 2;
            this.lblTown.Text = "Населенный пункт /или НП в подчинении у города/";
            // 
            // fldDistrict
            // 
            this.fldDistrict.DisplayMember = "Name";
            this.fldDistrict.FormattingEnabled = true;
            this.fldDistrict.Location = new System.Drawing.Point(6, 43);
            this.fldDistrict.Name = "fldDistrict";
            this.fldDistrict.Size = new System.Drawing.Size(293, 21);
            this.fldDistrict.TabIndex = 1;
            this.fldDistrict.ValueMember = "Code";
            this.fldDistrict.SelectedIndexChanged += new System.EventHandler(this.fldDistrict_SelectedIndexChanged);
            this.fldDistrict.SelectedValueChanged += new System.EventHandler(this.fldDistrict_SelectedValueChanged);
            // 
            // ldlDistrict
            // 
            this.ldlDistrict.AutoSize = true;
            this.ldlDistrict.Location = new System.Drawing.Point(6, 27);
            this.ldlDistrict.Name = "ldlDistrict";
            this.ldlDistrict.Size = new System.Drawing.Size(139, 13);
            this.ldlDistrict.TabIndex = 0;
            this.ldlDistrict.Text = "Административный район";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.fldTypeReader);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnFolderDialog);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fldFolderDialog);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройка";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(224, 98);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // fldTypeReader
            // 
            this.fldTypeReader.DisplayMember = "Name";
            this.fldTypeReader.FormattingEnabled = true;
            this.fldTypeReader.Location = new System.Drawing.Point(6, 71);
            this.fldTypeReader.Name = "fldTypeReader";
            this.fldTypeReader.Size = new System.Drawing.Size(293, 21);
            this.fldTypeReader.TabIndex = 3;
            this.fldTypeReader.ValueMember = "CodeEnum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Реализация чтения классификатора";
            // 
            // btnFolderDialog
            // 
            this.btnFolderDialog.Location = new System.Drawing.Point(273, 32);
            this.btnFolderDialog.Name = "btnFolderDialog";
            this.btnFolderDialog.Size = new System.Drawing.Size(26, 20);
            this.btnFolderDialog.TabIndex = 2;
            this.btnFolderDialog.Text = "...";
            this.btnFolderDialog.UseVisualStyleBackColor = true;
            this.btnFolderDialog.Click += new System.EventHandler(this.btnFolderDialog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Путь к папке классификатора";
            // 
            // fldFolderDialog
            // 
            this.fldFolderDialog.Location = new System.Drawing.Point(6, 32);
            this.fldFolderDialog.Name = "fldFolderDialog";
            this.fldFolderDialog.Size = new System.Drawing.Size(269, 20);
            this.fldFolderDialog.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(12, 150);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(305, 108);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 328);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbAddresse);
            this.Controls.Add(this.grbRegion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор адреса";
            this.grbRegion.ResumeLayout(false);
            this.grbRegion.PerformLayout();
            this.grbAddresse.ResumeLayout(false);
            this.grbAddresse.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbRegion;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.ComboBox fldRegion;
        private System.Windows.Forms.GroupBox grbAddresse;
        private System.Windows.Forms.ComboBox fldStreet;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.ComboBox fldTown;
        private System.Windows.Forms.Label lblTown;
        private System.Windows.Forms.ComboBox fldDistrict;
        private System.Windows.Forms.Label ldlDistrict;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFolderDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fldFolderDialog;
        private System.Windows.Forms.ComboBox fldTypeReader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox fldCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}


namespace DP._205786148._308340223
{
    partial class FormSearch
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelFilters = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.comboBoxRelationshipStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxInterestedIn = new System.Windows.Forms.ComboBox();
            this.comboBoxReligion = new System.Windows.Forms.ComboBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.checkBoxLocation = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(13, 13);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(78, 35);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelFilters
            // 
            this.labelFilters.AutoSize = true;
            this.labelFilters.Location = new System.Drawing.Point(98, 13);
            this.labelFilters.Name = "labelFilters";
            this.labelFilters.Size = new System.Drawing.Size(46, 17);
            this.labelFilters.TabIndex = 1;
            this.labelFilters.Text = "Filters";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(13, 70);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(191, 372);
            this.listBox1.TabIndex = 4;
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Location = new System.Drawing.Point(150, 10);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(121, 24);
            this.comboBoxGender.TabIndex = 2;
            this.comboBoxGender.Text = "Gender";
            this.comboBoxGender.SelectedIndexChanged += new System.EventHandler(this.comboBoxGender_SelectedIndexChanged);
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(277, 10);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(121, 24);
            this.comboBoxLanguage.TabIndex = 2;
            this.comboBoxLanguage.Text = "Language";
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxGender_SelectedIndexChanged);
            // 
            // comboBoxRelationshipStatus
            // 
            this.comboBoxRelationshipStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRelationshipStatus.FormattingEnabled = true;
            this.comboBoxRelationshipStatus.Location = new System.Drawing.Point(404, 10);
            this.comboBoxRelationshipStatus.Name = "comboBoxRelationshipStatus";
            this.comboBoxRelationshipStatus.Size = new System.Drawing.Size(153, 24);
            this.comboBoxRelationshipStatus.TabIndex = 2;
            this.comboBoxRelationshipStatus.Text = "Relationship Status";
            this.comboBoxRelationshipStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxGender_SelectedIndexChanged);
            // 
            // comboBoxInterestedIn
            // 
            this.comboBoxInterestedIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxInterestedIn.FormattingEnabled = true;
            this.comboBoxInterestedIn.Location = new System.Drawing.Point(563, 10);
            this.comboBoxInterestedIn.Name = "comboBoxInterestedIn";
            this.comboBoxInterestedIn.Size = new System.Drawing.Size(121, 24);
            this.comboBoxInterestedIn.TabIndex = 2;
            this.comboBoxInterestedIn.Text = "Interested In";
            this.comboBoxInterestedIn.SelectedIndexChanged += new System.EventHandler(this.comboBoxGender_SelectedIndexChanged);
            // 
            // comboBoxReligion
            // 
            this.comboBoxReligion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxReligion.FormattingEnabled = true;
            this.comboBoxReligion.Location = new System.Drawing.Point(150, 40);
            this.comboBoxReligion.Name = "comboBoxReligion";
            this.comboBoxReligion.Size = new System.Drawing.Size(121, 24);
            this.comboBoxReligion.TabIndex = 2;
            this.comboBoxReligion.Text = "Religion";
            this.comboBoxReligion.SelectedIndexChanged += new System.EventHandler(this.comboBoxGender_SelectedIndexChanged);
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(277, 40);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(121, 22);
            this.textBoxFirstName.TabIndex = 7;
            this.textBoxFirstName.Text = "First Name";
            this.textBoxFirstName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxFirstName_MouseClick);
            this.textBoxFirstName.TextChanged += new System.EventHandler(this.textBoxFirstName_TextChanged);
            this.textBoxFirstName.Leave += new System.EventHandler(this.textBoxFirstName_Leave);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(404, 40);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(153, 22);
            this.textBoxLastName.TabIndex = 7;
            this.textBoxLastName.Text = "Last Name";
            this.textBoxLastName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxLastName_MouseClick);
            this.textBoxLastName.TextChanged += new System.EventHandler(this.textBoxLastName_TextChanged);
            this.textBoxLastName.Leave += new System.EventHandler(this.textBoxLastName_Leave);
            // 
            // checkBoxLocation
            // 
            this.checkBoxLocation.AutoSize = true;
            this.checkBoxLocation.Location = new System.Drawing.Point(563, 40);
            this.checkBoxLocation.Name = "checkBoxLocation";
            this.checkBoxLocation.Size = new System.Drawing.Size(84, 21);
            this.checkBoxLocation.TabIndex = 8;
            this.checkBoxLocation.Text = "Location";
            this.checkBoxLocation.UseVisualStyleBackColor = true;
            this.checkBoxLocation.CheckedChanged += new System.EventHandler(this.checkBoxLocation_CheckedChanged);
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxLocation);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.comboBoxInterestedIn);
            this.Controls.Add(this.comboBoxRelationshipStatus);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.labelFilters);
            this.Controls.Add(this.comboBoxReligion);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.buttonSearch);
            this.Name = "FormSearch";
            this.Text = "FormSearch";
            this.Load += new System.EventHandler(this.FormSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelFilters;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.ComboBox comboBoxRelationshipStatus;
        private System.Windows.Forms.ComboBox comboBoxInterestedIn;
        private System.Windows.Forms.ComboBox comboBoxReligion;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.CheckBox checkBoxLocation;
    }
}
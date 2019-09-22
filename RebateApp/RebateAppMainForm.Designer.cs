namespace RebateApp
{
    partial class RebateAppMainForm
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtMiddleInitial = new System.Windows.Forms.TextBox();
            this.lblMiddleInitial = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtAddrLine1 = new System.Windows.Forms.TextBox();
            this.lblAddrLine1 = new System.Windows.Forms.Label();
            this.txtAddrLine2 = new System.Windows.Forms.TextBox();
            this.lblAddrLine2 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.lblZipCode = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblPhoneNum = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblProofPurchase = new System.Windows.Forms.Label();
            this.lblDateReceived = new System.Windows.Forms.Label();
            this.dateTimePickerDateReceived = new System.Windows.Forms.DateTimePicker();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.cboProofPurchase = new System.Windows.Forms.ComboBox();
            this.masktxtPhoneNum = new System.Windows.Forms.MaskedTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.statusStripRebateApp = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCurrentMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.listViewRebateRecords = new System.Windows.Forms.ListView();
            this.btnAddMode = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.statusStripRebateApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(47, 13);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(110, 10);
            this.txtFirstName.MaxLength = 20;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(125, 20);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtFirstName_KeyDown);
            this.txtFirstName.Leave += new System.EventHandler(this.TxtFirstName_Leave);
            // 
            // txtMiddleInitial
            // 
            this.txtMiddleInitial.Location = new System.Drawing.Point(110, 36);
            this.txtMiddleInitial.MaxLength = 1;
            this.txtMiddleInitial.Name = "txtMiddleInitial";
            this.txtMiddleInitial.Size = new System.Drawing.Size(20, 20);
            this.txtMiddleInitial.TabIndex = 3;
            // 
            // lblMiddleInitial
            // 
            this.lblMiddleInitial.AutoSize = true;
            this.lblMiddleInitial.Location = new System.Drawing.Point(39, 39);
            this.lblMiddleInitial.Name = "lblMiddleInitial";
            this.lblMiddleInitial.Size = new System.Drawing.Size(65, 13);
            this.lblMiddleInitial.TabIndex = 2;
            this.lblMiddleInitial.Text = "Middle Initial";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(110, 62);
            this.txtLastName.MaxLength = 20;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(125, 20);
            this.txtLastName.TabIndex = 5;
            this.txtLastName.Leave += new System.EventHandler(this.TxtLastName_Leave);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(46, 65);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name";
            // 
            // txtAddrLine1
            // 
            this.txtAddrLine1.Location = new System.Drawing.Point(110, 88);
            this.txtAddrLine1.MaxLength = 35;
            this.txtAddrLine1.Name = "txtAddrLine1";
            this.txtAddrLine1.Size = new System.Drawing.Size(215, 20);
            this.txtAddrLine1.TabIndex = 7;
            this.txtAddrLine1.Leave += new System.EventHandler(this.TxtAddrLine1_Leave);
            // 
            // lblAddrLine1
            // 
            this.lblAddrLine1.AutoSize = true;
            this.lblAddrLine1.Location = new System.Drawing.Point(27, 91);
            this.lblAddrLine1.Name = "lblAddrLine1";
            this.lblAddrLine1.Size = new System.Drawing.Size(77, 13);
            this.lblAddrLine1.TabIndex = 6;
            this.lblAddrLine1.Text = "Address Line 1";
            // 
            // txtAddrLine2
            // 
            this.txtAddrLine2.Location = new System.Drawing.Point(110, 114);
            this.txtAddrLine2.MaxLength = 35;
            this.txtAddrLine2.Name = "txtAddrLine2";
            this.txtAddrLine2.Size = new System.Drawing.Size(215, 20);
            this.txtAddrLine2.TabIndex = 9;
            // 
            // lblAddrLine2
            // 
            this.lblAddrLine2.AutoSize = true;
            this.lblAddrLine2.Location = new System.Drawing.Point(27, 117);
            this.lblAddrLine2.Name = "lblAddrLine2";
            this.lblAddrLine2.Size = new System.Drawing.Size(77, 13);
            this.lblAddrLine2.TabIndex = 8;
            this.lblAddrLine2.Text = "Address Line 2";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(110, 140);
            this.txtCity.MaxLength = 25;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(155, 20);
            this.txtCity.TabIndex = 11;
            this.txtCity.Leave += new System.EventHandler(this.TxtCity_Leave);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(80, 143);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 10;
            this.lblCity.Text = "City";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(110, 166);
            this.txtState.MaxLength = 2;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(30, 20);
            this.txtState.TabIndex = 13;
            this.txtState.Leave += new System.EventHandler(this.TxtState_Leave);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(72, 169);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 13);
            this.lblState.TabIndex = 12;
            this.lblState.Text = "State";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(110, 192);
            this.txtZipCode.MaxLength = 9;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(60, 20);
            this.txtZipCode.TabIndex = 15;
            this.txtZipCode.Leave += new System.EventHandler(this.TxtZipCode_Leave);
            // 
            // lblZipCode
            // 
            this.lblZipCode.AutoSize = true;
            this.lblZipCode.Location = new System.Drawing.Point(54, 195);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(50, 13);
            this.lblZipCode.TabIndex = 14;
            this.lblZipCode.Text = "Zip Code";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(62, 221);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 16;
            this.lblGender.Text = "Gender";
            // 
            // lblPhoneNum
            // 
            this.lblPhoneNum.AutoSize = true;
            this.lblPhoneNum.Location = new System.Drawing.Point(26, 247);
            this.lblPhoneNum.Name = "lblPhoneNum";
            this.lblPhoneNum.Size = new System.Drawing.Size(78, 13);
            this.lblPhoneNum.TabIndex = 18;
            this.lblPhoneNum.Text = "Phone Number";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(110, 270);
            this.txtEmail.MaxLength = 60;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(365, 20);
            this.txtEmail.TabIndex = 21;
            this.txtEmail.Leave += new System.EventHandler(this.TxtEmail_Leave);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(31, 273);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(73, 13);
            this.lblEmail.TabIndex = 20;
            this.lblEmail.Text = "Email Address";
            // 
            // lblProofPurchase
            // 
            this.lblProofPurchase.AutoSize = true;
            this.lblProofPurchase.Location = new System.Drawing.Point(12, 295);
            this.lblProofPurchase.Name = "lblProofPurchase";
            this.lblProofPurchase.Size = new System.Drawing.Size(92, 26);
            this.lblProofPurchase.TabIndex = 22;
            this.lblProofPurchase.Text = "Proof of Purchase\r\nAttached";
            // 
            // lblDateReceived
            // 
            this.lblDateReceived.AutoSize = true;
            this.lblDateReceived.Location = new System.Drawing.Point(27, 328);
            this.lblDateReceived.Name = "lblDateReceived";
            this.lblDateReceived.Size = new System.Drawing.Size(79, 13);
            this.lblDateReceived.TabIndex = 24;
            this.lblDateReceived.Text = "Date Recieved";
            // 
            // dateTimePickerDateReceived
            // 
            this.dateTimePickerDateReceived.Location = new System.Drawing.Point(110, 322);
            this.dateTimePickerDateReceived.Name = "dateTimePickerDateReceived";
            this.dateTimePickerDateReceived.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDateReceived.TabIndex = 25;
            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cboGender.Location = new System.Drawing.Point(110, 218);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(40, 21);
            this.cboGender.TabIndex = 17;
            this.cboGender.Leave += new System.EventHandler(this.CboGender_Leave);
            // 
            // cboProofPurchase
            // 
            this.cboProofPurchase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProofPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProofPurchase.FormattingEnabled = true;
            this.cboProofPurchase.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cboProofPurchase.Location = new System.Drawing.Point(110, 295);
            this.cboProofPurchase.Name = "cboProofPurchase";
            this.cboProofPurchase.Size = new System.Drawing.Size(45, 21);
            this.cboProofPurchase.TabIndex = 23;
            this.cboProofPurchase.Leave += new System.EventHandler(this.CboProofPurchase_Leave);
            // 
            // masktxtPhoneNum
            // 
            this.masktxtPhoneNum.Location = new System.Drawing.Point(110, 244);
            this.masktxtPhoneNum.Mask = "(999) 000-0000";
            this.masktxtPhoneNum.Name = "masktxtPhoneNum";
            this.masktxtPhoneNum.Size = new System.Drawing.Size(80, 20);
            this.masktxtPhoneNum.TabIndex = 19;
            this.masktxtPhoneNum.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.masktxtPhoneNum.Leave += new System.EventHandler(this.MasktxtPhoneNum_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(110, 362);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // statusStripRebateApp
            // 
            this.statusStripRebateApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCurrentMode,
            this.toolStripStatusLabelStatusMsg});
            this.statusStripRebateApp.Location = new System.Drawing.Point(0, 428);
            this.statusStripRebateApp.Name = "statusStripRebateApp";
            this.statusStripRebateApp.Size = new System.Drawing.Size(832, 22);
            this.statusStripRebateApp.TabIndex = 30;
            this.statusStripRebateApp.Text = "statusStrip";
            // 
            // toolStripStatusLabelCurrentMode
            // 
            this.toolStripStatusLabelCurrentMode.Name = "toolStripStatusLabelCurrentMode";
            this.toolStripStatusLabelCurrentMode.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabelCurrentMode.Text = "Current Mode: ";
            // 
            // toolStripStatusLabelStatusMsg
            // 
            this.toolStripStatusLabelStatusMsg.Name = "toolStripStatusLabelStatusMsg";
            this.toolStripStatusLabelStatusMsg.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabelStatusMsg.Text = "Status: ";
            // 
            // listViewRebateRecords
            // 
            this.listViewRebateRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewRebateRecords.FullRowSelect = true;
            this.listViewRebateRecords.HideSelection = false;
            this.listViewRebateRecords.Location = new System.Drawing.Point(491, 12);
            this.listViewRebateRecords.MultiSelect = false;
            this.listViewRebateRecords.Name = "listViewRebateRecords";
            this.listViewRebateRecords.Size = new System.Drawing.Size(329, 413);
            this.listViewRebateRecords.TabIndex = 29;
            this.listViewRebateRecords.UseCompatibleStateImageBehavior = false;
            this.listViewRebateRecords.Click += new System.EventHandler(this.ListViewRebateRecords_Click);
            this.listViewRebateRecords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListViewRebateRecords_KeyDown);
            this.listViewRebateRecords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListViewRebateRecords_KeyPress);
            this.listViewRebateRecords.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListViewRebateRecords_MouseUp);
            // 
            // btnAddMode
            // 
            this.btnAddMode.Location = new System.Drawing.Point(410, 402);
            this.btnAddMode.Name = "btnAddMode";
            this.btnAddMode.Size = new System.Drawing.Size(75, 23);
            this.btnAddMode.TabIndex = 28;
            this.btnAddMode.Text = "Add Mode";
            this.btnAddMode.UseVisualStyleBackColor = true;
            this.btnAddMode.Click += new System.EventHandler(this.BtnAddMode_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(309, 402);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 23);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear All Fields";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // RebateAppMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAddMode);
            this.Controls.Add(this.listViewRebateRecords);
            this.Controls.Add(this.statusStripRebateApp);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.masktxtPhoneNum);
            this.Controls.Add(this.cboProofPurchase);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.dateTimePickerDateReceived);
            this.Controls.Add(this.lblDateReceived);
            this.Controls.Add(this.lblProofPurchase);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhoneNum);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtZipCode);
            this.Controls.Add(this.lblZipCode);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtAddrLine2);
            this.Controls.Add(this.lblAddrLine2);
            this.Controls.Add(this.txtAddrLine1);
            this.Controls.Add(this.lblAddrLine1);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtMiddleInitial);
            this.Controls.Add(this.lblMiddleInitial);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.KeyPreview = true;
            this.Name = "RebateAppMainForm";
            this.Text = "RebateAppMainForm";
            this.Load += new System.EventHandler(this.RebateAppMainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RebateAppMainForm_KeyPress);
            this.statusStripRebateApp.ResumeLayout(false);
            this.statusStripRebateApp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleInitial;
        private System.Windows.Forms.Label lblMiddleInitial;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtAddrLine1;
        private System.Windows.Forms.Label lblAddrLine1;
        private System.Windows.Forms.TextBox txtAddrLine2;
        private System.Windows.Forms.Label lblAddrLine2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label lblZipCode;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblPhoneNum;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblProofPurchase;
        private System.Windows.Forms.Label lblDateReceived;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateReceived;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.ComboBox cboProofPurchase;
        private System.Windows.Forms.MaskedTextBox masktxtPhoneNum;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.StatusStrip statusStripRebateApp;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCurrentMode;
        private System.Windows.Forms.ListView listViewRebateRecords;
        private System.Windows.Forms.Button btnAddMode;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatusMsg;
        private System.Windows.Forms.Button btnClear;
    }
}


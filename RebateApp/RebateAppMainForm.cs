using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RebateApp
{
    public partial class RebateAppMainForm : Form
    {
        //Hidden Fields Variables
        public String mainform_TimeFirstEntered;
        public String mainform_TimePressedSave;
        public int mainform_NumPressedBackSpace;

        public RebateAppMainForm()
        {
            InitializeComponent();

            //Initialze starting hidden fields variables
            ResetHiddenVariables();
        }

        private void RebateAppMainForm_Load(object sender, EventArgs e)
        {
            //Change ListView Settings
            listViewRebateRecords.View = View.Details;
            listViewRebateRecords.GridLines = true;
            listViewRebateRecords.Columns.Add("First Name");
            listViewRebateRecords.Columns.Add("Last Name");
            listViewRebateRecords.Columns.Add("Phone Number");
            listViewRebateRecords.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewRebateRecords.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //Set MaxDate of DateTimePicker
            dateTimePickerDateReceived.MaxDate = DateTime.Today;

            //Refreshes the form to default
            RefreshForm();
        }


        #region Edit Mode Populate Code
        private void ListViewRebateRecords_Click(object sender, EventArgs e)
        {
            ListViewRebateRecords_EditEvent();
        }

        private void ListViewRebateRecords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                ListViewRebateRecords_EditEvent();
            }
        }

        private void ListViewRebateRecords_EditEvent()
        {
            //First changes the mode to EditMode
            ChangeCurrentMode(Domain.CurrentMode.editMode);

            //Enables Delte Button
            btnDelete.Enabled = true;

            //Does not do the edit event if there are no selected items
            if (listViewRebateRecords.SelectedItems.Count == 0)
            {
                return;
            }

            //Obtains rebateInfo from single selected item
            Domain.RebateInfo rebateInfo = (Domain.RebateInfo)listViewRebateRecords.SelectedItems[0].Tag;

            //Populates fields from rebateInfo
            txtFirstName.Text = rebateInfo.Fname;
            txtMiddleInitial.Text = rebateInfo.Minit;
            txtLastName.Text = rebateInfo.Lname;
            txtAddrLine1.Text = rebateInfo.Addr1;
            txtAddrLine2.Text = rebateInfo.Addr2;
            txtCity.Text = rebateInfo.City;
            txtState.Text = rebateInfo.State;
            txtZipCode.Text = rebateInfo.Zip;
            cboGender.SelectedIndex = cboGender.FindStringExact(rebateInfo.Gender);
            masktxtPhoneNum.Text = rebateInfo.PhoneNum;
            txtEmail.Text = rebateInfo.Email;
            cboProofPurchase.SelectedIndex = cboProofPurchase.FindStringExact(rebateInfo.ProofPurchase);
            dateTimePickerDateReceived.Value = DateTime.ParseExact(rebateInfo.DateRecieved, "M/dd/yyyy", CultureInfo.InvariantCulture);

            //After populating it will check for valid (should be valid)
            CheckFields_ShowErrorColors();
        }
        #endregion


        private void ListViewRebateRecords_MouseUp(object sender, MouseEventArgs e)
        {
            //Keeps listview selected even when user clicks into empty space on listview controller
            //works if no multiselect
            if (listViewRebateRecords.FocusedItem != null)
            {
                if (listViewRebateRecords.SelectedItems.Count == 0)
                    listViewRebateRecords.FocusedItem.Selected = true;
            }
        }


        #region Delete Functions Code
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ListViewRebateRecords_DeleteEvent();
        }

        private void ListViewRebateRecords_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ListViewRebateRecords_DeleteEvent();
            }
        }

        private void ListViewRebateRecords_DeleteEvent()
        {
            //Does not do the follwing if there are no selected items
            if (listViewRebateRecords.SelectedItems.Count == 0)
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record permanently?", "Delete Record Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Removes the selcted ListViewItem
                listViewRebateRecords.SelectedItems[0].Remove();

                //Will save the listview as list to the DAL
                BLL.BLLSingleton.Instance.SaveRebateInfo(RebateInfoListViewToList(listViewRebateRecords));

                //Refreshes the form to default
                RefreshForm();
            }
            else if (dialogResult == DialogResult.No)
            {

            }

        }
        #endregion Code


        #region Save Functions Code
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //First records when button save was clicked. Also checks if its in addmode
            if (mainform_TimePressedSave.Equals(Domain.CurrentMode.defaultHiddenVarTime) && BLL.BLLSingleton.Instance.currentMode.Equals(Domain.CurrentMode.addMode))
            {
                mainform_TimePressedSave = DateTime.Now.ToString();
            }

            //testing
            //MessageBox.Show(mainform_TimeFirstEntered);
            //MessageBox.Show(mainform_TimePressedSave);
            //MessageBox.Show(mainform_NumPressedBackSpace.ToString());

            if (FieldsValidation())
            {
                //First creates a rebateInfo to store field data
                Domain.RebateInfo rebateInfo = new Domain.RebateInfo();
                rebateInfo.Fname = txtFirstName.Text;
                rebateInfo.Minit = txtMiddleInitial.Text;
                rebateInfo.Lname = txtLastName.Text;
                rebateInfo.Addr1 = txtAddrLine1.Text;
                rebateInfo.Addr2 = txtAddrLine2.Text;
                rebateInfo.City = txtCity.Text;
                rebateInfo.State = txtState.Text;
                rebateInfo.Zip = txtZipCode.Text;
                rebateInfo.Gender = cboGender.SelectedItem.ToString();
                rebateInfo.PhoneNum = masktxtPhoneNum.Text;
                rebateInfo.Email = txtEmail.Text;
                rebateInfo.ProofPurchase = cboProofPurchase.SelectedItem.ToString();
                rebateInfo.DateRecieved = dateTimePickerDateReceived.Value.ToString("M/dd/yyyy");

                //Different Modes will save in different ways
                if (BLL.BLLSingleton.Instance.currentMode.Equals(Domain.CurrentMode.addMode))
                {
                    //Will use new hidden variable values
                    rebateInfo.TimeFirstEntered = mainform_TimeFirstEntered;
                    rebateInfo.TimePressedSave = mainform_TimePressedSave;
                    rebateInfo.NumPressedBackSpace = mainform_NumPressedBackSpace.ToString();

                    AddMode_Save(rebateInfo);
                }
                else if (BLL.BLLSingleton.Instance.currentMode.Equals(Domain.CurrentMode.editMode))
                {
                    //Does not do the follwing if there are no selected items
                    if (listViewRebateRecords.SelectedItems.Count == 0)
                    {
                        return;
                    }

                    //Get selected ListViewItem
                    Domain.RebateInfo rebateInfo_OLDVALUES = (Domain.RebateInfo)listViewRebateRecords.SelectedItems[0].Tag;

                    //Will use old hidden variable values
                    rebateInfo.TimeFirstEntered = rebateInfo_OLDVALUES.TimeFirstEntered;
                    rebateInfo.TimePressedSave = rebateInfo_OLDVALUES.TimePressedSave;
                    rebateInfo.NumPressedBackSpace = rebateInfo_OLDVALUES.NumPressedBackSpace;

                    EditMode_Save(rebateInfo);
                }

                //Will save the listview as list to the DAL
                BLL.BLLSingleton.Instance.SaveRebateInfo(RebateInfoListViewToList(listViewRebateRecords));

                //Refreshes the form to default
                RefreshForm();
            }

        }

        private void EditMode_Save(Domain.RebateInfo rebateInfo)
        {
            //Does not do the follwing if there are no selected items
            if (listViewRebateRecords.SelectedItems.Count == 0)
            {
                return;
            }

            //Get selected ListViewItem
            ListViewItem selectedItem = listViewRebateRecords.SelectedItems[0];

            //Set new values to ListView
            selectedItem.SubItems[0].Text = rebateInfo.Fname;
            selectedItem.SubItems[1].Text = rebateInfo.Lname;
            selectedItem.SubItems[2].Text = rebateInfo.PhoneNum;
            selectedItem.Tag = rebateInfo;
        }

        private void AddMode_Save(Domain.RebateInfo rebateInfo)
        {
            //Add ListViewItem to ListView
            ListViewItem item = new ListViewItem(new[] { rebateInfo.Fname, rebateInfo.Lname, rebateInfo.PhoneNum });
            item.Tag = rebateInfo;
            listViewRebateRecords.Items.Add(item);
        }
        #endregion


        private ICollection<Domain.RebateInfo> RebateInfoListViewToList(ListView listView)
        {
            List<Domain.RebateInfo> rebateInfos = new List<Domain.RebateInfo>();

            foreach (ListViewItem item in listView.Items)
            {
                Domain.RebateInfo tempRebateInfo = (Domain.RebateInfo)item.Tag;

                rebateInfos.Add(tempRebateInfo);
            }

            return rebateInfos;
        }


        #region Error Handling Code

        #region Check Individual Fields Code
        private Boolean CheckTxtFieldNonEmpty(TextBox txtBox)
        {
            if (txtBox.TextLength > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean CheckStateField(TextBox txtBox)
        {
            if (txtBox.TextLength == 2 && txtBox.Text.All(Char.IsLetter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean CheckZipField(TextBox txtBox)
        {
            if ((txtBox.TextLength == 5 || txtBox.TextLength == 9) && txtBox.Text.All(Char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean CheckCboField(ComboBox cboBox)
        {
            if (cboBox.SelectedIndex > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean CheckMaskTxtField(MaskedTextBox maskTxtBox)
        {
            if (maskTxtBox.MaskCompleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean CheckEmailField(TextBox txtBox)
        {
            if (txtBox.TextLength > 0 && txtBox.Text.Contains("@"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        private Boolean CheckFields()
        {
            Boolean fieldsFlag = false;

            if (CheckTxtFieldNonEmpty(txtFirstName) && CheckTxtFieldNonEmpty(txtLastName) &&
                CheckTxtFieldNonEmpty(txtAddrLine1) && CheckTxtFieldNonEmpty(txtCity) &&
                CheckStateField(txtState) && CheckZipField(txtZipCode) &&
                CheckCboField(cboGender) && CheckMaskTxtField(masktxtPhoneNum) &&
                CheckEmailField(txtEmail) && CheckCboField(cboProofPurchase))
            {
                fieldsFlag = true;
            }
            else
            {
                fieldsFlag = false;
            }

            return fieldsFlag;
        }

        private Boolean CheckUnique()
        {
            Boolean uniqueFlag = false;

            if (BLL.BLLSingleton.Instance.currentMode.Equals(Domain.CurrentMode.addMode))
            {
                if (BLL.BLLSingleton.Instance.CheckUnique(txtFirstName.Text, txtLastName.Text, masktxtPhoneNum.Text))
                {
                    lblFirstName.BackColor = default(Color);
                    lblLastName.BackColor = default(Color);
                    lblPhoneNum.BackColor = default(Color);
                    uniqueFlag = true;
                }
                else
                {
                    lblFirstName.BackColor = Color.Red;
                    lblLastName.BackColor = Color.Red;
                    lblPhoneNum.BackColor = Color.Red;
                    uniqueFlag = false;
                }
            }

            if (BLL.BLLSingleton.Instance.currentMode.Equals(Domain.CurrentMode.editMode))
            {
                //Does not do the follwing if there are no selected items
                if (listViewRebateRecords.SelectedItems.Count == 0)
                {
                    return false;
                }

                Domain.RebateInfo rebateInfo = (Domain.RebateInfo)listViewRebateRecords.SelectedItems[0].Tag;

                Boolean currentRecordMatch = false;

                if (txtFirstName.Text.Equals(rebateInfo.Fname) && txtLastName.Text.Equals(rebateInfo.Lname) && masktxtPhoneNum.Text.Equals(rebateInfo.PhoneNum))
                {
                    currentRecordMatch = true;
                }

                if (BLL.BLLSingleton.Instance.CheckUnique(txtFirstName.Text, txtLastName.Text, masktxtPhoneNum.Text) || currentRecordMatch)
                {
                    lblFirstName.BackColor = default(Color);
                    lblLastName.BackColor = default(Color);
                    lblPhoneNum.BackColor = default(Color);
                    uniqueFlag = true;
                }
                else
                {
                    lblFirstName.BackColor = Color.Red;
                    lblLastName.BackColor = Color.Red;
                    lblPhoneNum.BackColor = Color.Red;
                    uniqueFlag = false;
                }
            }


            return uniqueFlag;
        }

        private void UpdateToolStripStatus()
        {
            String status = "Status: ";

            if (!CheckFields())
            {
                status += "Highlighted fields are invalid. ";
            }

            if (!CheckUnique())
            {
                status += "Highlighted field lables are not unique. ";
            }

            if (CheckFields() && CheckUnique())
            {
                status += "All fields are valid. ";
            }

            toolStripStatusLabelStatusMsg.Text = status;

        }

        private void CheckFields_ShowErrorColors()
        {
            if (CheckTxtFieldNonEmpty(txtFirstName))
            {
                txtFirstName.BackColor = default(Color);
            }
            else
            {
                txtFirstName.BackColor = Color.PaleVioletRed;
            }

            if (CheckTxtFieldNonEmpty(txtLastName))
            {
                txtLastName.BackColor = default(Color);
            }
            else
            {
                txtLastName.BackColor = Color.PaleVioletRed;
            }

            if (CheckTxtFieldNonEmpty(txtAddrLine1))
            {
                txtAddrLine1.BackColor = default(Color);
            }
            else
            {
                txtAddrLine1.BackColor = Color.PaleVioletRed;
            }

            if (CheckTxtFieldNonEmpty(txtCity))
            {
                txtCity.BackColor = default(Color);
            }
            else
            {
                txtCity.BackColor = Color.PaleVioletRed;
            }

            if (CheckStateField(txtState))
            {
                txtState.BackColor = default(Color);
            }
            else
            {
                txtState.BackColor = Color.PaleVioletRed;
            }

            if (CheckZipField(txtZipCode))
            {
                txtZipCode.BackColor = default(Color);
            }
            else
            {
                txtZipCode.BackColor = Color.PaleVioletRed;
            }

            if (CheckCboField(cboGender))
            {
                cboGender.BackColor = default(Color);
            }
            else
            {
                cboGender.BackColor = Color.PaleVioletRed;
            }

            if (CheckMaskTxtField(masktxtPhoneNum))
            {
                masktxtPhoneNum.BackColor = default(Color);
            }
            else
            {
                masktxtPhoneNum.BackColor = Color.PaleVioletRed;
            }

            if (CheckEmailField(txtEmail))
            {
                txtEmail.BackColor = default(Color);
            }
            else
            {
                txtEmail.BackColor = Color.PaleVioletRed;
            }

            if (CheckCboField(cboProofPurchase))
            {
                cboProofPurchase.BackColor = default(Color);
            }
            else
            {
                cboProofPurchase.BackColor = Color.PaleVioletRed;
            }

            //Checks for total fields validation and enables or disables save button
            if (FieldsValidation())
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }

            UpdateToolStripStatus();
        }

        private Boolean FieldsValidation()
        {
            //Checks for both correct input and unique input
            Boolean correctFlag = false;

            if (CheckFields() && CheckUnique())
            {
                correctFlag = true;
            }
            else
            {
                correctFlag = false;
            }

            return correctFlag;
        }

        #region Fields Leave Code
        private void TxtFirstName_Leave(object sender, EventArgs e)
        {
            CheckFields_ShowErrorColors();
        }

        private void TxtLastName_Leave(object sender, EventArgs e)
        {
            CheckFields_ShowErrorColors();
        }

        private void TxtAddrLine1_Leave(object sender, EventArgs e)
        {
            CheckFields_ShowErrorColors();
        }

        private void TxtCity_Leave(object sender, EventArgs e)
        {
            CheckFields_ShowErrorColors();
        }

        private void TxtState_Leave(object sender, EventArgs e)
        {
            CheckFields_ShowErrorColors();
        }

        private void TxtZipCode_Leave(object sender, EventArgs e)
        {
            CheckFields_ShowErrorColors();
        }

        private void CboGender_Leave(object sender, EventArgs e)
        {
            CheckFields_ShowErrorColors();
        }

        private void MasktxtPhoneNum_Leave(object sender, EventArgs e)
        {
            CheckFields_ShowErrorColors();
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            CheckFields_ShowErrorColors();
        }

        private void CboProofPurchase_Leave(object sender, EventArgs e)
        {
            CheckFields_ShowErrorColors();
        }
        #endregion

        #endregion


        private void ChangeCurrentMode(String mode)
        {
            BLL.BLLSingleton.Instance.currentMode = mode;
            toolStripStatusLabelCurrentMode.Text = "Current Mode: " + mode;

            //After changing modes it will check all the fields agian for the new mode
            CheckFields_ShowErrorColors();
        }

        private void BtnAddMode_Click(object sender, EventArgs e)
        {
            ChangeCurrentMode(Domain.CurrentMode.addMode);

            //Disable Delete Button
            btnDelete.Enabled = false;
        }


        #region Refresh Form Code
        public void ResetAllControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                    textBox.BackColor = default(Color);
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                    {
                        comboBox.SelectedIndex = -1;
                    }
                    comboBox.BackColor = default(Color);

                }

                if (control is MaskedTextBox)
                {
                    MaskedTextBox maskedTextBox = (MaskedTextBox)control;
                    maskedTextBox.Text = null;
                    maskedTextBox.BackColor = default(Color);
                }

                //Reset Date to current
                dateTimePickerDateReceived.Value = DateTime.Today;

                //Force Focus to First Field
                txtFirstName.Focus();
            }
        }

        private void RefreshListView()
        {
            //Clears ListView
            listViewRebateRecords.Items.Clear();

            //Check if RebateInfo is null
            if (BLL.BLLSingleton.Instance.GetRebateInfoList() == null || !BLL.BLLSingleton.Instance.GetRebateInfoList().Any())
            {
                listViewRebateRecords.Enabled = false;
                return;
            }
            else
            {
                listViewRebateRecords.Enabled = true;
            }

            //Populates Listview
            List<Domain.RebateInfo> rebateInfos = BLL.BLLSingleton.Instance.GetRebateInfoList().ToList();
            foreach (Domain.RebateInfo record in rebateInfos)
            {
                ListViewItem item = new ListViewItem(new[] { record.Fname, record.Lname, record.PhoneNum });
                item.Tag = record;

                listViewRebateRecords.Items.Add(item);
            }

            //Default selects the first listviewitem
            if (listViewRebateRecords.Items.Count > 0)
            {
                listViewRebateRecords.Items[0].Selected = true;
            }
        }

        private void ResetHiddenVariables()
        {
            mainform_TimeFirstEntered = Domain.CurrentMode.defaultHiddenVarTime;
            mainform_TimePressedSave = Domain.CurrentMode.defaultHiddenVarTime;
            mainform_NumPressedBackSpace = 0;
        }

        private void RefreshForm()
        {
            //Clears all data in fields
            ResetAllControls(this);

            //Refreshes the ListView
            RefreshListView();

            //Default Mode is AddMode
            ChangeCurrentMode(Domain.CurrentMode.addMode);

            //Disable Delete Button
            btnDelete.Enabled = false;

            //Resets hidden variables to defaults
            ResetHiddenVariables();

            //Clears all data in fields (Again to fix colors)
            ResetAllControls(this);

            //Update status to initial
            toolStripStatusLabelStatusMsg.Text = "Status: New Add";

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            //Refreshes the form to default
            RefreshForm();
        }
        #endregion


        #region Hidden Variable Functions
        private void TxtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            //Checks if first time keydown, then keeps datetime of when
            if (mainform_TimeFirstEntered.Equals(Domain.CurrentMode.defaultHiddenVarTime))
            {
                mainform_TimeFirstEntered = DateTime.Now.ToString();
            }
        }

        private void RebateAppMainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //On form settings: Set Key Preview to True First
            //char(8) is backspace

            if ((e.KeyChar == (char)8))
            {
                mainform_NumPressedBackSpace++;
            }
        }




        #endregion

        
    }
}

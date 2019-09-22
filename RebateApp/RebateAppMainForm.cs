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
        public RebateAppMainForm()
        {
            InitializeComponent();

            //Change ListView Settings
            listViewRebateRecords.View = View.Details;
            listViewRebateRecords.GridLines = true;

            listViewRebateRecords.Columns.Add("First Name");
            listViewRebateRecords.Columns.Add("Last Name");
            listViewRebateRecords.Columns.Add("Phone Number");

            listViewRebateRecords.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewRebateRecords.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void RebateAppMainForm_Load(object sender, EventArgs e)
        {
            RefreshListView();

            //Inital Tool Strip Status'
            ChangeCurrentMode(Domain.CurrentMode.addMode);

        }


        private void ChangeCurrentMode(String mode)
        {
            BLL.BLLSingleton.Instance.currentMode = mode;

            toolStripStatusLabelCurrentMode.Text = "Current Mode: " + mode;

            FieldsValidation();
        }

        private void RefreshListView()
        {
            //Clears Litview
            listViewRebateRecords.Items.Clear();
            
            //Check if RebateInfo is null
            if (BLL.BLLSingleton.Instance.GetRebateInfo() == null || !BLL.BLLSingleton.Instance.GetRebateInfo().Any())
            {
                //MessageBox.Show("Is Null");
                listViewRebateRecords.Enabled = false;
                return;
            }
            else
            {
                listViewRebateRecords.Enabled = true;
            }

            //Populates Listview
            List<Domain.RebateInfo> rebateInfos = BLL.BLLSingleton.Instance.GetRebateInfo().ToList();

            foreach (Domain.RebateInfo record in rebateInfos)
            {
                ListViewItem item = new ListViewItem(new[] { record.Fname, record.Lname, record.PhoneNum });
                item.Tag = record;

                listViewRebateRecords.Items.Add(item);
            }

            if (listViewRebateRecords.Items.Count > 0)
            {
                listViewRebateRecords.Items[0].Selected = true;
            }
        }


        private void ListViewRebateRecords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                ListViewRebateRecords_EditEvent();
            }
        }

        private void ListViewRebateRecords_Click(object sender, EventArgs e)
        {
            ListViewRebateRecords_EditEvent();
        }

        private void ListViewRebateRecords_EditEvent()
        {
            ChangeCurrentMode(Domain.CurrentMode.editMode);

            if (listViewRebateRecords.SelectedItems.Count == 0)
            {
                return;
            }

            Domain.RebateInfo rebateInfo = (Domain.RebateInfo)listViewRebateRecords.SelectedItems[0].Tag;

            //populate rebate record fields
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
            datetimepickerDateReceived.Value = DateTime.ParseExact(rebateInfo.DateRecieved, "M/dd/yyyy", CultureInfo.InvariantCulture);

            FieldsValidation();
        }

        private void ListViewRebateRecords_MouseUp(object sender, MouseEventArgs e)
        {//Keeps listview selected even when click into empty controller
            //works if no multiselect
            if (listViewRebateRecords.FocusedItem != null)
            {
                if (listViewRebateRecords.SelectedItems.Count == 0)
                    listViewRebateRecords.FocusedItem.Selected = true;
            }
        }



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

        private void CheckField_ShowErrorColorsANDStatus()
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

            UpdateToolStripStatus();
        }

        private Boolean FieldsValidation()
        {
            Boolean correctFlag = false;

            if (CheckFields() && CheckUnique())
            {
                correctFlag = true;
            }
            else
            {
                correctFlag = false;
            }

            CheckField_ShowErrorColorsANDStatus();

            return correctFlag;
        }


        #region Fields Leave Code
        private void TxtFirstName_Leave(object sender, EventArgs e)
        {
            CheckField_ShowErrorColorsANDStatus();
        }

        private void TxtLastName_Leave(object sender, EventArgs e)
        {
            CheckField_ShowErrorColorsANDStatus();
        }

        private void TxtAddrLine1_Leave(object sender, EventArgs e)
        {
            CheckField_ShowErrorColorsANDStatus();
        }

        private void TxtCity_Leave(object sender, EventArgs e)
        {
            CheckField_ShowErrorColorsANDStatus();
        }

        private void TxtState_Leave(object sender, EventArgs e)
        {
            CheckField_ShowErrorColorsANDStatus();
        }

        private void TxtZipCode_Leave(object sender, EventArgs e)
        {
            CheckField_ShowErrorColorsANDStatus();
        }

        private void CboGender_Leave(object sender, EventArgs e)
        {
            CheckField_ShowErrorColorsANDStatus();
        }

        private void MasktxtPhoneNum_Leave(object sender, EventArgs e)
        {
            CheckField_ShowErrorColorsANDStatus();
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            CheckField_ShowErrorColorsANDStatus();
        }

        private void CboProofPurchase_Leave(object sender, EventArgs e)
        {
            CheckField_ShowErrorColorsANDStatus();
        }
        #endregion


        private void BtnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show(FieldsValidation().ToString());

            if (FieldsValidation())
            {
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
                rebateInfo.DateRecieved = datetimepickerDateReceived.Value.ToString("M/dd/yyyy");

                //Different Modes
                if (BLL.BLLSingleton.Instance.currentMode.Equals(Domain.CurrentMode.addMode))
                {
                    AddMode_Save(rebateInfo);
                }
                else if (BLL.BLLSingleton.Instance.currentMode.Equals(Domain.CurrentMode.editMode))
                {
                    EditMode_Save(rebateInfo);
                }

                BLL.BLLSingleton.Instance.SaveRebateInfo(RebateInfoListViewToList(listViewRebateRecords));

                ResetAllControls(this);
                RefreshListView();

                //Inital Tool Strip Status'
                ChangeCurrentMode(Domain.CurrentMode.addMode);
            }


        }

        private void EditMode_Save(Domain.RebateInfo rebateInfo)
        {
            //Get ListViewItem
            ListViewItem selectedItem = listViewRebateRecords.SelectedItems[0];
            //Set NewValues
            selectedItem.SubItems[0].Text = rebateInfo.Fname;
            selectedItem.SubItems[1].Text = rebateInfo.Lname;
            selectedItem.SubItems[2].Text = rebateInfo.PhoneNum;
            selectedItem.Tag = rebateInfo;     
        }

        private void AddMode_Save(Domain.RebateInfo rebateInfo)
        {
            //Add ListViewItem
            ListViewItem item = new ListViewItem(new[] { rebateInfo.Fname, rebateInfo.Lname, rebateInfo.PhoneNum });
            item.Tag = rebateInfo;
            listViewRebateRecords.Items.Add(item);
        }

        private ICollection<Domain.RebateInfo> RebateInfoListViewToList(ListView listView)
        {
            List<Domain.RebateInfo> rebateInfos = new List<Domain.RebateInfo>();

            foreach(ListViewItem item in listView.Items)
            {
                Domain.RebateInfo tempRebateInfo = (Domain.RebateInfo)item.Tag;

                rebateInfos.Add(tempRebateInfo);
            }

            return rebateInfos;
        }

        private void BtnAddMode_Click(object sender, EventArgs e)
        {
            ChangeCurrentMode(Domain.CurrentMode.addMode);

            MessageBox.Show(BLL.BLLSingleton.Instance.currentMode);

            //Domain.RebateInfo rebateInfo = (Domain.RebateInfo)listViewRebateRecords.SelectedItems[0].Tag;

            //MessageBox.Show(rebateInfo.Fname);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ResetAllControls(this);

            FieldsValidation();
        }

        public void ResetAllControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = -1;
                }

                if (control is MaskedTextBox)
                {
                    MaskedTextBox maskedTextBox = (MaskedTextBox)control;
                    maskedTextBox.Text = null;
                }
                
                //Reset Date to current
                datetimepickerDateReceived.Value = DateTime.Now;

            }
        }


    }
}

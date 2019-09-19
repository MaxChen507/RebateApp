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
            //Check if RebateInfo is null
            if (DAL.DALSingleton.Instance.GetRebateInfo() == null || !DAL.DALSingleton.Instance.GetRebateInfo().Any())
            {
                //MessageBox.Show("Is Null");
                listViewRebateRecords.Enabled = false;
                return;
            }
            else
            {
                listViewRebateRecords.Enabled = true;
            }

            //Populate Listview

            List<Domain.RebateInfo> rebateInfos = DAL.DALSingleton.Instance.GetRebateInfo().ToList();

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
            if(listViewRebateRecords.SelectedItems.Count == 0)
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
        }

        //Keeps listview selected even when click into empty controller
        private void ListViewRebateRecords_MouseUp(object sender, MouseEventArgs e)
        {
            //works if no multiselect
            if (listViewRebateRecords.FocusedItem != null)
            {
                if (listViewRebateRecords.SelectedItems.Count == 0)
                    listViewRebateRecords.FocusedItem.Selected = true;
            }
        }

        private Boolean CheckFields()
        {
            Boolean fieldsFlag = false;
            Boolean uniqueFlag = false;

            return fieldsFlag;
        }

        private Boolean CheckTxtFieldNonEmpty(TextBox txtBox)
        {
            if (txtBox.TextLength > 0)
            {
                txtBox.BackColor = Color.White;
                return true;
            }
            else
            {
                txtBox.BackColor = Color.PaleVioletRed;
                return false;
            }
        }

        private Boolean CheckStateField(TextBox txtBox)
        {
            if(txtBox.TextLength == 2 && txtBox.Text.All(Char.IsLetter))
            {
                txtBox.BackColor = Color.White;
                return true;
            }
            else
            {
                txtBox.BackColor = Color.PaleVioletRed;
                return false;
            }
        }

        private Boolean CheckZipField(TextBox txtBox)
        {
            if( (txtBox.TextLength == 5 || txtBox.TextLength == 9) && txtBox.Text.All(Char.IsDigit) )
            {
                txtBox.BackColor = Color.White;
                return true;
            }
            else
            {
                txtBox.BackColor = Color.PaleVioletRed;
                return false;
            }
        }

        private Boolean CheckCboField(ComboBox cboBox)
        {
            if(cboBox.SelectedIndex > -1)
            {
                cboBox.BackColor = Color.White;
                return true;
            }
            else
            {
                cboBox.BackColor = Color.PaleVioletRed;
                return false;
            }
        }

        private Boolean CheckMaskTxtField(MaskedTextBox maskTxtBox)
        {
            if(maskTxtBox.MaskCompleted)
            {
                maskTxtBox.BackColor = Color.White;
                return true;
            }
            else
            {
                maskTxtBox.BackColor = Color.PaleVioletRed;
                return false;
            }
        }

        private Boolean CheckEmailField(TextBox txtBox)
        {
            if(txtBox.TextLength > 0 && txtBox.Text.Contains("@"))
            {
                txtBox.BackColor = Color.White;
                return true;
            }
            else
            {
                txtBox.BackColor = Color.PaleVioletRed;
                return false;
            }
        }

        private void FieldControl_Leave(object sender, EventArgs e)
        {
            
        }
    }
}

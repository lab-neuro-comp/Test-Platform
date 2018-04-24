using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

namespace TestPlatform.Views.ParticipantPages
{
    public partial class FormParticipantConfig : UserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public FormParticipantConfig()
        {
            InitializeComponent();
        }

        private void femaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.femaleRadioButton.Checked)
            {
                periodDateLabel.Visible = true;
                periodDatePicker.Visible = true;
            }
            else
            {
                periodDatePicker.Visible = false;
                periodDateLabel.Visible = false;
                periodDatePicker.CustomFormat = " ";
                periodDatePicker.Format = DateTimePickerFormat.Custom;
            }
        }

        private void periodDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if(periodDatePicker.ShowCheckBox == true)
            {
                if(periodDatePicker.Checked == false)
                {
                    periodDatePicker.CustomFormat = " ";
                    periodDatePicker.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    periodDatePicker.Format = DateTimePickerFormat.Short;
                }
            }
            else
            {
                periodDatePicker.Format = DateTimePickerFormat.Short;
            }
        }
        
        private bool validPeriodDate(DateTimePicker periodDatePicker, out string errorMessage)
        {
            bool returnValue;
            errorMessage = "";
            if (!periodDatePicker.Visible || periodDatePicker.Format != DateTimePickerFormat.Custom)
            {
                returnValue = true;
            }
            else
            {
                errorMessage = LocRM.GetString("invalidDate", currentCulture);
                returnValue = false;
            }

            return returnValue;
        }

        private void periodDatePicker_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!validPeriodDate((DateTimePicker)sender, out errorMsg))
            {
                e.Cancel = true;
            }
            this.errorProvider1.SetError((Control)sender, errorMsg);
        }

        private void periodDatePicker_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError((Control)sender, "");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {

            }
        }

        private void birthDatePicker_ValueChanged(object sender, EventArgs e)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDatePicker.Value.Year;
            if (birthDatePicker.Value < today.AddYears(-age)) age--;
            if (age > 0)
            {
                this.ageNumeric.Value = age;
            }
        }

        private void birthDatePicker_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(periodDatePicker, "");
        }

        private bool validBirthDate(DateTimePicker birthDatePicker, out string errorMessage)
        {
            bool returnValue;
            errorMessage = "";
            if (birthDatePicker.Value < DateTime.Today)
            {
                returnValue = true;
            }
            else
            {
                errorMessage = LocRM.GetString("invalidDate", currentCulture);
                returnValue = false;
            }

            return returnValue;
        }

        private void birthDatePicker_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!validBirthDate((DateTimePicker)sender, out errorMsg))
            {
                e.Cancel = true;
            }
            this.errorProvider1.SetError((Control)sender, errorMsg);
        }
    }
}

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
using TestPlatform.Models.General;
using System.IO;

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

        private Participant createParticipant()
        {
            int degreeOfSchool = 0;
            int sex = 0;
            if (this.femaleRadioButton.Checked)
            {
                sex = 1;
            }
            else
            {
                sex = 2;
            }
            foreach (Control c in schoolingPanel.Controls)
            {
                if (((RadioButton)c).Checked)
                {
                    switch (c.Name)
                    {
                        case "middleSchoolButton":
                            degreeOfSchool = 1;
                            break;
                        case "highSchoolradioButton":
                            degreeOfSchool = 2;
                            break;
                        case "higherEducationradioButton":
                            degreeOfSchool = 3;
                            break;
                        case "higher1radioButton":
                            degreeOfSchool = 4;
                            break;
                        case "postGraduate":
                            degreeOfSchool = 5;
                            break;
                    }
                }
            }
            return new Participant(
                participantNameTextBox.Text,
                int.Parse(registrationIDText.Text),
                sex,
                "", /*Missing location field on form*/
                degreeOfSchool,
                int.Parse(ageNumeric.Value.ToString()),
                birthDatePicker.Value,
                periodDatePicker.Value,
                -1, /*missing late in period field on form*/
                glassesYes.Checked,
                medicineYes.Checked,
                energizersYes.Checked,
                drugsYEs.Checked,
                relaxantYes.Checked,
                alcoholYes.Checked,
                sleepYes.Checked,
                glassesEspecification.Text,
                medicineEspecification.Text,
                relaxingEspecification.Text,
                sleepEspecification.Text,
                alcoholEspecification.Text,
                drugsEspecification.Text,
                energeticEspecification.Text,
                instructionsBox.Lines.ToList()
                );
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool hasToSave = true;
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                Participant participant = createParticipant();
                if (File.Exists(participant.getParticipantPath()))
                {
                    DialogResult dialogResult = MessageBox.Show(
                        LocRM.GetString("participantAlreadyExistsWishOverride", currentCulture), 
                        LocRM.GetString("error", currentCulture), MessageBoxButtons.YesNo);
                    if(dialogResult == DialogResult.No)
                    {
                        MessageBox.Show(LocRM.GetString("participantNotSaved", currentCulture));
                        hasToSave = false;
                    }
                }
                if (hasToSave && participant.saveParticipantFile())
                {
                    MessageBox.Show(LocRM.GetString("participantSaveSucessful"));
                }
            }
        }

        private void birthDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (birthDatePicker.ShowCheckBox == true)
            {
                if (birthDatePicker.Checked == false)
                {
                    birthDatePicker.CustomFormat = " ";
                    birthDatePicker.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    birthDatePicker.Format = DateTimePickerFormat.Short;
                }
            }
            else
            {
                birthDatePicker.Format = DateTimePickerFormat.Short;
            }
            var today = DateTime.Today;
            var age = today.Year - birthDatePicker.Value.Year;
            if (birthDatePicker.Value >= today.AddYears(-age)) age--;
            if (age > 0)
            {
                this.ageNumeric.Value = age;
            }
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

        private bool validSchoolingLevel(FlowLayoutPanel panel, out string errorMsg)
        {
            bool returnValue = false;
            errorMsg = "";
            foreach(Control child in panel.Controls)
            {
                if (((RadioButton)child).Checked)
                {
                    returnValue = true;
                }
            }
            if (!returnValue)
            {
                errorMsg = LocRM.GetString("invalidSchoolingLevel", currentCulture);
            }
            return returnValue;
        }

        private void schoolingPanel_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!validSchoolingLevel((FlowLayoutPanel)sender, out errorMsg))
            {
                e.Cancel = true;
            }
            this.errorProvider1.SetError((Control)sender, errorMsg);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private bool validSex(FlowLayoutPanel panel, out string errorMsg)
        {
            bool returnValue = false;
            errorMsg = "";
            foreach (Control child in panel.Controls)
            {
                if (((RadioButton)child).Checked)
                {
                    returnValue = true;
                }
            }
            if (!returnValue)
            {
                errorMsg = LocRM.GetString("invalidSex", currentCulture);
            }
            return returnValue;
        }

        private void Control_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError((Control)sender, "");
        }

        private void sexPanel_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!validSex((FlowLayoutPanel)sender, out errorMsg))
            {
                e.Cancel = true;
            }
            this.errorProvider1.SetError((Control)sender, errorMsg);
        }

        private bool validYesNoPanel(FlowLayoutPanel panel, out string errorMsg)
        {
            bool returnValue = false;
            errorMsg = "";
            foreach (Control child in panel.Controls)
            {
                if (((RadioButton)child).Checked)
                {
                    returnValue = true;
                }
            }
            if (!returnValue)
            {
                errorMsg = LocRM.GetString("invalidYesNoPanel", currentCulture);
            }
            return returnValue;
        }

        private void yesNoPanel_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!validYesNoPanel((FlowLayoutPanel)sender, out errorMsg))
            {
                e.Cancel = true;
            }
            this.errorProvider1.SetError((Control)sender, errorMsg);
        }

        private bool validName(string name, out string errorMsg)
        {
            bool returnValue;
            if(name.Length == 0)
            {
                errorMsg = LocRM.GetString("invalidName", currentCulture);
                returnValue = false;
            }
            else
            {
                errorMsg = "";
                returnValue = true;
            }

            return returnValue;
        }

        private void prgNameTextBox_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}

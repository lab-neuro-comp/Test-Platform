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
using TestPlatform.Models;

namespace TestPlatform.Views.ParticipantPages
{
    public partial class FormParticipantConfig : UserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public FormParticipantConfig(string participantToEdit)
        {
            InitializeComponent();
            if(participantToEdit != "false")
            {
                fillFieldsWithData(participantToEdit);
            }
        }

        private void fillFieldsWithData(string participant)
        {
            Participant participantToEdit = new Participant(participant);
            bool isFemale = false;
            if (participantToEdit.Sex == 1)
            {
                isFemale = true;
            }

            this.participantNameTextBox.Text = participantToEdit.Name;
            this.registrationIDText.Text = participantToEdit.RegistrationID.ToString();
            this.birthDatePicker.Value = participantToEdit.BirthDate;
            this.masculineRadioButton.Checked = !isFemale;
            this.femaleRadioButton.Checked = isFemale;
            this.periodDatePicker.Value = participantToEdit.LastPeriodDate;

            switch (participantToEdit.DegreeOfSchooling)
            {
                case 1:
                    middleSchoolButton.Checked = true;
                    break;
                case 2:
                    highSchoolradioButton.Checked = true;
                    break;
                case 3:
                    higherEducationradioButton.Checked = true;
                    break;
                case 4:
                    higher1radioButton.Checked = true;
                    break;
                case 5:
                    postGraduate.Checked = true;
                    break;
            }

            reasonForNotMenstruating.SelectedIndex = participantToEdit.ReasonForNotMenstruating;
            if(participantToEdit.ReasonForNotMenstruating >= 0)
            {
                setBooleanField(false, menstruatingYes, menstruatingNo);
                reasonForNotMenstruating.Visible = true;
                notMenstruatingLabel.Visible = true;
            }

            setBooleanField(participantToEdit.WearGlasses, glassesYes, glassesNo);
            setBooleanField(participantToEdit.UsesMedication, medicineYes, medicineNo);
            setBooleanField(participantToEdit.UsedRelaxant, relaxantYes, relaxantNo);
            setBooleanField(participantToEdit.GoodLastNightOfSleep, sleepYes, sleepNo);
            setBooleanField(participantToEdit.ConsumedAlcohol, alcoholYes, alcoholNo);
            setBooleanField(participantToEdit.ConsumedDrugs, drugsYes, drugsNo);
            setBooleanField(participantToEdit.ConsumedEnergizers, energizersYes, energizersNo);
            

            glassesEspecification.Text = participantToEdit.GlassesEspecification;
            medicineEspecification.Text = participantToEdit.MedicationEspecification;
            relaxingEspecification.Text = participantToEdit.RelaxantEspecification;
            sleepEspecification.Text = participantToEdit.SleepEspecification;
            alcoholEspecification.Text = participantToEdit.AlcoholEspecification;
            drugsEspecification.Text = participantToEdit.DrugsEspecification;
            energeticEspecification.Text = participantToEdit.EnergizersEspecification;
            LivingLocationTextBox.Text = participantToEdit.LivingLocation;


            /* only fills observations box if there are any within participant registration*/
            if (participantToEdit.Observations != null)
            {
                foreach (string line in participantToEdit.Observations)
                {
                    instructionsBox.Text += line + "\n";
                }
            }
            
        }

        private void setBooleanField(bool value, RadioButton yes, RadioButton no)
        {
            if (value)
            {
                yes.Checked = true;
            }
            else
            {
                no.Checked = true;
            }
        }

        private void femaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.femaleRadioButton.Checked)
            {
                femaleGroupBox.Enabled = true;
                femaleGroupBox.Visible = true;
            }
            else
            {
                femaleGroupBox.Enabled = false;
                femaleGroupBox.Visible = false;
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
            if (periodDatePicker.Visible && !validPeriodDate((DateTimePicker)sender, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError((Control)sender, errorMsg);
            }
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
                LivingLocationTextBox.Text, 
                degreeOfSchool,
                int.Parse(ageNumeric.Value.ToString()),
                birthDatePicker.Value,
                periodDatePicker.Value,
                reasonForNotMenstruating.SelectedIndex, 
                glassesYes.Checked,
                medicineYes.Checked,
                energizersYes.Checked,
                drugsYes.Checked,
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

        public bool save()
        {
            saveButton_Click(this, null);
            foreach (Control c in this.errorProvider1.ContainerControl.Controls)
            {
                if (errorProvider1.GetError(c) != "")
                {
                    return false;
                }
            }
            return true;
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
                    Global.GlobalFormMain.initializeParticipants();
                    this.Parent.Controls.Remove(this);
                }
            }
            else
            {
                MessageBox.Show(LocRM.GetString("notFilledProperlyMessage", currentCulture));
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
            if(validBirthDate(birthDatePicker, out string errorMsg))
            {
                this.errorProvider1.SetError(birthDatePicker, "");   
            }
            else
            {
                this.errorProvider1.SetError(birthDatePicker, errorMsg);
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
            if (!returnValue && panel.Visible)
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

        private void menstruatingYes_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.menstruatingYes.Checked)
            {
                reasonForNotMenstruating.Visible = true;
                notMenstruatingLabel.Visible = true;
            }
            else
            {
                reasonForNotMenstruating.Visible = false;
                notMenstruatingLabel.Visible = false;
                reasonForNotMenstruating.SelectedIndex = -1;
            }
        }

        private bool validReason(ComboBox reasonComboBox, out string errorMsg)
        {
            errorMsg = "";
            bool returnValue = true;
            if(this.menstruatingNo.Checked && reasonComboBox.SelectedIndex == -1)
            {
                errorMsg = LocRM.GetString("shouldSelectReason", currentCulture);
                returnValue = false;
            }
            return returnValue;
        }

        private void reasonForNotMenstruating_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!validReason((ComboBox)sender, out errorMsg))
            {
                e.Cancel = true;
            }
            this.errorProvider1.SetError((Control)sender, errorMsg);
        }


        private bool validLivingLocation(TextBox LivingLocation, out string errorMsg)
        {
            errorMsg = "";
            bool returnValue = true;
            if (!Validations.isAlphanumeric(LivingLocation.Text))
            {
                errorMsg = LocRM.GetString("participantNameAlphanumericError", currentCulture);
                returnValue = false;
            }
            return returnValue;
        }

        private void LivingLocationTextBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!validLivingLocation((TextBox)sender, out errorMsg))
            {
                e.Cancel = true;
            }
            this.errorProvider1.SetError((Control)sender, errorMsg);

        }
    }
}

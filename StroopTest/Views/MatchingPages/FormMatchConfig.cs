﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using TestPlatform.Models;

namespace TestPlatform.Views.MatchingPages
{
    public partial class FormMatchConfig : UserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public FormMatchConfig(bool isEditing)
        {
            InitializeComponent();
        }

        public bool save()
        {
            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("MatchConfigInstructions", currentCulture));
            try { infoBox.Show(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void programName_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(programName, "");
        }

        public bool ValidProgramName(string pgrName, out string errorMessage)
        {
            if (pgrName.Length == 0)
            {
                errorMessage = LocRM.GetString("programNotFilled", currentCulture);
                return false;
            }
            if (!Validations.isAlphanumeric(pgrName))
            {
                errorMessage = LocRM.GetString("programNotAlphanumeric", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void programName_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidProgramName(programName.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(programName, errorMsg);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {

            }
            else
            {
                MessageBox.Show(LocRM.GetString("fieldNotRight", currentCulture));
            }
        }

        private void expositionType_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!validExpositionType(out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(expositionType, errorMsg);
            }
        }

        private bool validExpositionType(out string errorMessage)
        {
            if(this.expositionType.SelectedIndex >= 0 && this.expositionType.SelectedIndex < 1)
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = LocRM.GetString("expoTypeError", currentCulture);
                return false;
            }
        }

        private void expositionType_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(expositionType, "");
        }

        private void expositionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.expositionType.SelectedIndex > 0)
            {
                this.errorProvider1.SetError(this.expositionType, LocRM.GetString("unavailableExpo", currentCulture));
            }
            else
            {
                this.errorProvider1.SetError(this.expositionType, "");
            }
        }

        private void ExpoDisposition_Validating(object sender, CancelEventArgs e)
        {
            if(this.ExpoDisposition.SelectedIndex == -1)
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.ExpoDisposition, LocRM.GetString("dispositionError", currentCulture));
            }
        }

        private void ExpoDisposition_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.ExpoDisposition, "");
        }
    }
}

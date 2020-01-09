using System;
using System.Windows.Forms;
using TestPlatform.Models;
using TestPlatform.Views.ReactionPages;
using TestPlatform.Views.ExperimentPages;
using TestPlatform.Views.MatchingPages;
using TestPlatform.Views.SpacialRecognitionPages;

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class ResultsUserControl : DefaultUserControl
    {

        public ResultsUserControl()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public void showStroopResults()
        {
            StroopButton_Click(null, null);
        }

        private void StroopButton_Click(object sender, EventArgs e)
        {
            if(FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0) //if another result tab is open then close it
            {
                FileManipulation.GlobalFormMain._contentPanel.Controls.Clear(); 
            }
            FormShowData showData;
            try
            {
                showData = new FormShowData();
                FileManipulation.GlobalFormMain._contentPanel.Controls.Add(showData);
                StroopButton.Checked = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void showReactionResults()
        {
            reactionButton_Click(null, null);
        }
        private void reactionButton_Click(object sender, EventArgs e)
        {
            if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0) //if another result tab is open then close it
            {
                FileManipulation.GlobalFormMain._contentPanel.Controls.Clear();
            }
            ReactionResultUserControl showData;
            try
            {
                showData = new ReactionResultUserControl();
                FileManipulation.GlobalFormMain._contentPanel.Controls.Add(showData);
                reactionButton.Checked = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void showExperimentResults()
        {
            experimentButton_Click(null, null);
        }
        private void experimentButton_Click(object sender, EventArgs e)
        {
            if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0) //if another result tab is open then close it
            {
                FileManipulation.GlobalFormMain._contentPanel.Controls.Clear();
            }
            try
            {
                ExperimentResultUserControl showData = new ExperimentResultUserControl();
                FileManipulation.GlobalFormMain._contentPanel.Controls.Add(showData);
                experimentButton.Checked = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void showMatchingResults()
        {
            matchingButton_Click(null, null);
        }
        private void matchingButton_Click(object sender, EventArgs e)
        {
            if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0) //if another result tab is open then close it
            {
                FileManipulation.GlobalFormMain._contentPanel.Controls.Clear();
            }
            try
            {
                MatchingResultUserControl showData = new MatchingResultUserControl();
                FileManipulation.GlobalFormMain._contentPanel.Controls.Add(showData);
                matchingButton.Checked = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void showSpacialRecoginitionResults()
        {
            SRResultButton_Click(null, null);
        }
        private void SRResultButton_Click(object sender, EventArgs e)
        {
            if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0) //if another result tab is open then close it
            {
                FileManipulation.GlobalFormMain._contentPanel.Controls.Clear();
            }
            try
            {
                SRResultUserControl showData = new SRResultUserControl();
                FileManipulation.GlobalFormMain._contentPanel.Controls.Add(showData);
                SRResultButton.Checked = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

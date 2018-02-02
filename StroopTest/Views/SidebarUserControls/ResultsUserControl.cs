using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Views;
using TestPlatform;
using TestPlatform.Views.ReactionPages;
using TestPlatform.Views.ExperimentPages;
using TestPlatform.Views.MatchingPages;

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class ResultsUserControl : DefaultUserControl
    {

        public ResultsUserControl()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void StroopButton_Click(object sender, EventArgs e)
        {
            if(Global.GlobalFormMain._contentPanel.Controls.Count > 0) //if another result tab is open then close it
            {
                Global.GlobalFormMain._contentPanel.Controls.Clear(); 
            }
            FormShowData showData;
            try
            {
                showData = new FormShowData();
                Global.GlobalFormMain._contentPanel.Controls.Add(showData);
                StroopButton.Checked = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void reactionButton_Click(object sender, EventArgs e)
        {
            if (Global.GlobalFormMain._contentPanel.Controls.Count > 0) //if another result tab is open then close it
            {
                Global.GlobalFormMain._contentPanel.Controls.Clear();
            }
            ReactionResultUserControl showData;
            try
            {
                showData = new ReactionResultUserControl();
                Global.GlobalFormMain._contentPanel.Controls.Add(showData);
                reactionButton.Checked = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void experimentButton_Click(object sender, EventArgs e)
        {
            if (Global.GlobalFormMain._contentPanel.Controls.Count > 0) //if another result tab is open then close it
            {
                Global.GlobalFormMain._contentPanel.Controls.Clear();
            }
            try
            {
                ExperimentResultUserControl showData = new ExperimentResultUserControl();
                Global.GlobalFormMain._contentPanel.Controls.Add(showData);
                experimentButton.Checked = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void matchingButton_Click(object sender, EventArgs e)
        {
            if (Global.GlobalFormMain._contentPanel.Controls.Count > 0) //if another result tab is open then close it
            {
                Global.GlobalFormMain._contentPanel.Controls.Clear();
            }
            try
            {
                MatchingResultUserControl showData = new MatchingResultUserControl();
                Global.GlobalFormMain._contentPanel.Controls.Add(showData);
                matchingButton.Checked = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

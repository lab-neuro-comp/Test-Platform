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
            ReactionResultUserControl showData;
            try
            {
                showData = new ReactionResultUserControl();
                Global.GlobalFormMain._contentPanel.Controls.Add(showData);
                reactionButton.Checked = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

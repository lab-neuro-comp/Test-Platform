using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPlatform.Views
{
    public partial class DefaultUserControl : UserControl
    {
        public DefaultUserControl()
        {
            BackColor = Color.White;
            Size = new Size(260, 548);
            TabIndex = 24;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {

            Location = new Point(190, 60);
            this.BringToFront();
            base.OnLoad(e);
        }


        private void DefaultUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}

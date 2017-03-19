using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StroopTest.Views
{
    public partial class DefaultUserControl : UserControl
    {
        public DefaultUserControl()
        {
            BackColor = Color.LightGray;
            Location = new Point(153, 58);
            Size = new Size(260, 548);
            TabIndex = 24;
            InitializeComponent();
        }

        private void DefaultUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}

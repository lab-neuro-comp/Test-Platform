using System;
using System.Drawing;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormWordColorDialog : Form
    {
        public string ReturnValue { get; set; }

        public FormWordColorDialog()
        {
            InitializeComponent();
        }

        private void hexColorTextBox_Click(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            hexColorTextBox.ForeColor = ColorTranslator.FromHtml(colorCode);
            hexColorTextBox.Text = colorCode;
        }

        private string pickColor()
        {
            ColorDialog MyDialog = new ColorDialog();
            Color colorPicked = new Color();
            MyDialog.CustomColors = new int[] {
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#F8E000")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#007BB7")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#7EC845")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#D01C1F"))
                                      };
            colorPicked = this.BackColor;
            string hexColor = "#000000";
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                colorPicked = MyDialog.Color;
                hexColor = "#" + colorPicked.R.ToString("X2") + colorPicked.G.ToString("X2") + colorPicked.B.ToString("X2");
            }
            return hexColor;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.ReturnValue = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(wordTextBox.Text))
                {
                    throw new Exception("Campo palavra deve ser preenchido!");
                }
                this.ReturnValue = wordTextBox.Text + " " + hexColorTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

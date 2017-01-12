using System;
using System.Drawing;
using System.Windows.Forms;
using StroopTest.Models;

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
            if (colorCode != null)
            {
                hexColorTextBox.ForeColor = ColorTranslator.FromHtml(colorCode);
                hexColorTextBox.Text = colorCode;
            }
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
            string hexColor = null;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                colorPicked = MyDialog.Color;
                hexColor = "#" + colorPicked.R.ToString("X2") + colorPicked.G.ToString("X2") + colorPicked.B.ToString("X2");
            }
            return hexColor;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(wordTextBox.Text))
                {
                    throw new Exception("Preencha os campos!");
                }

                ReturnValue = wordTextBox.Text + " " + hexColorTextBox.Text;
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void hexColorTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var box = (TextBox)sender;
                if (box.Text.Length <= 1)
                {
                    box.Text = "#";
                    box.SelectionStart = 1;
                }

                if (Validations.isColorLengthValid(box.Text.Length) && !Validations.isHexPattern(box.Text))
                {
                    throw new Exception("O código de cor deve estar em formato hexadecimal.\nEx: #000000");
                }


                if (Validations.isHexPattern(hexColorTextBox.Text) && Validations.isColorLengthValid(hexColorTextBox.TextLength))
                {
                    hexColorTextBox.ForeColor = ColorTranslator.FromHtml(hexColorTextBox.Text);
                }
                else
                {
                    hexColorTextBox.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

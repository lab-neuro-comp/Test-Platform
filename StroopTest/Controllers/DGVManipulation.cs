namespace TestPlatform.Controllers
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>  
    ///  This class performs different kinds of manipulations on data grid views that are necessary to application  
    /// </summary>
    public class DGVManipulation
    {
        internal static void MoveDGVRowUp(DataGridView dgv)
        {
            int totalRows = dgv.Rows.Count;

            // get index of the row for the selected cell
            int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
            if (rowIndex == 0)
            {
                return;
            }
                
            // get index of the column for the selected cell
            int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
            DataGridViewRow selectedRow = dgv.Rows[rowIndex];
            dgv.Rows.Remove(selectedRow);
            dgv.Rows.Insert(rowIndex - 1, selectedRow);
            dgv.ClearSelection();
            dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
        }

        internal static void MoveDGVRowDown(DataGridView dgv)
        {
            int totalRows = dgv.Rows.Count;

            // get index of the row for the selected cell
            int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
            if (rowIndex == totalRows - 1)
            {
                return;
            }
               
            // get index of the column for the selected cell
            int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
            DataGridViewRow selectedRow = dgv.Rows[rowIndex];
            dgv.Rows.Remove(selectedRow);
            dgv.Rows.Insert(rowIndex + 1, selectedRow);
            dgv.ClearSelection();
            dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
        }

        internal static void DeleteDGVRow(DataGridView dgv)
        {
            if (dgv.RowCount > 1)
            {
                foreach (DataGridViewRow item in dgv.SelectedRows)
                {
                    dgv.Rows.RemoveAt(item.Index);
                }
            }
            else
            {
                dgv.Rows.Clear();
                dgv.Refresh();
            }
        }

        internal static void SaveColumnToListFile(DataGridView dgv, int column, string path, string filename)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            try
            {
                saveFileDialog1.Filter = "List (.lst)|*.lst"; // salva em .lst
                saveFileDialog1.RestoreDirectory = true;
                
                if (File.Exists(path + filename + ".lst"))
                {
                    DialogResult dr = MessageBox.Show("Uma lista com este nome já existe.\nDeseja sobrescrevê-la?", string.Empty, MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.Cancel)
                    {
                        throw new Exception("A lista não será salva!");
                    }
                }

                StreamWriter w1 = new StreamWriter(path + filename + ".lst");
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    w1.WriteLine(dgv.Rows[i].Cells[column].Value.ToString());
                }

                w1.Close();
                MessageBox.Show("A lista " + filename + ".lst foi salva com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void ReadStringListIntoDGV(string[] fileNames, DataGridView dataGridView)
        {
            try
            {
                foreach (string file in fileNames)
                {
                    dataGridView.Rows.Add(Path.GetFileNameWithoutExtension(file), Path.GetFullPath(file));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void CloseFormListNotEmpty(DataGridView dgv)
        {
            if (dgv.RowCount != 0)
            {
                throw new Exception("A lista não será salva!");
            }
        }
    }
}

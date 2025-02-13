using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using ExcelDataReader;
using System.IO;

namespace Importador
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {

            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivos de Excel|*.xlsx|Archivos de Excel 97-2003|*.xls" })
                {
                    if(ofd.ShowDialog() == DialogResult.OK)
                    {
                        using(var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                var dataset = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                    {
                                        UseHeaderRow = true
                                    }
                                });

                                dataGridView1.DataSource = dataset.Tables[0];
                            }
                        }

                        dataGridView1.Columns[0].HeaderText = "Calle";
                        dataGridView1.Columns[1].HeaderText = "Num";
                        dataGridView1.Columns[2].HeaderText = "Colonia";
                        dataGridView1.Columns[3].HeaderText = "Delegacion";


                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft sans serif", 11);

                    }
                }

                


            }


        }
    }
}

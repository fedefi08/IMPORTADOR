using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Importador
{
    public partial class FormTransporte : Form
    {
        public FormTransporte()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivos de Excel|*.xlsx|Archivos de Excel 97-2003|*.xls" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
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

                        dataGridView1.Columns[0].HeaderText = "idtransporte";
                        dataGridView1.Columns[1].HeaderText = "Nombre";
                        dataGridView1.Columns[2].HeaderText = "Domicilio";
                        dataGridView1.Columns[3].HeaderText = "Localidad";
                        dataGridView1.Columns[4].HeaderText = "Cpostal";
                        dataGridView1.Columns[2].HeaderText = "Telefono";
                        dataGridView1.Columns[3].HeaderText = "Cuit";
                        dataGridView1.Columns[1].HeaderText = "Destinos";
                        dataGridView1.Columns[2].HeaderText = "idprovincia";
                        dataGridView1.Columns[3].HeaderText = "patente";


                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft sans serif", 11);

                    }
                }
            }
        }
        private void btncargardatos_Click(object sender, EventArgs e)
        {
            SqlConnection con = ConexcionBD.DbConnection.getDBConnection();
            var importarTransportes = new ImportarTransportes(Convert.ToString(con));
            ImportarTransportes impTransportes = new ImportarTransportes(Convert.ToString(con));
            ImportarTransportes nuevoTransporte = new ImportarTransportes(Convert.ToString(con));
            impTransportes.Add(nuevoTransporte);
        }
    }
}


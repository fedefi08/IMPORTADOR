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
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Archivos de Excel 97-2003 (*.xls)|*.xls|Archivos CSV (*.csv)|*.csv" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtBox.Text = ofd.FileName;

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
            //SqlConnection con = ConexcionBD.DbConnection.getDBConnection();
            //var importarTransportes = new ImportarTransportes(Convert.ToString(con));
            //ImportarTransportes impTransportes = new ImportarTransportes(Convert.ToString(con));
            //ImportarTransportes nuevoTransporte = new ImportarTransportes(Convert.ToString(con));
            //impTransportes.Add(nuevoTransporte);


            //Me conecto a la base
            using (SqlConnection con = ConexcionBD.DbConnection.getDBConnection())
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow) // Evitar la fila vacía al final
                    {
                        // Obtener los valores de las columnas
                        string idtransporte = row.Cells[0].Value?.ToString() ?? "";
                        string nombre = row.Cells[1].Value?.ToString() ?? "";
                        string domicilio = row.Cells[2].Value?.ToString() ?? "";
                        string localidad = row.Cells[3].Value?.ToString() ?? "";
                        string cpostal = row.Cells[4].Value?.ToString() ?? "";
                        string telefono = row.Cells[5].Value?.ToString() ?? "";
                        string cuit = row.Cells[6].Value?.ToString() ?? "";
                        string destinos = row.Cells[7].Value?.ToString() ?? "";
                        string idprovincia = row.Cells[8].Value?.ToString() ?? "";
                        string patente = row.Cells[9].Value?.ToString() ?? "";

                        
                        string query = "INSERT INTO Transportes (idtransporte, Nombre, Domicilio, Localidad, Cpostal, Telefono, Cuit, Destinos, idprovincia, Patente) " +
                                       "VALUES (@idtransporte, @Nombre, @Domicilio, @Localidad, @Cpostal, @Telefono, @Cuit, @Destinos, @idprovincia, @Patente)";
                       
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@idtransporte", idtransporte);
                                cmd.Parameters.AddWithValue("@Nombre", nombre);
                                cmd.Parameters.AddWithValue("@Domicilio", domicilio);
                                cmd.Parameters.AddWithValue("@Localidad", localidad);
                                cmd.Parameters.AddWithValue("@Cpostal", cpostal);
                                cmd.Parameters.AddWithValue("@Telefono", telefono);
                                cmd.Parameters.AddWithValue("@Cuit", cuit);
                                cmd.Parameters.AddWithValue("@Destinos", destinos);
                                cmd.Parameters.AddWithValue("@idprovincia", idprovincia);
                                cmd.Parameters.AddWithValue("@Patente", patente);
                                cmd.ExecuteNonQuery(); // Ejecutar la consulta
                            }

                       
                    }
                }


                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                MessageBox.Show("Datos importados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Descargar ejemplo transporte me quedo como button2 ESTA MAL EL NOMBRE
        {
            
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
                saveFileDialog.Title = "Descargar ejemplo CSV";
                saveFileDialog.FileName = "TransportesEjemplo.csv"; // Nombre predeterminado

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string destino = saveFileDialog.FileName;

                    // Ruta del archivo CSV de ejemplo (debe estar en la carpeta de salida del proyecto)
                    string origen = Path.Combine(Application.StartupPath, "TransportesEjemplo.csv");

                    if (File.Exists(origen))
                    {
                        File.Copy(origen, destino, true);
                        MessageBox.Show("Archivo de ejemplo descargado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el archivo de ejemplo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            

        }

        private void FormTransporte_Load(object sender, EventArgs e)
        {

        }
    }
}


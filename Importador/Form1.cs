using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Importador
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            FormClientes frmclientes = new FormClientes();

            frmclientes.Show();
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            FormTransporte frmTransporte = new FormTransporte();
            frmTransporte.Show();

        }
    }
}

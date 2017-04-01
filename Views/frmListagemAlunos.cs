using Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class frmListagemAlunos : Form
    {
        public frmListagemAlunos()
        {
            InitializeComponent();
        }

        private void frmListagemClientes_Load(object sender, EventArgs e)
        {
            CarregarGridViewClientes();
        }

        private void CarregarGridViewClientes()
        {
            dgvClientes.DataSource = null;
            AlunosController alunoController = new AlunosController();
            dgvClientes.DataSource = alunoController.Listar();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            

        }

        private void lblListaAlunos_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;

namespace Views
{
    public partial class frmListagemCursos : Form
    {
        public frmListagemCursos()
        {
            InitializeComponent();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmListagemCursos_Load(object sender, EventArgs e)
        {
            CarregarGridViewCursos();
        }

        private void CarregarGridViewCursos()
        {
            dgvCursos.DataSource = null;
            CursosController cursoController = new CursosController();
            dgvCursos.DataSource = cursoController.Listar();
        }

        private void dgvCursos_SelectionChanged(object sender, EventArgs e)
        {
          

        }

    }
}

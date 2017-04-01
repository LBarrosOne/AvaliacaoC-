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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            lblDataAtual.Text = DateTime.Now.ToString();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroAluno cadCliente = new frmCadastroAluno(null);
            cadCliente.MdiParent = this;
            cadCliente.Show();
        }

        private void listagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListagemAlunos listagem = new frmListagemAlunos();
            listagem.MdiParent = this;
            listagem.Show();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void carroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCadastroCurso cadCurso = new frmCadastroCurso(null);
            cadCurso.MdiParent = this;
            cadCurso.Show();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListagemCursos listagem = new frmListagemCursos();
            listagem.MdiParent = this;
            listagem.Show();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExcluirAlunos exAluno = new frmExcluirAlunos();
            exAluno.MdiParent = this;
            exAluno.Show();
        }

        private void excluirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmExcluirCursos exAluno = new frmExcluirCursos();
            exAluno.MdiParent = this;
            exAluno.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditarCursos edCurso = new frmEditarCursos(null);
            edCurso.MdiParent = this;
            edCurso.Show();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEditarAlunos edAluno = new frmEditarAlunos(null);
            edAluno.MdiParent = this;
            edAluno.Show();
        }
    }
}

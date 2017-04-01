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
using Models;

namespace Views
{
    public partial class frmEditarAlunos : Form
    {

        public int? AlunoID { get; set; }
        public Aluno _Aluno { get; set; }

        public frmEditarAlunos(int? idAluno)
        {
            InitializeComponent();

            if (idAluno.HasValue)
                AlunoID = idAluno;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void editar()
        {
            string mensagem = "";
            try
            {
                if (Validar())
                {
                    AlunosController alunoController = new AlunosController();
                    mensagem = alunoController.Editar(Int32.Parse(txtId.Text), txtNome.Text, txtCpf.Text);
                    MessageBox.Show(mensagem);
                    LimparCampos();


                }
                else
                {
                    MessageBox.Show("Todos campos são obrigatórios");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO");
            }
        }

        private bool Validar()
        {
            return !(string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtCpf.Text)
                || string.IsNullOrEmpty(txtNome.Text));
        }

        public void LimparCampos()
        {
            AlunoID = null;
            _Aluno = null;
            txtId.Clear();
            txtNome.Clear();
            txtCpf.Clear();            
        }
    }
}

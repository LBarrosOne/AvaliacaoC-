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
    public partial class frmEditarCursos : Form
    {
        public int? CursoID { get; set; }
        public Curso _Curso { get; set; }

        public frmEditarCursos(int? idCurso)
        {
            InitializeComponent();

            if (idCurso.HasValue)
                CursoID = idCurso;
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
                    CursosController cursoController = new CursosController();
                    mensagem = cursoController.Editar(Int32.Parse(txtId.Text), txtCodigo.Text, txtDescricao.Text, txtNome.Text);
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
            return !(string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtCodigo.Text)
                || string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtDescricao.Text)); 
        }

        public void LimparCampos()
        {
            CursoID = null;
            _Curso = null;
            txtId.Clear();
            txtCodigo.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
        }

    }
}

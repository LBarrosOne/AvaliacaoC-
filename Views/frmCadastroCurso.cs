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
    public partial class frmCadastroCurso : Form
    {
        public int? CursoID { get; set; }
        public Curso _Curso { get; set; }

        public frmCadastroCurso(int? idCurso)
        {
            InitializeComponent();

            if (idCurso.HasValue)
                CursoID = idCurso;
        }

        private void frmCadastroCurso_Load(object sender, EventArgs e)
        {
            CarregarFormulario();
        }

        private void CarregarFormulario()
        {
            if (CursoID.HasValue)
            {
                CursosController cursosController = new CursosController();
                _Curso = cursosController.Detalhes(CursoID.Value);

                if (_Curso != null)
                {
                    txtCodigo.Text = _Curso.Codigo;
                    txtNome.Text = _Curso.Nome;
                    txtDescricao.Text = _Curso.Descricao;
                    btnSalvar.Text = "Atualizar";
                }
            }
            else
                LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Salvar()
        {
            try
            {
                if (Validar())
                {
                    if (CursoID.HasValue)
                    {
                        CursosController cursoController = new CursosController();
                        cursoController.Editar(CursoID.Value, txtCodigo.Text, txtDescricao.Text, txtNome.Text);

                        MessageBox.Show("Curso alterado com sucesso");
                        LimparCampos();
                        this.Close();
                    }
                    else
                    {
                        CursosController cursoController = new CursosController();
                        cursoController.Adicionar(txtCodigo.Text, txtDescricao.Text, txtNome.Text);

                        MessageBox.Show("Curso cadastrado com sucesso");
                        LimparCampos();
                    }
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
            return !(string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtNome.Text));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LimparCampos()
        {
            CursoID = null;
            _Curso = null;
            txtCodigo.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            btnSalvar.Text = "Salvar";
        }
    }
}

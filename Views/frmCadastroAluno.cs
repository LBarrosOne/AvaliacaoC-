using System;
using System.Windows.Forms;
using Controllers;
using Models;

namespace Views
{
    public partial class frmCadastroAluno : Form
    {
        public int? AlunoID { get; set; }
        public Aluno _Aluno { get; set; }

        public frmCadastroAluno(int? idAluno)
        {
            InitializeComponent();

            if (idAluno.HasValue)
                AlunoID = idAluno;
        }

        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {
            CarregarFormulario();

        }

        private void CarregarFormulario()
        {
            if (AlunoID.HasValue)
            {
                AlunosController cliController = new AlunosController();
                _Aluno = cliController.Detalhes(AlunoID.Value);

                if (_Aluno != null)
                {
                    txtNome.Text = _Aluno.Nome;
                    txtCpf.Text = _Aluno.Cpf;
                    btnSalvar.Text = "Atualizar";
                }
            }
            else
                LimparCampos();
        }

        public void LimparCampos()
        {
            AlunoID = null;
            _Aluno = null;
            txtNome.Clear();
            txtCpf.Clear();
            btnSalvar.Text = "Salvar";
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    if (AlunoID.HasValue)
                    {
                        AlunosController cliController = new AlunosController();
                        cliController.Editar(AlunoID.Value, txtNome.Text, txtCpf.Text);

                        MessageBox.Show("Aluno alterado com sucesso");
                        LimparCampos();
                        this.Close();
                    }
                    else
                    {
                        AlunosController cliController = new AlunosController();
                        cliController.Adicionar(txtNome.Text, txtCpf.Text);

                        MessageBox.Show("Aluno cadastrado com sucesso");
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
            return !(string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtCpf.Text));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

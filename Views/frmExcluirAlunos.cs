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
    public partial class frmExcluirAlunos : Form
    {
        public frmExcluirAlunos()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                if (Validar())
                {
                    AlunosController alunoController = new AlunosController();
                    i = alunoController.Excluir(Int32.Parse(txtCodigo.Text));
                    if(i == 1)
                    {
                        MessageBox.Show("Aluno excluído com sucesso.");
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Aluno não encontrado.");
                        LimparCampos();
                    }
                  
                    

                }
                else
                {
                    MessageBox.Show("O campo 'Código' é obrigatório");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO");
            }
        }

        private bool Validar()
        {
            return !(string.IsNullOrEmpty(txtCodigo.Text));
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }
    }
}

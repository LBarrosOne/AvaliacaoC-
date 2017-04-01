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
    public partial class frmExcluirCursos : Form
    {
        public frmExcluirCursos()
        {
            InitializeComponent();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                if (Validar())
                {
                    CursosController cursoController = new CursosController();
                    i = cursoController.Excluir(Int32.Parse(txtId.Text));
                    if (i == 1)
                    {
                        MessageBox.Show("Curso excluído com sucesso.");
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Curso não encontrado.");
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show("O campo 'ID' é obrigatório");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validar()
        {
            return !(string.IsNullOrEmpty(txtId.Text));
        }

        private void LimparCampos()
        {
            txtId.Text = "";
        }
    }
}

using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class AlunosController
    {
        private static List<Aluno> listaAlunos = new List<Aluno>();

        public void Adicionar(string nome, string cpf)
        {
            Aluno aluno = new Aluno();
            aluno.AlunoID = listaAlunos.Count + 1;
            aluno.Nome = nome;
            aluno.Cpf = cpf;

            listaAlunos.Add(aluno);
        }

        private Aluno BuscarPorID(int id)
        {
            foreach (Aluno aluno in listaAlunos)
            {
                if (aluno.AlunoID == id)
                {
                    return aluno;
                }
            }
            return null;
        }

        public Aluno Detalhes(int id)
        {
            return BuscarPorID(id);
        }

        public string Editar(int id, string novoNome, string novoCpf)
        {
            Aluno a = BuscarPorID(id);

            if(a != null)
            {
                a.Nome = novoNome;
                a.Cpf = novoCpf;

                return "Aluno editado com sucesso";
            }
            else
            {
                return "Aluno não encontrado";
            }
        }

        public int Excluir(int id)
        {
            int i = 0;
            foreach (Aluno aluno in listaAlunos)
            {
                if (aluno.AlunoID == id)
                {
                    i = 1;
                    listaAlunos.Remove(aluno);
                    break;
                }
            }
            return i;
        }

        public List<Aluno> Listar()
        {
            return listaAlunos;
        }
    }
}

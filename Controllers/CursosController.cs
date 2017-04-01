using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class CursosController
    {
        private static List<Curso> listaCursos = new List<Curso>();

        public void Adicionar(string codigo, string descricao, string nome)
        {
            Curso curso = new Curso();
            curso.CursoID = listaCursos.Count + 1;
            curso.Codigo = codigo;
            curso.Descricao = descricao;
            curso.Nome = nome;

            listaCursos.Add(curso);
        }

        private Curso BuscarPorID(int id)
        {
            foreach (Curso curso in listaCursos)
            {
                if (curso.CursoID == id)
                {
                    return curso;
                }
            }
            return null;
        }

        public Curso Detalhes(int id)
        {
            return BuscarPorID(id);
        }

        public string Editar(int id, string novoCodigo, string novoDescricao, string novoNome)
        {
            Curso c = BuscarPorID(id);

            if(c != null)
            {
                c.Codigo = novoCodigo;
                c.Descricao = novoDescricao;
                c.Nome = novoNome;

                return "Curso editado com sucesso";
            }
            else
            {
                return "Curso não encontrado";
            }
        }

        public List<Curso> Listar()
        {
            return listaCursos;
        }

        public int Excluir(int id)
        {
            int i = 0;
            foreach (Curso curso in listaCursos)
            {
                if (curso.CursoID == id)
                {
                    i = 1;
                    listaCursos.Remove(curso);
                    break;
                }
            }
            return i;
        }
    }
}

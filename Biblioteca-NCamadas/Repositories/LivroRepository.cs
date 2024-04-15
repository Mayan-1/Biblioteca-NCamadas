using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    internal class LivrosRepository
    {

        public Dictionary<int, Livro> livros { get; set; }


        public LivrosRepository()
        {
            livros = new Dictionary<int, Livro>();
        }

        public void CadastrarLivro(Livro livro)
        {
            try
            {
                livros.Add(livro.Key, livro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Dictionary<int, Livro> ExcluirLivro(int key)
        {
            if (livros.ContainsKey(key))
            {
                try
                {
                    livros.Remove(key);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadKey();
            return livros;
        }

        public void VerTodosOsLivros()
        {
            foreach (var livro in livros)
            {
                string? livroInfo = livro.Value.ToString();
                Console.WriteLine($"\n{livroInfo}");
            }
            Console.ReadKey();
        }

        public List<Livro> GetLivros()
        {

            List<Livro> colecaoDeLivros = livros.Values.ToList();
            if (colecaoDeLivros.Count == 0)
                throw new NullReferenceException();
            return colecaoDeLivros;

        }

        public Livro GetLivro(int key)
        {
            if (livros.ContainsKey(key))
            {
                return livros[key];
            }
            else
            {
                throw new KeyNotFoundException($"Não foi encontrado nenhum livro com a chave {key}.");
            }
        }


    }
}

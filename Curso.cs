using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque
{
    internal class Curso : Produto, IEstoque
    {
        private static List<Curso> _listCurso = new();

        public string Autor { get; set; }
        private int Vagas { get; set; }

        public Curso(string nome, float preco, string autor)
        {
            Nome = nome;
            Preco = preco;
            Autor = autor;
        }
        public static void Exibir()
        {
            Console.Clear();
            Ferramentas.Say("LISTA DE CURSOS:");
            foreach (var i in _listCurso)
            {
                Console.WriteLine("Nome -> " + i.Nome);
                Console.WriteLine("Preco -> " + i.Preco);
                Console.WriteLine("Autor -> " + i.Autor);
                Console.WriteLine(".......................");
            }
            Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
            var sair = Console.ReadLine();

            Console.Clear();
        }

        public static void AdicionarCadastro()
        {
            Console.Clear();
            Ferramentas.Say("CADASTRO DE CURSOS");
            
            Console.WriteLine("Digite o nome do curso");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite o preço do curso");
            var preco = Ferramentas.ConverteParaFloat(Console.ReadLine());
            if (preco == -1f)
            {
                AdicionarCadastro();
                return;
            }

            Console.WriteLine("Digite o autor do curso");
            var autor = Console.ReadLine();

            _listCurso.Add(new Curso(nome, preco, autor));

            Ferramentas.Say("CURSO CADASTRADO");

            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void AdicionarSaida()
        {
            Console.Clear();
            Ferramentas.Say("VENDER CURSO");

            Console.WriteLine("Digite o nome do Curso vendido:");
            var input = Console.ReadLine();

            List<Curso> novaLista = _listCurso
                .Where(item => item.Nome != input)
                .ToList();

            _listCurso = novaLista;

            Console.Clear();

            Ferramentas.Say("CURSO REMOVIDO DOS DISPINIVEIS:");
            Thread.Sleep(2000);
            Exibir();
        }

        public static void AdicionarEntradaEstoque()
        {
            Console.Clear();
            Ferramentas.Say("ENTRADA DE CURSOS- ESTOQUE");

            Console.WriteLine("Digite o nome do curso que deseja " +
                "dar entrada:");

            var input = Console.ReadLine();

            Ferramentas.Say("ESTOQUE ATUALIZADO");
            Thread.Sleep(2000);
            Console.Clear();

            Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
            Console.ReadLine();
            Console.Clear();
        }

        public static void SaidaEstoque()
        {
            Console.Clear();
            Ferramentas.Say("SAIDA DE CURSOS- ESTOQUE");

            Console.WriteLine("Digite o nome do curso que deseja " +
                "dar saida:");

            var input = Console.ReadLine();

            Ferramentas.Say("ESTOQUE ATUALIZADO");
            Thread.Sleep(2000);
            Console.Clear();

            Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

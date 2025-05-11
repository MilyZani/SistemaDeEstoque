using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque
{
    internal class Ebook : Produto, IEstoque
    {
        private static List<Ebook> _listEbook = new();

        public string Autor { get; set; }
        private int _vendas;

        public Ebook(string nome, float preco, string autor)
        {
            Nome = nome;
            Preco = preco;
            Autor = autor;
        }
       
        public static void Exibir()
        {
            Console.Clear();
            Ferramentas.Say("LISTA DE E-BOOK's:");
            foreach (var book in _listEbook)
            {
                Console.WriteLine("Nome -> " + book.Nome);
                Console.WriteLine("Preco -> " + book.Preco);
                Console.WriteLine("Autor -> " + book.Autor);
                Console.WriteLine(".......................");
            }
            Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
            var sair = Console.ReadLine();

            Console.Clear();
        }

        public static void AdicionarCadastro()
        {
            Console.Clear();
            Ferramentas.Say("CADASTRO DE E-BOOK's");

            Console.WriteLine("Digite o nome do E-book:");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite o preço do E-book:");
            var preco = Ferramentas.ConverteParaFloat(Console.ReadLine());
            if (preco == -1f)
            {
                AdicionarCadastro();
                return;
            }

            Console.WriteLine("Digite o Autor:");
            var autor = Console.ReadLine();

            var obj = new Ebook(nome, preco, autor);

            _listEbook.Add(obj);

            Ferramentas.Say("E-BOOK CADASTRADO");
            Thread.Sleep(2000);
            Console.Clear();
            return;
        }

        public static void AdicionarSaida()
        {
            Console.Clear();
            Ferramentas.Say("VENDER E-BOOK");

            Console.WriteLine("Digite o nome do e-book vendido");
            var input = Console.ReadLine();

            List<Ebook> novalista = _listEbook
                .Where(item => item.Nome != input)
                .ToList();

            _listEbook = novalista;

            Console.Clear();

            Ferramentas.Say("E-BOOK REMOVIDO DOS DISPONIVEIS");
            Thread.Sleep(2000);
            Exibir();
        }

        public static void AdicionarEntradaEstoque()
        {
            Console.Clear();
            Ferramentas.Say("ENTRADA DE E-BOOK - ESTOQUE");

            Console.WriteLine("Digite o nome do E-book que deseja " +
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
            Ferramentas.Say("SAIDA DE E-BOOK - ESTOQUE");

            Console.WriteLine("Digite o nome do E-book que deseja " +
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

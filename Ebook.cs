using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque
{
    internal class Ebook : Produto, IEstoque
    {
        public static List<Ebook> _listEbook = new();

        public string Autor { get; set; }
        private int _vendas;
        public static string caminho = "VENDAS.json";

        public static void Exibir()
        {
            Console.Clear();

            var listObj = Ferramentas.LerJsonParaObj<Ebook>(caminho);
            if (listObj.Count == 0)
            {
                Ferramentas.Say("LISTA VAZIA!");
                Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
                Console.ReadLine();
                Console.Clear();
                Menu.StartMenuOpcoes();
                return;
            }
            
            Ferramentas.Say("LISTA DE E-BOOK's:");
            foreach (var book in listObj)
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

            //var obj = new Ebook(nome, preco, autor);
            Ebook objeto = new()
            {
                Nome = nome,
                Preco = preco,
                Autor = autor
            };

            _listEbook.Add(objeto);
            Ferramentas.SalvarListaEmArquivo(_listEbook, caminho);

            Ferramentas.Say("E-BOOK CADASTRADO");
            Thread.Sleep(2000);
            Console.Clear();
            return;
        }

        public static void RemoverCadastro()
        {
            Console.Clear();
            Ferramentas.Say("VENDER E-BOOK");

            Console.WriteLine("Digite o nome do e-book vendido");
            var input = Console.ReadLine();

           

            var inputNome = _listEbook.FirstOrDefault(x => x.Nome == input);
            _listEbook.Remove(inputNome);
            Ferramentas.SalvarListaEmArquivo(_listEbook, caminho);

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

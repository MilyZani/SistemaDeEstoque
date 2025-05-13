using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque
{
    internal class ProdutoFisico : Produto, IEstoque
    {
        public static List<ProdutoFisico> _listPF = new();
        public float Frete { get; set; }
        private float Estoque { get; set; }
        public static string caminho = "ESTOQUE1.json";

        public static void Exibir()
        {
            Console.Clear();

            var listaDeProdutos = Ferramentas.LerJsonParaObj<ProdutoFisico>(caminho);
            if (listaDeProdutos.Count == 0)
            {
                Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
                Console.ReadLine();
                Console.Clear();
                Menu.StartMenuOpcoes();
                return;
            }
            

            Ferramentas.Say("LISTA DE PRODUTOS FISICOS:");
            
            foreach (var i in listaDeProdutos)
            {
                Console.WriteLine("Nome -> " + i.Nome);
                Console.WriteLine("Preco -> " + i.Preco);
                Console.WriteLine("Frete -> " + i.Frete);
                Console.WriteLine(".......................");
            }

            Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");

            Console.ReadLine();
            Console.Clear();

        }

        public static void AdicionarCadastro()
        {
            Console.Clear();
            Ferramentas.Say("CADASTRO DE PRODUTO FISICO");

            Console.WriteLine("Digite o nome do produto:");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite o preço do produto:");
            var preco = Ferramentas.ConverteParaFloat(Console.ReadLine());
            if (preco == -1f)
                return;

            Console.WriteLine("Digite o frete do produto:");
            var frete = Ferramentas.ConverteParaFloat(Console.ReadLine());
            if (frete == -1f)
                return;

            var objProdFisico = new ProdutoFisico()
            {
                Nome = nome,
                Preco = preco,
                Frete = frete
            };

            _listPF.Add(objProdFisico);

            Ferramentas.SalvarListaEmArquivo(_listPF, caminho);

            Console.Clear();

            Ferramentas.Say("PRODUTO CADASTRADO");

            Thread.Sleep(2000);
        }

        public static void AdicionarSaida()
        {
            Console.Clear();
            Ferramentas.Say("VENDA DE PRODUTOS FISICOS");

            Console.WriteLine("Digite o nome do produto vendido:");

            var input = Console.ReadLine();

            List<ProdutoFisico> newList = _listPF
                .Where(item => item.Nome != input)
                .ToList();

            _listPF = newList;

            Console.Clear();

            Ferramentas.Say("PRODUTO REMOVIDO DOS DISPONIVEIS");
            Thread.Sleep(2000);
            Console.Clear();
            Exibir();
        }

        public static void AdicionarEntradaEstoque()
        {
            Console.Clear();
            Ferramentas.Say("ENTRADA DE PRODUTOS FISICOS- ESTOQUE");

            Console.WriteLine("Digite o nome do produto que deseja " +
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
            Ferramentas.Say("SAIDA DE PRODUTOS FISICOS - ESTOQUE");

            Console.WriteLine("Digite o nome do produto que deseja " +
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

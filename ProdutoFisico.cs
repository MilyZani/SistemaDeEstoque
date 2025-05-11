using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque
{
    internal class ProdutoFisico : Produto, IEstoque
    {
        private static List<ProdutoFisico> newList = new();
        private static List<ProdutoFisico> _listPF = new();
        private float _frete;
        private float _estoque;
        public static string _caminho = "ESTOQUE1.txt";

        public ProdutoFisico(string nome, float preco, float frete)
        {
            Nome = nome;
            Preco = preco;
            _frete = frete;
        }

        public static void Exibir()
        {
            Console.Clear();
            Ferramentas.Say("LISTA DE PRODUTOS FISICOS:");
            foreach (var i in _listPF)
            {
                Console.WriteLine("Nome -> " + i.Nome);
                Console.WriteLine("Preco -> " + i.Preco);
                Console.WriteLine("Frete -> " + i._frete);
                Console.WriteLine(".......................");
            }
            Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
            Console.ReadLine();
            Console.Clear();

            // voltar daqui para o menu sem que caia no erro de chamada recursiva
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
            {
                AdicionarCadastro();
                return;
            }

            Console.WriteLine("Digite o frete do produto:");
            var frete = Ferramentas.ConverteParaFloat(Console.ReadLine());
            if (frete == -1f)
            {
                AdicionarCadastro();
                return;
            }

            var objProdFisico = new ProdutoFisico(nome, preco, frete);
            _listPF.Add(objProdFisico);
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
            Ferramentas.Say("SAIDA DE PRODUTOS FISICOS- ESTOQUE");

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

        //public static List<string> TransformaString(List<ProdutoFisico> list)
        //{
            
        //    foreach (var item in list)
        //    {
        //        newList.Add(item.Nome.ToString());
        //        newList.Add(item.Preco.ToString());
        //        newList.Add(item._frete.ToString());
        //        Console.WriteLine(item.Nome);
               
        //    }
        //    return newList;
        //}

        public static void FileAppend(string _caminho, List<string> arquivo)
        {
            foreach (var item in arquivo)
            {
                
            }
            string stringArquivo = arquivo.ToString(); //transforma a lista em 1 string
            File.AppendAllText(_caminho, stringArquivo);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque
{
    internal class Curso : Produto, IEstoque
    {
        public static List<Curso> _listCurso = new();

        public string Autor { get; set; }
        private int Vagas { get; set; }
        public static string caminho = "VAGAS.json";

        public static void Exibir()
        {
            Console.Clear();

            var listObj = Ferramentas.LerJsonParaObj<Curso>(caminho);
            if (listObj.Count == 0)
            {
                Ferramentas.Say("LISTA VAZIA!");
                Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
                Console.ReadLine();
                Console.Clear();
                Menu.StartMenuOpcoes();
                return;
            }

            Ferramentas.Say("LISTA DE CURSOS:");
            foreach (var i in listObj)
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
            

            Curso obj = new()
            {
                Nome = nome,
                Preco = preco,
                Autor = autor
            };


            _listCurso.Add(obj);

            Ferramentas.SalvarListaEmArquivo(_listCurso, caminho);


            Ferramentas.Say("CURSO CADASTRADO");

            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void RemoverCadastro()
        {
            Console.Clear();
            Ferramentas.Say("VENDER CURSO");

            Console.WriteLine("Digite o nome do Curso vendido:");
            var input = Console.ReadLine();


            var inputNome = _listCurso.FirstOrDefault(x => x.Nome == input);
            _listCurso.Remove(inputNome);
            Ferramentas.SalvarListaEmArquivo(_listCurso, caminho);

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

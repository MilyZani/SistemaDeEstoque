using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque;

internal class ProdutoFisico : Produto, IEstoque
{
    private static List<ProdutoFisico> _items = [];
    public float Frete { get; set; }
    
    private float Estoque { get; set; }

    private const string _caminho = "ESTOQUE.json";

    public static void Exibir()
    {
        Console.Clear();

        if (_items.Count == 0)
        {
            Ferramentas.Say("LISTA VAZIA!");
            Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
            Console.ReadLine();
            Console.Clear();
            Menu.StartMenuOpcoes();
            return;
        }
        

        Ferramentas.Say("LISTA DE PRODUTOS FISICOS:");
        
        foreach (var i in _items)
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

        Console.Write("Digite o nome do produto: ");
        var nome = Console.ReadLine();

        if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
        {
            Console.Clear();
            Ferramentas.Say("ERRO NA OPCAO SELECIONADA");
            Thread.Sleep(2000);
            Console.Clear();
            return;
        }

        Console.Write("Digite o preço do produto: ");
        var preco = Ferramentas.ConverteParaFloat(Console.ReadLine());
        if (preco == -1f)
            return;

        Console.Write("Digite o frete do produto: ");
        var frete = Ferramentas.ConverteParaFloat(Console.ReadLine());
        if (frete == -1f)
            return;

        var objProdFisico = new ProdutoFisico()
        {
            Nome = nome,
            Preco = preco,
            Frete = frete
        };

        _items.Add(objProdFisico);

        Ferramentas.SalvarListaEmArquivo(_items, _caminho);

        Console.Clear();

        Ferramentas.Say("PRODUTO CADASTRADO");

        Thread.Sleep(2000);
        Console.Clear();    
    }

    public static void RemoverCadastro()
    {
        Console.Clear();
        
        Ferramentas.Say("VENDA DE PRODUTOS FISICOS");

        Console.WriteLine("Digite o nome do produto vendido:");

        var input = Console.ReadLine();

        var produto = _items.FirstOrDefault(t => input.Contains(t.Nome));
        if (produto is null)
        {
            Console.Clear();
            Ferramentas.Say("PRODUTO NAO ENCONTRADO");
            Thread.Sleep(2000);
            Console.Clear();
            return;
        }

        _items.Remove(produto);
        
        Ferramentas.SalvarListaEmArquivo(_items, _caminho);

        Console.Clear();

        Ferramentas.Say("PRODUTO REMOVIDO DOS DISPONIVEIS");
        Thread.Sleep(2000);
        Console.Clear();
        Exibir();
    }

    public static void AdicionarEntradaEstoque()
    {
        Console.Clear();
        Ferramentas.Say("ENTRADA DE PRODUTOS FISICOS - ESTOQUE");

        Console.Write(
            "Digite o nome do produto que deseja dar entrada: "
        );

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

        Console.WriteLine(
            "Digite o nome do produto que deseja dar saida:"
        );

        Console.ReadLine();

        Ferramentas.Say("ESTOQUE ATUALIZADO");
        Thread.Sleep(2000);
        Console.Clear();

        Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
        Console.ReadLine();
        Console.Clear();
    }

    public static void ValidarLista()
    {
        try
        {
            if (new FileInfo(_caminho).Length == 0) return;

            var list = JsonSerializer.Deserialize<List<ProdutoFisico>>(File.ReadAllText(_caminho));

            if (list is null) return;

            _items = list;
        }
        catch { }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque;
internal class Ebook : Produto, IEstoque
{
    private static List<Ebook> _items = [];
    public string Autor { get; init; }
    
    private static string _caminho = "VENDAS.json";

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
        
        Ferramentas.Say("LISTA DE E-BOOK's:");
        
        foreach (var book in _items)
        {
            Console.WriteLine("Nome -> " + book.Nome);
            Console.WriteLine("Preco -> " + book.Preco);
            Console.WriteLine("Autor -> " + book.Autor);
            Console.WriteLine(".......................");
        }
        
        Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
        
        Console.ReadLine();

        Console.Clear();
    }

    public static void AdicionarCadastro()
    {
        Console.Clear();
        
        Ferramentas.Say("CADASTRO DE E-BOOK's");

        Console.WriteLine("Digite o nome do E-book:");
        
        var nome = Console.ReadLine();
        if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
        {
            Console.Clear();
            Ferramentas.Say("DIGITE UM NOME");
            Thread.Sleep(3000);
            return;
        }

        Console.WriteLine("Digite o preço do E-book:");
        var preco = Ferramentas.ConverteParaFloat(Console.ReadLine());
        if (preco == -1f)
        {
            AdicionarCadastro();
            return;
        }

        Console.WriteLine("Digite o Autor:");
        var autor = Console.ReadLine();

        var objeto = new Ebook()
        {
            Nome = nome,
            Preco = preco,
            Autor = autor
        };

        _items.Add(objeto);
        
        Ferramentas.SalvarListaEmArquivo(_items, _caminho);

        Ferramentas.Say("E-BOOK CADASTRADO");
        Thread.Sleep(2000);
        Console.Clear();
    }

    public static void RemoverCadastro()
    {
        Console.Clear();
        Ferramentas.Say("VENDER E-BOOK");

        Console.WriteLine("Digite o nome do e-book vendido");
        var input = Console.ReadLine();

        var inputNome = _items.FirstOrDefault(x => x.Nome == input);
        
        if (inputNome == null)
        {
            Console.Clear();
            Ferramentas.Say("EBOOK NAO EXISTE");
            Thread.Sleep(3000);
            return;
        }
        
        _items.Remove(inputNome);
        
        Ferramentas.SalvarListaEmArquivo(_items, _caminho);

        Console.Clear();

        Ferramentas.Say("E-BOOK REMOVIDO DOS DISPONIVEIS");
        
        Thread.Sleep(2000);
        
        Exibir();
    }

    public static void AdicionarEntradaEstoque()
    {
        Console.Clear();
        Ferramentas.Say("ENTRADA DE E-BOOK - ESTOQUE");

        Console.Write(
            "Digite o nome do E-book que deseja dar entrada: "
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
        Ferramentas.Say("SAIDA DE E-BOOK - ESTOQUE");

        Console.WriteLine(
        "Digite o nome do E-book que deseja dar saida:"
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

            var list = JsonSerializer.Deserialize<List<Ebook>>(File.ReadAllText(_caminho));

            if (list is null) return;

            _items = list;
        }
        catch { }
    }
}

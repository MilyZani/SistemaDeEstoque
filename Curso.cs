﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque;


internal class Curso : Produto, IEstoque
{
    [JsonPropertyName("autor")]
    public string Autor { get; init; }
    
    public static void Exibir()
    {
        var _list = Ferramentas.PegarLista<Curso>();
        Console.Clear();
        
        if (_list is null || _list.Count == 0)
        {
            Ferramentas.Say("LISTA VAZIA!");
            Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
            Console.ReadLine();
            Console.Clear();
            Menu.StartMenuOpcoes();
            return;
        }

        Ferramentas.Say("LISTA DE CURSOS:");
        
        foreach (var item in _list)
        {
            Console.WriteLine("Nome -> " + item.Nome);
            Console.WriteLine("Preco -> " + item.Preco);
            Console.WriteLine("Autor -> " + item.Autor);
            Console.WriteLine(".......................");
        }
        
        Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
        
        Console.ReadLine();

        Console.Clear();
    }

    public static void AdicionarCadastro()
    {
        Console.Clear();
        Ferramentas.Say("CADASTRO DE CURSOS");

        Console.Write("Digite o nome do curso: ");
        var nome = Console.ReadLine();

        Console.Write("Digite o preço do curso: ");
        var preco = Ferramentas.ConverteParaFloat(Console.ReadLine());
        if (preco == -1f)
        {
            AdicionarCadastro();
            return;
        }

        Console.Write("Digite o autor do curso: ");
        
        var autor = Console.ReadLine();

        Curso obj = new()
        {
            Nome = nome,
            Preco = preco,
            Autor = autor
        };

        var resultado = Ferramentas.AdicionarEntidade(obj);
        
        if (resultado is false)
        {
            Console.Clear();
            Ferramentas.Say("ERRO NO CADASTRO DO CURSO");
            Console.ReadLine();
            return;
        }
        
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

        var inputNome = Ferramentas.RemoverEntidade<Curso>(input);

        if (inputNome is false)
        {
            Console.Clear();
            Ferramentas.Say("PRODUTO NAO EXISTE");
            Thread.Sleep(2000);
            Console.Clear();
            return;
        }
        
        Console.Clear();

        Ferramentas.Say("CURSO REMOVIDO DOS DISPINIVEIS:");
        
        Thread.Sleep(2000);
        
        Exibir();
    }

    public static void AdicionarEntradaEstoque()
    {
        Console.Clear();
        
        Ferramentas.Say("ENTRADA DE CURSOS- ESTOQUE");

        Console.WriteLine(
            "Digite o nome do curso que deseja dar entrada:"
        );

        Console.ReadLine();

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

        Console.WriteLine(
            "Digite o nome do curso que deseja dar saida:"
        );

        Console.ReadLine();

        Ferramentas.Say("ESTOQUE ATUALIZADO");
        Thread.Sleep(2000);
        Console.Clear();

        Ferramentas.Say("TECLE ENTER PARA VOLTAR AO MENU");
        Console.ReadLine();
        Console.Clear();
    }
}
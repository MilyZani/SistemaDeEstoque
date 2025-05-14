using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque;

public static class Menu
{
    public static void StartMenuOpcoes()
    {
        var loop = true;
        while (loop)
        {
            int quantidadeItemsMenu = 6;

            Ferramentas.Say("MENU DE OPÇÕES");

            Console.WriteLine("1- Listar\n2- Adicionar\n3- Remover\n" +
                "4- Entrada\n5- Saida\n6- Fechar Programa");

            var inputDoUsuario = Console.ReadLine();
            var inputInt = Ferramentas.ConverteParaInteiro(inputDoUsuario);
            if (inputInt == -1)
            {
                StartMenuOpcoes();
                return;
            }

            var opcaoDoMenu = Ferramentas.VerificaOpcaoMenu(inputInt, quantidadeItemsMenu);
            if (opcaoDoMenu == -1)
            {
                StartMenuOpcoes();
                return;
            }

            switch (opcaoDoMenu)
            {
                case 1:
                    ListarProdutos();
                    break;

                case 2:
                    CadastroProduto();
                    break;

                case 3:
                    RemoverProduto();
                    break;
                case 4:
                    DarEntrada();
                    break;
                case 5:
                    DarSaida();
                    break;

                case 6:
                    Console.Clear();
                    Console.WriteLine("Saindo do programa em 3...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Saindo do programa em 2...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Saindo do programa em 1...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    loop = false;
                    break;
            }
        }
        
        
        Console.WriteLine("SAIU DO PROGRAMA");
    }

    public static void ListarProdutos()
    {
        int quantidadeOpcoesMenu = 3;
        
        Console.Clear();
        Ferramentas.Say("QUAL TIPO DE PRODUTO DESEJA LISTAR?");

        Ferramentas.SayTiposProduto();

        var inputUsuario = Console.ReadLine();
        var inputUsuarioInteiro = Ferramentas.ConverteParaInteiro(inputUsuario);
        if (inputUsuarioInteiro == -1)
        {
            ListarProdutos();
            return;
        }

        var opcaoMenu = Ferramentas.VerificaOpcaoMenu(inputUsuarioInteiro, quantidadeOpcoesMenu);
        if (opcaoMenu == -1)
        {
            ListarProdutos();
            return;
        }

        switch (opcaoMenu)
        {
            case 1:
                ProdutoFisico.Exibir();
                break;
            case 2:
                Ebook.Exibir();
                break;
            case 3:
                Curso.Exibir();
                break;
        }
    }

    public static void CadastroProduto()
    {
        const int quantidadeItemsMenu = 3;

        Console.Clear();

        Ferramentas.Say("QUAL O TIPO DE PRODUTO QUE QUER CADASTRAR?");

        Ferramentas.SayTiposProduto();

        var inputUsuario = Console.ReadLine();

        var inputInteiro = Ferramentas.ConverteParaInteiro(inputUsuario);
        if (inputInteiro == -1)
        {
            CadastroProduto();
            return;
        }

        var opcaoMenu = Ferramentas.VerificaOpcaoMenu(inputInteiro, quantidadeItemsMenu);
        if (opcaoMenu == -1)
        {
            CadastroProduto();
            return;
        }

        switch (opcaoMenu)
        {
            case 1:
                ProdutoFisico.AdicionarCadastro();
                Console.Clear();
                break;
            case 2:
                Ebook.AdicionarCadastro();
                break;
            case 3:
                Curso.AdicionarCadastro();
                break;
        }
    }

    public static void ListarProduto()
    {
        var quantidadeOpcoesMenu = 3;
        Console.Clear();
        Ferramentas.Say("QUAL TIPO DE PRODUTO DESEJA LISTAR?");

        Ferramentas.SayTiposProduto();

        var inputUsuario = Console.ReadLine();
        var inputUsuarioInteiro = Ferramentas.ConverteParaInteiro(inputUsuario);
        if (inputUsuarioInteiro == -1)
        {
            ListarProduto();
            return;
        }
        var inputusuarioMenu = Ferramentas.VerificaOpcaoMenu(inputUsuarioInteiro, quantidadeOpcoesMenu);
        if (inputusuarioMenu == -1)
        {
            ListarProduto();
            return;
        }

        switch (inputUsuarioInteiro)
        {
            case 1:
                ProdutoFisico.Exibir();
                break;
            case 2:
                Ebook.Exibir();
                break;
            case 3:
                Curso.Exibir();
                break;
        }
    }

    public static void RemoverProduto()
    {
        var quantidadeOpcoesMenu = 3;

        Console.Clear();
        Ferramentas.Say("QUAL O TIPO DO PRODUTO QUE DESEJA EXCLUIR?");

        Ferramentas.SayTiposProduto();
        var input = Console.ReadLine();

        var inputUsuarioInteiro = Ferramentas.ConverteParaInteiro(input);
        if (inputUsuarioInteiro == -1)
        {
            ListarProduto();
            return;
        }
        var VerificaInputMenu = Ferramentas.VerificaOpcaoMenu(inputUsuarioInteiro, quantidadeOpcoesMenu);
        if (VerificaInputMenu == -1)
        {
            ListarProduto();
            return;
        }

        switch (VerificaInputMenu)
        {
            case 1:
                ProdutoFisico.RemoverCadastro();
                break;
            case 2:
                Ebook.RemoverCadastro();
                break;
            case 3:
                Curso.RemoverCadastro();
                break;
        }

    }

    public static void DarEntrada()
    {
        var quantidadeOpcoesMenu = 3;
        Console.Clear();
        Ferramentas.Say("QUAL O TIPO DE PRODUTO QUE DESEJA DAR ENTRADA EM ESTOQUE?");

        Ferramentas.SayTiposProduto();
        var input = Console.ReadLine();

        var inputInt = Ferramentas.ConverteParaInteiro(input);
        if (inputInt == -1)
        {
            ListarProduto();
            return;
        }
        var verificaInputMenu = Ferramentas.VerificaOpcaoMenu(inputInt, quantidadeOpcoesMenu);
        if (verificaInputMenu == -1)
        {
            ListarProduto();
            return;
        }

        switch (verificaInputMenu)
        {
            case 1:
                ProdutoFisico.AdicionarEntradaEstoque();
                break;
            case 2:
                Ebook.AdicionarEntradaEstoque();
                break;
            case 3:
                Curso.AdicionarEntradaEstoque();
                break;
        }
    }

    public static void DarSaida()
    {
        var quantidadeOpcoesMenu = 3;
        Console.Clear();
        Ferramentas.Say("QUAL O TIPO DE PRODUTO QUE DESEJA DAR SAIDA NO ESTOQUE?");

        Ferramentas.SayTiposProduto();
        var input = Console.ReadLine();

        var inputInt = Ferramentas.ConverteParaInteiro(input);
        if (inputInt == -1)
        {
            ListarProduto();
            return;
        }
        var VerificaInputMenu = Ferramentas.VerificaOpcaoMenu(inputInt, quantidadeOpcoesMenu);
        if (VerificaInputMenu == -1)
        {
            ListarProduto();
            return;
        }

        switch (VerificaInputMenu)
        {
            case 1:
                ProdutoFisico.SaidaEstoque();
                break;
            case 2:
                Ebook.SaidaEstoque();
                break;
            case 3:
                Curso.SaidaEstoque();
                break;
        }
    }


}

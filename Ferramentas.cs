using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque;

public static class Ferramentas
{
    public static List<T> LerJsonParaObj<T>(string caminho)
    {
        try
        {
            var arquivo = File.ReadAllText(caminho);

            if (new FileInfo(caminho).Length == 0)
                return [];

            var lista = JsonSerializer.Deserialize<List<T>>(arquivo);

            return lista;
        }
        catch
        {
            return [];
        }
    }

    public static void SalvarListaEmArquivo<T>(List<T> list, string caminho)
    {
        var arquivoJson = JsonSerializer.Serialize(list);
        File.Delete(caminho);
        File.AppendAllText(caminho, arquivoJson);
    }

    public static void Say(string palavra) =>
        Console.WriteLine(new string('=', palavra.Length) + "\n" + palavra + "\n" + new string('=', palavra.Length));

    public static int ConverteParaInteiro(string? inputUsuario)
    {
        if (string.IsNullOrEmpty(inputUsuario) || string.IsNullOrEmpty(inputUsuario))
            return -1;

        if (int.TryParse(inputUsuario, out int input) is false)
        {
            Console.Clear();
            Say("DIGITE UM NÚMERO");
            Thread.Sleep(2000);
            Console.Clear();

            return -1;
        }
        return input;
    }

    public static float ConverteParaFloat(string? inputUsuario)
    {
        if (string.IsNullOrEmpty(inputUsuario) || string.IsNullOrEmpty(inputUsuario))
            return -1;
            
        if (float.TryParse(inputUsuario, out float input) is false)
        {
            Say("ERRO NA OPCAO SELECIONADA");
            Thread.Sleep(2000);
            Console.Clear();

            return -1;
        }
        return input;
    }

    public static int VerificaOpcaoMenu(int input, int quantidadeOpcoesMenu)
    {
        if (input < 1 || input > quantidadeOpcoesMenu)
        {
            Console.Clear();

            Say("DIGITE UM NÚMERO DISPONINEL NO MENU" +
                " DE OPÇÕES ");

            Thread.Sleep(2000);
            Console.Clear();

            return -1;
        }
        return input;
    }

    public static void SayTiposProduto()
    {
        Console.WriteLine(
            "1- Produto Fisico\n" +
            "2- Ebook\n" +
            "3- Curso"
        );
    }
}

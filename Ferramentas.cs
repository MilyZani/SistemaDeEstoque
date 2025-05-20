using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque;

public static class Ferramentas
{
    private const string _url = "http://localhost:3000/api/v1/";
    
    public static List<T>? PegarLista<T>()
    {
        try
        {
            var client = new HttpClient();

            var result = client.GetAsync(_url + typeof(T).Name.ToLower()).Result;
            
            if (result.IsSuccessStatusCode is false) return null;
            
            return JsonSerializer.Deserialize<List<T>>(result.Content.ReadAsStringAsync().Result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public static bool AdicionarEntidade<T>(T entidade)
    {
        try
        {
            var client = new HttpClient();
            var json = JsonSerializer.Serialize(entidade);
            var content = new StringContent(
                json, 
                Encoding.UTF8, 
                "application/json"
            );
            var result = client.PostAsync(
                _url + typeof(T).Name.ToLower(), 
                content
            ).Result;
            
            if (result.IsSuccessStatusCode is false) return false;

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static bool RemoverEntidade<T>(string nome)
    {
        try
        {
            var client = new HttpClient();
            
            var result = client.DeleteAsync(
                _url + typeof(T).Name.ToLower()  + "/" + nome
            ).Result;
            
            if (result.IsSuccessStatusCode is false) return false;

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
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

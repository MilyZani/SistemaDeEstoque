using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque;

public class Tests
{
    public static class Estoque
    {
        public static void AdicionarCadastroTest()
        {
            var successString = "======================================\nPRODUTO CADASTRADO\n======================================";
            
            var originalConsoleIn = Console.In;
            var bufferIn = new StringWriter();
            var produto = "sapato\n12\n12";
            Console.SetIn(new StringReader(produto));


            var originalConsoleOut = Console.Out;
            var bufferOut = new StringWriter();
            Console.SetOut(bufferOut);
            ProdutoFisico.AdicionarCadastro();
            Console.SetIn(originalConsoleIn);
            var outData = bufferOut.ToString();
            Console.SetOut(originalConsoleOut);
            if (outData.Split("\n").Any(i => i == "PRODUTO CADASTRADO"))
            {
                Console.WriteLine("TESTE_ADICIONAR - OK");
                Console.ReadLine();
            }
            Console.WriteLine("TESTE_ADICIONAR - ERROR");
            Console.ReadLine();
        }
    }
}

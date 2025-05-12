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
        public static void Start()
        {
            var resultList = new List<string>();
            if (AdicionarCadastroTest_Erro())
            {
                resultList.Add("TESTE_ADICIONAR_PRODUTO_ERRADO - OK");
            }
            else
            {
                resultList.Add("TESTE_ADICIONAR_PRODUTO_ERRADO - ERRO");
            }

            if (AdicionarCadastroTest_Sucesso())
            {
                resultList.Add("TESTE_ADICIONAR_PRODUTO_CORRETO - OK");
            }
            else
            {
                resultList.Add("TESTE_ADICIONAR_PRODUTO_CORRETO - ERRO");
            }
            resultList.ForEach(x => Console.WriteLine(x));
        }
        
        private static bool AdicionarCadastroTest_Sucesso()
        {
            var originalInput = Console.In;
            var originalOutput = Console.Out;
            var bufferInput = new StringWriter();
            var bufferOutput = new StringWriter();
            
            var produto = "sapato\n12\n12";

            Console.SetIn(new StringReader(produto));
            Console.SetOut(bufferOutput);

            ProdutoFisico.AdicionarCadastro();
            
            var outData = bufferOutput.ToString().Split("\n");
            Console.SetOut(originalOutput);
            Console.SetIn(originalInput);
            
            if (outData.Any(i => i == "PRODUTO CADASTRADO"))
                return true;
            return false;
        }
        
        private static bool AdicionarCadastroTest_Erro()
        {
            var originalInput = Console.In;
            var originalOutput = Console.Out;
            var bufferInput = new StringWriter();
            var bufferOutput = new StringWriter();
            
            var produto = "sapato\n12\nf\nsapato\n2\n2";

            Console.SetIn(new StringReader(produto));
            Console.SetOut(bufferOutput);

            ProdutoFisico.AdicionarCadastro();
            
            var outData = bufferOutput.ToString().Split("\n");
            
            Console.SetOut(originalOutput);
            Console.SetIn(originalInput);

            if (outData.Any(i => i == "ERRO NA OPCAO SELECIONADA"))
                return true;
            return false;
        }
    
    }
}

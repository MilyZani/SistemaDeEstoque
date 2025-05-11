using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto__Sistema_de_Estoque
{
    public interface IEstoque
    {
        static void Exibir() { }

        static void AdicionarCadastro() { }

        static void AdicionarSaida() { }

        static void AdicionarEntradaEstoque() { }

        static void SaidaEstoque() { }
    }
}

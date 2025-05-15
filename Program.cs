using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Projeto__Sistema_de_Estoque;

internal class Program
{
    public static void Main(string[] args)
    {
        ProdutoFisico.ValidarLista();
        Ebook.ValidarLista();
        Curso.ValidarLista();
        Menu.StartMenuOpcoes();
    }
}

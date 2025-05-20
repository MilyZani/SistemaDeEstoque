using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.Json;

namespace Projeto__Sistema_de_Estoque;

public class Program
{
    public static void Main(string[] args)
    {
        ProdutoFisico.ValidarLista();
        Ebook.ValidarLista();
        Menu.StartMenuOpcoes();
    }
}

using System.Collections.Generic;
using System.Drawing;

namespace Projeto__Sistema_de_Estoque;

internal class Program
{
    public static void Main(string[] args)
    {
        Ferramentas.LerJsonParaObj<ProdutoFisico>(ProdutoFisico.caminho);
        Ferramentas.LerJsonParaObj<Ebook>(Ebook.caminho);
        Ferramentas.LerJsonParaObj<Curso>(Curso.caminho);
        Menu.StartMenuOpcoes();
    }
}

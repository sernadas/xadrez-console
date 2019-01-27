using tabuleiro;

namespace xadrez_console
{
    class Tela
    {

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    string peca = "-";
                    if (tab.Peca(i,j) != null)
                    {
                        peca = tab.Peca(i, j).ToString();
                    }
                    System.Console.Write(peca + " ");
                }
                System.Console.WriteLine();
            }
        }

    }
}

using System;
using tabuleiro;

namespace xadrez_console
{
    class Tela
    {

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                System.Console.Write((int)(8 - i) + " ");

                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.Peca(i, j) != null)
                    {
                        ImprimePeca(tab.Peca(i, j));
                    }
                    else
                    {
                        System.Console.Write("-");
                    }
                    
                    System.Console.Write(" ");
                }
                System.Console.WriteLine();
            }

            System.Console.Write("  ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                int caracter = 'a' + j;
                //System.Console.Write(caracter + ' ');
                System.Console.Write((char)caracter + " ");

            }

        }


        public static void ImprimePeca(Peca peca)
        {

            ConsoleColor oldColor = Console.ForegroundColor;

            switch (peca.Cor)
            {
                case Cor.Branco:
                    break;
                case Cor.Preto:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Cor.Amarelo:
                    break;
                case Cor.Laranja:
                    break;
                case Cor.Azul:
                    break;
                case Cor.Vermelha:
                    break;
                case Cor.Verde:
                    break;
                default:
                    break;
            }

            Console.Write(peca);
            Console.ForegroundColor = oldColor;


        }
    }
}

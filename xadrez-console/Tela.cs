using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] movimentosPossiveis)
        {
            ConsoleColor corBackgroundNormal = Console.BackgroundColor;
            ConsoleColor corBackgroundDestaque = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                System.Console.Write((int)(8 - i) + " ");

                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (movimentosPossiveis != null && movimentosPossiveis[i,j])
                    {
                        Console.BackgroundColor = corBackgroundDestaque;
                    }
                    else
                    {
                        Console.BackgroundColor = corBackgroundNormal;
                    }
                    ImprimePeca(tab.Peca(i, j));
                    System.Console.Write(" ");
                }
                System.Console.WriteLine();
                Console.BackgroundColor = corBackgroundNormal;

            }


            System.Console.Write("  ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                int caracter = 'a' + j;
                //System.Console.Write(caracter + ' ');
                System.Console.Write((char)caracter + " ");

            }

        }

        public static void ImprimirTabuleiro(Tabuleiro tab) 
        {
            ImprimirTabuleiro(tab, null);
        }

            public static void ImprimePeca(Peca peca)
        {

            if (peca == null)
            {
                Console.Write("-");
                return;
            }


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


        public static PosicaoXadrez LerPosicaoXadrez ()
        {
            string input = Console.ReadLine();
            char coluna = input[0];
            int linha = int.Parse(input[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }



    }
}


using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Aguardando Jodada: " + partida.JogadorAtual);

            if (partida.Xeque)
            {
                Console.WriteLine("XEQUE!");
            }
        }


        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            
            Console.WriteLine("Peças Capturadas: ");

            Console.WriteLine("Brancas: ");
            Console.ForegroundColor = GetConsoleColor(Cor.Branco);
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branco));

            Console.WriteLine();

            Console.WriteLine("Pretas: ");
            Console.ForegroundColor = GetConsoleColor(Cor.Preto);
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preto));


            Console.ForegroundColor = oldColor;
        }


        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");

            foreach (Peca p in conjunto)
            {
                Console.Write(p + " ");
            }

            Console.Write("]");
        }




            public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] movimentosPossiveis)
        {
            ConsoleColor corBackgroundNormal = Console.BackgroundColor;
            ConsoleColor corBackgroundDestaque = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                System.Console.Write(8 - i + " ");

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


        private static ConsoleColor GetConsoleColor (Cor cor)
        {

            ConsoleColor consoleColor = ConsoleColor.White;

            switch (cor)
            {
                case Cor.Branco:
                    consoleColor = ConsoleColor.White;
                    break;
                case Cor.Preto:
                    consoleColor = ConsoleColor.Yellow;
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

            return consoleColor;
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

            Console.ForegroundColor = GetConsoleColor(peca.Cor);
            
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


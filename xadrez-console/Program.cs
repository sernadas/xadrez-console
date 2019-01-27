using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Preto), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preto), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Preto), new Posicao(0, 0));

                Tela.imprimirTabuleiro(tab);
                */

                PosicaoXadrez pos = new PosicaoXadrez('a', 1);

                Console.WriteLine(pos.ToPosicao());
            }

            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            } 

            Console.ReadKey();
        }
    }
}

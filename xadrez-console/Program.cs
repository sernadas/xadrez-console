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


                //PosicaoXadrez pos = new PosicaoXadrez('a', 1);
                //Console.WriteLine(pos.ToPosicao());

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {

                    try
                    {


                        Console.Clear();

                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);

                        Console.Clear();
                        bool[,] movimentosPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro, movimentosPossiveis);


                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);


                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }

                }


            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }


        }



    }
}

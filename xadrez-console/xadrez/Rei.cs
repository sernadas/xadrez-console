using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public PartidaDeXadrez Partida { get; private set; }

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover (Posicao pos)
        {
            // ou nao tem peça na nova posição, ou é uma peça adversária
            return Tabuleiro.Peca(pos) == null || Tabuleiro.Peca(pos).Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao novaPosicao = new Posicao(0, 0);


            novaPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            // #jogada especial roque
            if (QteMovimentos == 0 && ! Partida.Xeque)
            {
                // #jogadaespecial roque pequeno
                Posicao posicaoTorre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posicaoTorre1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }


                // #jogadaespecial roque grande
                Posicao posicaoTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(posicaoTorre2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna -2] = true;
                    }
                }
            }


            return mat;
        }


        private bool TesteTorreParaRoque (Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);

            return p != null && p is Torre && p.Cor == Cor && p.QteMovimentos == 0;
        }
    }
}

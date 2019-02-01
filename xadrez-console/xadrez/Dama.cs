using tabuleiro;

namespace xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "D";
        }

        private bool PodeMover(Posicao pos)
        {
            // ou nao tem peça na nova posição, ou é uma peça adversária
            return Tabuleiro.Peca(pos) == null || Tabuleiro.Peca(pos).Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao novaPosicao = new Posicao(0, 0);
            int i, j;


            // esquerda
            for (i = Posicao.Linha - 1; i >= 0; i--)
            {
                novaPosicao.DefinirValores(i, Posicao.Coluna);

                if (!Tabuleiro.PosicaoValida(novaPosicao) || !PodeMover(novaPosicao))
                {
                    break;
                }

                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;

                if (Tabuleiro.ExistePeca(novaPosicao) && Tabuleiro.Peca(novaPosicao).Cor != Cor)
                {
                    break;
                }
            }


            // direita
            for (i = Posicao.Linha + 1; i < Tabuleiro.Linhas; i++)
            {
                novaPosicao.DefinirValores(i, Posicao.Coluna);

                if (!Tabuleiro.PosicaoValida(novaPosicao) || !PodeMover(novaPosicao))
                {
                    break;
                }

                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;

                if (Tabuleiro.ExistePeca(novaPosicao) && Tabuleiro.Peca(novaPosicao).Cor != Cor)
                {
                    break;
                }
            }

            // cima
            for (i = Posicao.Coluna - 1; i >= 0; i--)
            {
                novaPosicao.DefinirValores(Posicao.Linha, i);

                if (!Tabuleiro.PosicaoValida(novaPosicao) || !PodeMover(novaPosicao))
                {
                    break;
                }

                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;

                if (Tabuleiro.ExistePeca(novaPosicao) && Tabuleiro.Peca(novaPosicao).Cor != Cor)
                {
                    break;
                }
            }


            // baixo
            for (i = Posicao.Coluna + 1; i < Tabuleiro.Colunas; i++)
            {
                novaPosicao.DefinirValores(Posicao.Linha, i);

                if (!Tabuleiro.PosicaoValida(novaPosicao) || !PodeMover(novaPosicao))
                {
                    break;
                }

                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;

                if (Tabuleiro.ExistePeca(novaPosicao) && Tabuleiro.Peca(novaPosicao).Cor != Cor)
                {
                    break;
                }
            }



            // baixo-esquerda
            i = Posicao.Linha - 1;
            j = Posicao.Coluna - 1;
            novaPosicao = new Posicao(i, j);
            while (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;

                if (Tabuleiro.ExistePeca(novaPosicao) && Tabuleiro.Peca(novaPosicao).Cor != Cor)
                {
                    break;
                }
                i--;
                j--;
                novaPosicao = new Posicao(i, j);
            }



            // cima-esquerda
            i = Posicao.Linha + 1;
            j = Posicao.Coluna - 1;
            novaPosicao = new Posicao(i, j);
            while (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;

                if (Tabuleiro.ExistePeca(novaPosicao) && Tabuleiro.Peca(novaPosicao).Cor != Cor)
                {
                    break;
                }
                i++;
                j--;
                novaPosicao = new Posicao(i, j);
            }



            // cima-direita
            i = Posicao.Linha + 1;
            j = Posicao.Coluna + 1;
            novaPosicao = new Posicao(i, j);
            while (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;

                if (Tabuleiro.ExistePeca(novaPosicao) && Tabuleiro.Peca(novaPosicao).Cor != Cor)
                {
                    break;
                }
                i++;
                j++;
                novaPosicao = new Posicao(i, j);
            }



            // baixo-direita
            i = Posicao.Linha - 1;
            j = Posicao.Coluna + 1;
            novaPosicao = new Posicao(i, j);
            while (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;

                if (Tabuleiro.ExistePeca(novaPosicao) && Tabuleiro.Peca(novaPosicao).Cor != Cor)
                {
                    break;
                }
                i--;
                j++;
                novaPosicao = new Posicao(i, j);
            }



            return mat;
        }
    }
}

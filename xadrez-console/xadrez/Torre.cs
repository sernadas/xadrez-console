using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "T";
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

            // esquerda
            for (int i = Posicao.Linha-1; i >= 0; i--)
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
            for (int i = Posicao.Linha + 1; i < Tabuleiro.Linhas; i++)
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
            for (int i = Posicao.Coluna - 1; i >= 0; i--)
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
            for (int i = Posicao.Coluna + 1; i < Tabuleiro.Colunas; i++)
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

            return mat;
        }
    }
}

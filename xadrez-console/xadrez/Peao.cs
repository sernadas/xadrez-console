using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "P";
        }


        private bool ExisteInimigo (Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null;
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


            if (Cor == Cor.Branco)
            {
                novaPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(novaPosicao) && Livre(novaPosicao))
                {
                    mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
                }

                novaPosicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(novaPosicao) && Livre(novaPosicao) && QteMovimentos == 0)
                {
                    mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
                }

                novaPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna-1);
                if (Tabuleiro.PosicaoValida(novaPosicao) && ExisteInimigo(novaPosicao))
                {
                    mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
                }

                novaPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(novaPosicao) && ExisteInimigo(novaPosicao))
                {
                    mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
                }
            }
            else
            {

                novaPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(novaPosicao) && Livre(novaPosicao))
                {
                    mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
                }

                novaPosicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(novaPosicao) && Livre(novaPosicao) && QteMovimentos==0)
                {
                    mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
                }

                novaPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(novaPosicao) && ExisteInimigo(novaPosicao))
                {
                    mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
                }

                novaPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(novaPosicao) && ExisteInimigo(novaPosicao))
                {
                    mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
                }

            }



            return mat;
        }
    }
}

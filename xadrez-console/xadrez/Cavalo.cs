using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "C";
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


            novaPosicao = new Posicao(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao = new Posicao(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao = new Posicao(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao = new Posicao(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao = new Posicao(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao = new Posicao(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao = new Posicao(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }

            novaPosicao = new Posicao(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(novaPosicao) && PodeMover(novaPosicao))
            {
                mat[novaPosicao.Linha, novaPosicao.Coluna] = true;
            }
            return mat;
        }
    }
}

using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
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

            return mat;
        }

    }
}

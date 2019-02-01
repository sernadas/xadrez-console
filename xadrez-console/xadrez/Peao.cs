using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public PartidaDeXadrez Partida { get; private set; }

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            Partida = partida;
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

                // #jogadaespecial en passant
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && 
                        Partida.VulneravelEnPassant == Tabuleiro.Peca(esquerda))
                    {
                        mat[esquerda.Linha -1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) &&
                        Partida.VulneravelEnPassant == Tabuleiro.Peca(direita))
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
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

                // #jogadaespecial en passant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) &&
                        Partida.VulneravelEnPassant == Tabuleiro.Peca(esquerda))
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) &&
                        Partida.VulneravelEnPassant == Tabuleiro.Peca(direita))
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }

            }



            return mat;
        }
    }
}

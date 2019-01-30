using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            Terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento (Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQteMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branco)
            {
                JogadorAtual = Cor.Preto;
            }
            else
            {
                JogadorAtual = Cor.Branco;
            }
        }

        public void RealizaJogada (Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoDeOrigem (Posicao origem)
        {
            
            if (! Tabuleiro.ExistePeca(origem))
            {
                throw new TabuleiroException("Não há peça nessa posição");
            }

            Peca peca = Tabuleiro.Peca(origem);

            if (peca.Cor != JogadorAtual)
            {
                throw new TabuleiroException("Só pode escolher uma peça do Jogador de cor " + JogadorAtual.ToString());
            }

            if (! peca.ExistemMovimentosPossiveis())
            {
                throw new TabuleiroException("Essa peça não tem qualquer movimento possivel.");
            }

        }


        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            
            if (! Tabuleiro.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Não pode mover para essa posição");
            }

        }




        private void ColocarPecas ()
        {

            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('e', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Branco), new PosicaoXadrez('d', 1).ToPosicao());


            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('c', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('d', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('e', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Preto), new PosicaoXadrez('d', 8).ToPosicao());

        }

    }
}

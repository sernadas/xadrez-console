using System;
using tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        private HashSet<Peca> Pecas { get; set; }
        private HashSet<Peca> Capturadas { get; set; }
        public bool Xeque { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            Xeque = false;
            ColocarPecas();
        }

        public Peca ExecutaMovimento (Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQteMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);

            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }

            // #jogadaespecial roque pequeno
            if (peca is Rei && destino.Coluna == origem.Coluna+2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca t = Tabuleiro.RetirarPeca(origemT);
                t.IncrementarQteMovimentos();
                Tabuleiro.ColocarPeca(t, destinoT);
            }

            // #jogadaespecial roque grande
            if (peca is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca t = Tabuleiro.RetirarPeca(origemT);
                t.IncrementarQteMovimentos();
                Tabuleiro.ColocarPeca(t, destinoT);
            }

            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca PecaCapturada)
        {
            Peca pecaVoltaOrigem = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(pecaVoltaOrigem, origem);
            pecaVoltaOrigem.DecrementarQteMovimentos();

            if (PecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(PecaCapturada, destino);
                Capturadas.Remove(PecaCapturada);
            }

            // #jogadaespecial roque pequeno
            if (pecaVoltaOrigem is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca t = Tabuleiro.RetirarPeca(destinoT);
                t.DecrementarQteMovimentos();
                Tabuleiro.ColocarPeca(t, origemT);
            }

            // #jogadaespecial roque grande
            if (pecaVoltaOrigem is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca t = Tabuleiro.RetirarPeca(destinoT);
                t.IncrementarQteMovimentos();
                Tabuleiro.ColocarPeca(t, origemT);
            }


        }




        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Movimento não é possivel, senão fica em Xeque.");
            }

            if (EstaEmXeque(CorAdversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (XequeMate(CorAdversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
        }

        private Cor CorAdversaria (Cor cor)
        {
            return (cor == Cor.Branco ? Cor.Preto : Cor.Branco);
        }

        private Peca Rei (Cor cor)
        {
            foreach (Peca p in PecasEmJogo(cor))
            {
                if (p is Rei)
                {
                    return p;
                }
            }
            return null;
        }

        public bool EstaEmXeque (Cor cor)
        {
            Peca rei = Rei(cor);

            foreach (Peca p in PecasEmJogo(CorAdversaria(cor)))
            {
                bool[,] movimentosPossiveis = p.MovimentosPossiveis();
                if (movimentosPossiveis[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }

            return false;
        }

        public bool XequeMate (Cor cor)
        {
            if (! EstaEmXeque(cor))
            {
                return false;
            }

            foreach (Peca peca in PecasEmJogo(cor))
            {
                bool[,] movimentosPossiveis = peca.MovimentosPossiveis();

                for (int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < Tabuleiro.Colunas; j++)
                    {
                        if (movimentosPossiveis[i,j])
                        {
                            Posicao posicaoPecaOrigem = peca.Posicao;
                            Posicao posicaoPecaDestino = new Posicao(i,j);

                            Peca pecaCapturada = ExecutaMovimento(posicaoPecaOrigem, posicaoPecaDestino);
                            bool emXeque = EstaEmXeque(cor);
                            DesfazMovimento(posicaoPecaOrigem, posicaoPecaDestino, pecaCapturada);

                            if (! emXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }


        public HashSet<Peca> PecasCapturadas (Cor cor)
        {
            HashSet<Peca> capturadasCor = new HashSet<Peca>();

            foreach (Peca p in Capturadas)
            {
                if (p.Cor == cor)
                {
                    capturadasCor.Add(p);
                }
            }
            return capturadasCor;
        }


        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> pecasCor = new HashSet<Peca>();
            HashSet<Peca> pecasCapt = PecasCapturadas(cor);
            
            foreach (Peca p in Pecas)
            {
                if (p.Cor == cor)
                {
                    pecasCor.Add(p);
                }
            }

            pecasCor.ExceptWith(pecasCapt);

            return pecasCor;
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
            
            if (! Tabuleiro.Peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Não pode mover para essa posição");
            }

        }



        private void ColocarNovaPeca (char coluna, int linha, Peca peca)
        {

            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }



        private void ColocarPecas ()
        {
            ColocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('d', 1, new Dama(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branco, this));
            ColocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('a', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('b', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('c', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('d', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('e', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('f', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('g', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('h', 2, new Peao(Tabuleiro, Cor.Branco));


            ColocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 8, new Dama(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('a', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('b', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('c', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('f', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('g', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('h', 7, new Peao(Tabuleiro, Cor.Preto));

        }

    }
}

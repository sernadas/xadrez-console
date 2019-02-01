namespace tabuleiro
{
    abstract class Peca
    {

        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QteMovimentos = 0;
        }

        public void IncrementarQteMovimentos()
        {
            QteMovimentos++;
        }

        public void DecrementarQteMovimentos()
        {
            QteMovimentos++;
        }

        public bool ExistemMovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = MovimentosPossiveis();

            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (movimentosPossiveis[i,j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool PodeMoverPara(Posicao destino)
        {
            return MovimentosPossiveis() [destino.Linha, destino.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}

using tabuleiro;

namespace xadrez
{
    /// <summary>
    /// Classe responsável por representar a entidade Torre.
    /// </summary>
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T";
        }

        /// <summary>
        /// Método para permitir movimentação de peça Torre.
        /// </summary>
        /// <param name="pos">Define uma instância da classe Posicao.</param>
        /// <returns>A posição da peça Torre.</returns>
        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.RetornarPeca(pos);
            return p == null || p.Cor != Cor;
        }

        /// <summary>
        /// Método para verificar os possiveis movimentos da peça Torre.
        /// </summary>
        /// <returns>Uma matriz com as posições da peça Torre.</returns>
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // Acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.RetornarPeca(pos) != null && Tab.RetornarPeca(pos).Cor != Cor) 
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            // Abaixo 
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.RetornarPeca(pos) != null && Tab.RetornarPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            // Direita 
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.RetornarPeca(pos) != null && Tab.RetornarPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            // Esquerda 
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.RetornarPeca(pos) != null && Tab.RetornarPeca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return mat;
        }
    }
}

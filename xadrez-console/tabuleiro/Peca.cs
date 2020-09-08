namespace tabuleiro
{
    /// <summary>
    /// Classe responsável pela atribuição das peças no tabuleiro associadas as cores e posições. 
    /// </summary>
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QteMovimentos = 0;
        }

        /// <summary>
        /// Método para incrementar a quantidade de movimentos das peças.
        /// </summary>
        public void IncrementarQteMovimentos() 
        {
            QteMovimentos++;
        }

        /// <summary>
        /// Método para verificar se existe movimentos possíveis das peças.
        /// </summary>
        /// <returns>O movimento possível das peças.</returns>
        public bool ExisteMovimentosPossiveis() 
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++) 
            {
                for (int j = 0; j < Tab.Colunas; j++) 
                {
                    if (mat[i, j]) 
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Método para verificar se peça pode mover para determinada posição.
        /// </summary>
        /// <param name="pos">Define uma instância da classe Posicao.</param>
        /// <returns>Os movimentos possíveis da peça.</returns>
        public bool PodeMoverPara(Posicao pos) 
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        /// <summary>
        /// Método para indicar os possiveis movimentos das peças.
        /// </summary>
        /// <returns>Uma matriz com as posições das peças.</returns>
        public abstract bool[,] MovimentosPossiveis();
    }
}

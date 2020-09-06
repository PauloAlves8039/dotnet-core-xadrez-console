namespace tabuleiro
{
    /// <summary>
    /// Classe responsável pela atribuição das peças no tabuleiro associadas as cores e posições. 
    /// </summary>
    class Peca
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
    }
}

namespace tabuleiro
{
    /// <summary>
    /// Classe responsável pela atribuição do tabuleiro.
    /// </summary>
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        /// <summary>
        /// Método responsável por retornar uma matriz de peças.
        /// </summary>
        /// <param name="linha">Define o parâmetro linha.</param>
        /// <param name="coluna">Define o parâmetro coluna.</param>
        /// <returns>Uma matriz de peças.</returns>
        public Peca RetornarPeca(int linha, int coluna) 
        {
            return pecas[linha, coluna];
        }
    }

}

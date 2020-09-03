namespace tabuleiro
{
    /// <summary>
    /// Classe responsável por definir as posições das peças no tabuleiro.
    /// </summary>
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        /// <summary>
        /// Método responsável por definir valores das posições.
        /// </summary>
        /// <param name="linha">Define o parâmetro linha.</param>
        /// <param name="coluna">Define o parâmetro coluna.</param>
        public void DefinirValores(int linha, int coluna) 
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString()
        {
            return Linha + "," + Coluna;
        }
    }
}

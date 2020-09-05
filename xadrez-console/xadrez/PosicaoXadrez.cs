using tabuleiro;

namespace xadrez
{
    /// <summary>
    /// Classe responsável por deternimar as posições das peças de acordo com o contexto do xadrez.
    /// </summary>
    class PosicaoXadrez
    {
        /// <value>Representa o valor da coluna.</value>
        public char Coluna { get; set; }

        /// <value>Representa o valor da linha.</value>
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        /// <summary>
        /// Método para converter a posição do xadrez para posição interna de uma matriz.
        /// </summary>
        /// <returns>Posição do xadrez no tabuleiro.</returns>
        public Posicao ToPosicao() 
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}

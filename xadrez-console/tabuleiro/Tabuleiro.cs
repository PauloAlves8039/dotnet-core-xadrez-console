namespace tabuleiro
{
    /// <summary>
    /// Classe responsável pela atribuição do tabuleiro.
    /// </summary>
    class Tabuleiro
    {
        /// <value>Representa o valor das linhas.</value>
        public int Linhas { get; set; }

        /// <value>Representa o valor das colunas.</value>
        public int Colunas { get; set; }

        /// <summary>
        /// Matriz responsável pela estrutura das posições das peças no tabuleiro.
        /// </summary>
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

        /// <summary>
        /// Método responsável por retornar uma matriz de peças.
        /// </summary>
        /// <param name="pos">Define uma instância da classe Posicao.</param>
        /// <returns>Uma matriz de peças.</returns>
        public Peca RetornarPeca(Posicao pos) 
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        /// <summary>
        /// Método para verificar se peça existe em determinada posição.
        /// </summary>
        /// <param name="pos">Define uma instância da classe Posicao.</param>
        /// <returns>A posição válida da peça.</returns>
        public bool ExistePeca(Posicao pos) 
        {
            ValidarPosicao(pos);
            return RetornarPeca(pos) != null;
        }

        /// <summary>
        /// Método para colocar peça no tabuleiro.
        /// </summary>
        /// <param name="p">Define uma instância da classe Peca.</param>
        /// <param name="pos">Define uma instância da classe Posicao.</param>
        public void ColocarPeca(Peca p, Posicao pos) 
        {
            if (ExistePeca(pos)) 
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        /// <summary>
        /// Método para retirar peça de um determinada posição no tabuleiro.
        /// </summary>
        /// <param name="pos">Identifica a posição da peça a ser removida no tabuleiro.</param>
        /// <returns>Posição onde a peça foi removida.</returns>
        public Peca RetirarPeca(Posicao pos) 
        {
            if (RetornarPeca(pos) == null) 
            {
                return null;
            }
            Peca aux = RetornarPeca(pos);
            aux.Posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        /// <summary>
        /// Método para testar se uma posição é válida.
        /// </summary>
        /// <param name="pos">Define uma instância da classe Posicao.</param>
        /// <returns>Uma posição válida no tabuleiro.</returns>
        public bool PosicaoValida(Posicao pos) 
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas) 
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método para válidar uma posição. 
        /// </summary>
        /// <param name="pos">Define uma instância da classe Posicao.</param>
        public void ValidarPosicao(Posicao pos) 
        {
            if (!PosicaoValida(pos)) 
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }

}

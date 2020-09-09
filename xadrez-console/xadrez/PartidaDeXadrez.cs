using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    /// <summary>
    /// Classe responsável pela regra do jogo de xadrez.
    /// </summary>
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        
        public int Turno { get; private set; }

        public Cor JogadorAtual { get; private set; }

        public bool Terminada { get; private set; }

        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            AdicionarPecas();
        }

        /// <summary>
        /// Método responsável pela execução de movimentos das peças no tabuleiro.
        /// </summary>
        /// <param name="origem">Define a posição de origem.</param>
        /// <param name="destino">Define a posição de destino.</param>
        public void ExecutarMovimento(Posicao origem, Posicao destino) 
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }

        /// <summary>
        /// Método responsável por realizar jogada.
        /// </summary>
        /// <param name="origem">Define a posição de origem.</param>
        /// <param name="destino">Define a posição de destino.</param>
        public void RealizaJogada(Posicao origem, Posicao destino) 
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        /// <summary>
        /// Método para validar posição de origem.
        /// </summary>
        /// <param name="pos">Define uma instância da classe Posicao.</param>
        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.RetornarPeca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if (JogadorAtual != Tab.RetornarPeca(pos).Cor) 
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }

            if (!Tab.RetornarPeca(pos).ExisteMovimentosPossiveis()) 
            {
                throw new TabuleiroException("Nâo há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        /// <summary>
        /// Método para validar posição de destino.
        /// </summary>
        /// <param name="origem">Define a posição de origem.</param>
        /// <param name="destino">Define a posição de destino.</param>
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino) 
        {
            if (!Tab.RetirarPeca(origem).PodeMoverPara(destino)) 
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        /// <summary>
        /// Método para mudar jogador.
        /// </summary>
        private void MudaJogador() 
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else 
            {
                JogadorAtual = Cor.Branca;
            }
        }

        /// <summary>
        /// Método para capturar peça de determinada cor.
        /// </summary>
        /// <param name="cor">Define uma instância da classe Cor.</param>
        /// <returns>Um conjunto de peças de detrminada cor.</returns>
        public HashSet<Peca> PecasCapturadas(Cor cor) 
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) 
            {
                if (x.Cor == cor) 
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        /// <summary>
        /// Método para obter cor de determinada peça em jogo.
        /// </summary>
        /// <param name="cor">Define uma instância da classe Cor.</param>
        /// <returns>Retorna uma peça de determinada cor em jogo.</returns>
        public HashSet<Peca> PecasEmJogo(Cor cor) 
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        /// <summary>
        /// Método para adicionar nova peça.
        /// </summary>
        /// <param name="coluna">Indica posição da coluna.</param>
        /// <param name="linha">Indica posição da linha</param>
        /// <param name="peca">Define uma instância da classe Peca.</param>
        public void ColocarNovaPeca(char coluna, int linha, Peca peca) 
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        /// <summary>
        /// Método para a adição das peças.
        /// </summary>
        private void AdicionarPecas() 
        {
            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));

        }
    }
}

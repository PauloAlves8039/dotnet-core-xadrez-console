using System;
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

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
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
        /// Método para a adição das peças.
        /// </summary>
        private void AdicionarPecas() 
        {
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}

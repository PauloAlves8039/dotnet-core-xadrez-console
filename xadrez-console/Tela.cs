using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    /// <summary>
    /// Classe responsável por imprimir o tabuleiro na tela.
    /// </summary>
    class Tela
    {
        /// <summary>
        /// Método para imprimir partida.
        /// </summary>
        /// <param name="partida">Recebe uma instância da classe PartidaDeXadrez.</param>
        public static void ImprimirPartida(PartidaDeXadrez partida) 
        {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
        }

        /// <summary>
        /// Método para imprimir peças capturadas.
        /// </summary>
        /// <param name="partida">Recebe uma instância da classe PartidaDeXadrez.</param>
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) 
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        /// <summary>
        /// Método para imprimir um conjunto de peças.
        /// </summary>
        /// <param name="conjunto">Define um conjunto de peças.</param>
        public static void ImprimirConjunto(HashSet<Peca> conjunto) 
        {
            Console.Write("[");
            foreach (Peca x in conjunto) 
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        /// <summary>
        /// Método responsável pela impressão o tabuleiro em tela.
        /// </summary>
        /// <param name="tab">Recebe uma instância da classe Tabuleiro.</param>
        public static void ImprimirTabuleiro(Tabuleiro tab) 
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++) 
                {
                    ImprimirPeca(tab.RetornarPeca(i, j));                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        /// <summary>
        /// Sobrecarga de método responsável pela impressão o tabuleiro em tela.
        /// </summary>
        /// <param name="tab">Recebe uma instância da classe Tabuleiro.</param>
        /// <param name="posicoesPossiveis">Defini as posições possíveis no tabuleiro.</param>
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else 
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    ImprimirPeca(tab.RetornarPeca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        /// <summary>
        /// Método para ler posição do xadrez digitada pelo usuário. 
        /// </summary>
        /// <returns></returns>
        public static PosicaoXadrez LerPosicaoXadrez() 
        {
            string s = Console.ReadLine();
            char Coluna = s[0];
            int Linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(Coluna, Linha);
        }

        /// <summary>
        /// Método para imprimir cor da peça.
        /// </summary>
        /// <param name="peca">Recebe uma instância da classe Peca.</param>
        public static void ImprimirPeca(Peca peca) 
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else 
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }            
        }
    }
}

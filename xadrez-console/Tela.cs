using System;
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

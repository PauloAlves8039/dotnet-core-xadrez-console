using System;
using tabuleiro;

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
                    if (tab.RetornarPeca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else 
                    {
                        ImprimirPeca(tab.RetornarPeca(i, j));
                        Console.Write(" ");
                    }                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        /// <summary>
        /// Método para imprimir cor da peça.
        /// </summary>
        /// <param name="peca">Recebe uma instância da classe Peca.</param>
        public static void ImprimirPeca(Peca peca) 
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
        }
    }
}

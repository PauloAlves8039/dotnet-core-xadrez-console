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
                for (int j = 0; j < tab.Colunas; j++) 
                {
                    if (tab.RetornarPeca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else 
                    {
                        Console.Write(tab.RetornarPeca(i, j) + " ");
                    }                    
                }
                Console.WriteLine();
            }
        }
    }
}

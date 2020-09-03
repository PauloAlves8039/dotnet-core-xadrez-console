using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.tabuleiro
{
    /// <summary>
    /// Classe responsável pela atribuição do tabuleiro.
    /// </summary>
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;
    }

    public Tabuleiro(int linhas, int colunas) 
    {
        Linhas = linhas;
        Colunas = colunas;
        Pecas = new Peca[linhas, colunas];
    }
}

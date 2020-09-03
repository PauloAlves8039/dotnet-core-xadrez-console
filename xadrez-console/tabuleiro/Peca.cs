﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    /// <summary>
    /// Classe responsável pela atribuição das peças no tabuleiro associadas as cores e posições. 
    /// </summary>
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; set; }

        public Peca(Posicao posicao, Cor cor, Tabuleiro tabuleiro)
        {
            Posicao = posicao;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QteMovimentos = 0;
        }
    }
}
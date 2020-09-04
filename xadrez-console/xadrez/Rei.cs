﻿using tabuleiro;

namespace xadrez
{
    /// <summary>
    /// Classe responsável por representar a entidade Rei.
    /// </summary>
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
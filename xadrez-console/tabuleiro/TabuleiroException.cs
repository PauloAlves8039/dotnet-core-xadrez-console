using System;

namespace tabuleiro
{
    /// <summary>
    /// Classe responsável por tratamento de exceção personalizada referente a entidade Tabuleiro.
    /// </summary>
    class TabuleiroException : Exception
    {
        public TabuleiroException(string msg) : base(msg)
        {

        }
    }
}

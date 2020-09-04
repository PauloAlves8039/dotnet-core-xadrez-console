using tabuleiro;

namespace xadrez
{
    /// <summary>
    /// Classe responsável por representar a entidade Torre.
    /// </summary>
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univers
{
    public class CorpsCelesteNoyau : CorpsCeleste
    {
        protected int m_noyau; // Rayon du noyau, en km.

        /**
         * Accesseur du rayon en lecture-écriture.
         * Retourne le rayon (en km).
         * Modifie le rayon s'il est positif.
         **/
        public int Noyau
        {
            get { return m_noyau; }
            set { if (value > 0) { m_noyau = value; } }
        }

        // --Overrides--

        /**
         * Comparer les deux corps selon la masse. Retourne -1 si plus petit que celui en paramètre, 0 si égale, 1 si masse est plus grande, 1 si masse égale mais rayon plus grand.
         * Paramètre du corps à comparer.
         **/
        public int CompareTo(Object corpsCelesteNoyau)
        {
            if ((this.Masse < ((CorpsCelesteNoyau)corpsCelesteNoyau).Masse))
                return -1;
            else if (this.Masse > ((CorpsCelesteNoyau)corpsCelesteNoyau).Masse)
                return 1;
            else if ((this.Masse == ((CorpsCelesteNoyau)corpsCelesteNoyau).Masse) && (this.Rayon > ((CorpsCelesteNoyau)corpsCelesteNoyau).Rayon))
                return 1;
            else if ((this.Noyau == ((CorpsCelesteNoyau)corpsCelesteNoyau).Masse) && (this.Rayon == ((CorpsCelesteNoyau)corpsCelesteNoyau).Rayon) && (this.Noyau > ((CorpsCelesteNoyau)corpsCelesteNoyau).Noyau))
                return 1;
            else
                return 0;
        }

        /**
         * Retourner vrai si le corps a les même caractéristiques à celui envoyé en paramètre, faux si il ne l'est pas.
         * Paramètre du corps à comparer.
         **/
        public override bool Equals(Object corpsCelesteNoyau)
        {
            if (this.GetType() == corpsCelesteNoyau.GetType())
            {
                if ((this.Rayon == ((CorpsCelesteNoyau)corpsCelesteNoyau).Rayon) && (this.Nom == ((CorpsCelesteNoyau)corpsCelesteNoyau).Nom) && (this.Masse == ((CorpsCelesteNoyau)corpsCelesteNoyau).Masse) && (this.Noyau == ((CorpsCelesteNoyau)corpsCelesteNoyau).Noyau))
                    return true;
            }

            return false;
        }
    }
}

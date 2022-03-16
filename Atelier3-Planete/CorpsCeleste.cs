/**
* But: Classe CorpsCeleste, qui correspond au parent de tout les corps dans l'espace.
* Auteur: Thomas Laporte
* Date: 14/03/2022 
**/

using System;

namespace Univers
{
    public class CorpsCeleste : ObjetCeleste, IComparable
    {
        const double MASSE_TERRESTRE = 5.9722 * 10e+24; // Constante de la masse terrestre, unité de mesure.

        protected int m_rayon; // Rayon du corps, en km.
        protected double m_masse; // Masse du corps, en masses terrestres.

        public CorpsCeleste() { }

        // --Accesseurs--

        /**
         * Accesseur du rayon en lecture-écriture.
         * Retourne le rayon (en km).
         * Modifie le rayon s'il est positif.
         **/
        public int Rayon
        {
            get { return m_rayon; }
            set { if (value > 0) { m_rayon = value; } }
        }

        /**
         * Accesseur de la masse en lecture-écriture.
         * Retourne la masse (en kg).
         * Modifie la masse si elle est positive.
         **/
        public double Masse
        {
            get { return m_masse * MASSE_TERRESTRE; }
            set { if (value > 0) { m_masse = value; } }
        }

        /**
         * Accesseur de la superficie en lecture.
         * Retourne la superficie (en km).
         **/
        public int Superficie
        {
            get { return (int)(4 * Math.PI * Math.Pow(m_rayon, 2)); }
        }

        /**
         * Accesseur du volume en lecture.
         * Retourne le volume (en km).
         **/
        public long Volume
        {
            get { return (long)(4 * Math.PI * Math.Pow(m_rayon, 3) / 3); }
        }

        /**
        * Accesseur de la masse volumique en lecture.
        * Retourne la masse volumique (en kg/km^3).
        **/
        public double MasseVolumique
        {
            get { if (m_rayon > 0 && m_masse > 0) { return (Masse * MASSE_TERRESTRE / Volume); } else { return 0; } }
        }

        // --Méthodes--

        /**
        * Retourner le corps le plus volumineux.
        * Paramètre du corps à comparer.
        **/
        public CorpsCeleste PlusVolumineux(CorpsCeleste corpsCeleste)
        {
            if (this.Volume > corpsCeleste.Volume)
                return this;

            return corpsCeleste;
        }

        /**
         * Retourner le corps le plus dense (celui avec la plus grande masse volumique).
         * Paramètre du corps à comparer.
         **/
        public CorpsCeleste PlusDense(CorpsCeleste corpsCeleste)
        {
            if (this.MasseVolumique > corpsCeleste.MasseVolumique)
                return this;

            return corpsCeleste;
        }

        // --Overrides--

        /**
         * Comparer les deux corps selon la masse. Retourne -1 si plus petit que celui en paramètre, 0 si égale, 1 si masse est plus grande, 1 si masse égale mais rayon plus grand.
         * Paramètre du corps à comparer.
         **/
        public int CompareTo(Object corpsCeleste)
        {
            if ((this.Masse < ((CorpsCeleste)corpsCeleste).Masse))
                return -1;
            else if (this.Masse > ((CorpsCeleste)corpsCeleste).Masse)
                return 1;
            else if ((this.Masse == ((CorpsCeleste)corpsCeleste).Masse) && (this.Rayon > ((CorpsCeleste)corpsCeleste).Rayon))
                return 1;
            else
                return 0;
        }

        /**
         * Retourner vrai si le corps a les même caractéristiques à celui envoyé en paramètre, faux si il ne l'est pas.
         * Paramètre du corps à comparer.
         **/
        public override bool Equals(Object corpsCeleste)
        {
            if(this.GetType() == corpsCeleste.GetType())
            {
                if ((this.Rayon == ((CorpsCeleste)corpsCeleste).Rayon) && (this.Nom == ((CorpsCeleste)corpsCeleste).Nom) && (this.Masse == ((CorpsCeleste)corpsCeleste).Masse))
                    return true;
            }

            return false;
        }

        /**
         * Retourner l'indice du corps en paramètre dans le tableau de corps en paramètre. Retourne -1 si pas trouvé.
         * Paramètre du corps à trouver et le tableau dans lequel chercher.
         **/
        public static int IndexOf(CorpsCeleste[] corpsCelestes, CorpsCeleste corpsCeleste)
        {
            for (int i = 0; i < corpsCelestes.Length; i++)
            {
                if (corpsCeleste.Equals(corpsCelestes[i]))
                    return i;
            }
            return -1;
        }

        // --Opérateurs de comparaison--

        /**
         * Retourner (en utilisant le Equals) vrai si les deux corps sont équivalents, sinon faux.
         **/
        public static bool operator ==(CorpsCeleste corpsGauche, CorpsCeleste corpsDroit)
        {
            return corpsGauche.Equals(corpsDroit);
        }

        /**
         * Retourner (en utilisant le Equals) vrai si les deux planètessi les deux corps ne sont pas équivalents, sinon faux.
         **/
        public static bool operator !=(CorpsCeleste corpsGauche, CorpsCeleste corpsDroit)
        {
            if (corpsGauche.Equals(corpsDroit))
                return false;
            else
                return true;
        }

        /**
         * Retourner (en utilisant le CompareTo) vrai si le corps de gauche est plus grand, sinon faux.
         **/
        public static bool operator >(CorpsCeleste corpsGauche, CorpsCeleste corpsDroit)
        {
            if (corpsGauche.CompareTo(corpsDroit) == 1)
                return true;
            return false;
        }

        /**
         * Retourner (en utilisant le CompareTo) vrai si le corps de droite est plus grande, sinon faux.
         **/
        public static bool operator <(CorpsCeleste corpsGauche, CorpsCeleste corpsDroit)
        {
            if (corpsGauche.CompareTo(corpsDroit) == -1)
                return true;
            return false;
        }

        /**
         * Retourner (en utilisant le CompareTo) vrai si le corps de gauche est plus grand ou égal, sinon faux.
         **/
        public static bool operator >=(CorpsCeleste corpsGauche, CorpsCeleste corpsDroit)
        {
            if (corpsGauche.CompareTo(corpsDroit) == 1 || corpsGauche.Equals(corpsDroit))
                return true;
            return false;
        }

        /**
         * Retourner (en utilisant le CompareTo) vrai si le corps de droite est plus grande ou égal, sinon faux.
         **/
        public static bool operator <=(CorpsCeleste corpsGauche, CorpsCeleste corpsDroit)
        {
            if (corpsGauche.CompareTo(corpsDroit) == -1 || corpsGauche.Equals(corpsDroit))
                return true;
            return false;
        }
    }
}

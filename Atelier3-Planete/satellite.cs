using System;

namespace Atelier3_Planete
{
    public class Satellite : IComparable
    {
        const double MASSE_TERRESTRE = 5.9722 * 10e+24; // Constante de la masse terrestre, unité de mesure.

        private String m_nom; // Nom du satellite.
        private int m_rayon; // Rayon du satellite, en km.
        private double m_masse; // Masse du satellite, en masses terrestres.

        // --Constructeurs--

        /**
         * Constructeur avec le nom seulement.
         * Paramètre est le nom en String.
         **/
        public Satellite(String nom)
        {
            m_nom = nom.Trim();
        }

        /**
         * Constructeur avec le nom et la rayon.
         * Paramètres sont le nom en String et le rayon en int.
         * On vérifie que le rayon est positif.
         **/
        public Satellite(String nom, int rayon)
        {
            m_nom = nom.Trim();

            if (rayon > 0)
                m_rayon = rayon;
        }

        /**
         * Constructeur avec le nom et la rayon.
         * Paramètres sont le nom en String, le rayon en int et la masse en double.
         * On vérifie que le rayon et la masse sont positifs.
         **/
        public Satellite(String nom, int rayon, double masse)
        {
            m_nom = nom.Trim();

            if (rayon > 0)
                m_rayon = rayon;

            if (masse > 0)
                m_masse = masse;
        }

        // --Accesseurs--

        /**
         * Accesseur du nom en lecture-écriture.
         * Retourne le nom.
         * Modifie le nom si le nombre de caractère est positif.
         **/
        public String Nom
        {
            get { return m_nom; }
            set { if (value.Length > 0) { m_nom = value.Trim(); } }
        }

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
        * Retourner le satellite le plus volumineux.
        * Paramètre du satellite à comparer.
        **/
        public Satellite PlusVolumineuse(Satellite satellite)
        {
            if (this.Volume > satellite.Volume)
                return this;

            return satellite;
        }

        /**
         * Retourner le satellite le plus dense (celui avec la plus grande masse volumique).
         * Paramètre du satellite à comparer.
         **/
        public Satellite PlusDense(Satellite satellite)
        {
            if (this.MasseVolumique > satellite.MasseVolumique)
                return this;

            return satellite;
        }

        // --Overrides--

        /**
         * Comparer les deux satellites selon la masse. Retourne -1 si plus petit que celui en paramètre, 0 si égale, 1 si masse est plus grande, 1 si masse égale mais rayon plus grand.
         * Paramètre du satellite à comparer.
         **/
        public int CompareTo(Object satellite)
        {
            if ((this.Masse < ((Satellite)satellite).Masse))
                return -1;
            else if (this.Masse > ((Satellite)satellite).Masse)
                return 1;
            else if ((this.Masse == ((Satellite)satellite).Masse) && (this.Rayon > ((Satellite)satellite).Rayon))
                return 1;
            else
                return 0;
        }

        /**
         * Retourner vrai si le satellite a les même caractéristiques à celui envoyé en paramètre, faux si il ne l'est pas.
         * Paramètre du satellite à comparer.
         **/
        public override bool Equals(Object satellite)
        {
            if ((this.Rayon == ((Satellite)satellite).Rayon) && (this.Nom == ((Satellite)satellite).Nom) && (this.Masse == ((Satellite)satellite).Masse))
                return true;

            return false;
        }

        /**
         * Retourner l'indice du satellite en paramètre dans le tableau de satellites en paramètre. Retourne -1 si pas trouvé.
         * Paramètre du satellite à trouver et le tableau dans lequel chercher.
         **/
        public static int IndexOf(Satellite[] satellites, Satellite satellite)
        {
            for (int i = 0; i < satellites.Length; i++)
            {
                if (satellite.Equals(satellites[i]))
                    return i;
            }
            return -1;
        }

        /**
         * Retourner les informations du satellite sous forme de chaine de caractères.
         **/
        public override String ToString()
        {
            String informations; // Chaine de caractère qui contient toutes les informations sur la planète.

            informations = "Nom : " + this.Nom;

            if (this.Rayon != 0)
            {
                informations += "\nRayon : " + this.Rayon + " km";
                informations += "\nSuperficie : " + this.Superficie + " km^2";
                informations += "\nVolume : " + this.Volume + " km^3";
            }

            if (this.Masse != 0)
            {
                informations += "\nMasse : " + this.Masse + " kg";
                if (this.Rayon != 0)
                    informations += "\nMasse volumique : " + this.MasseVolumique + " kg/km^3";
            }

            return informations;
        }

        // --Opérateurs de comparaison--

        /**
         * Retourner (en utilisant le Equals) vrai si les deux satellites sont équivalents, sinon faux.
         **/
        public static bool operator ==(Satellite satelliteGauche, Satellite satelliteDroite)
        {
            return satelliteGauche.Equals(satelliteDroite);
        }

        /**
         * Retourner (en utilisant le Equals) vrai si les deux satellites ne sont pas équivalents, sinon faux.
         **/
        public static bool operator !=(Satellite satelliteGauche, Satellite satelliteDroite)
        {
            if (satelliteGauche.Equals(satelliteDroite))
                return false;
            else
                return true;
        }

        /**
         * Retourner (en utilisant le CompareTo) vrai si le satellite de gauche est plus grand, sinon faux.
         **/
        public static bool operator >(Satellite satelliteGauche, Satellite satelliteDroite)
        {
            if (satelliteGauche.CompareTo(satelliteDroite) == 1)
                return true;
            return false;
        }

        /**
         * Retourner (en utilisant le CompareTo) vrai si le satellite de droite est plus grand ou égal, sinon faux.
         **/
        public static bool operator <(Satellite satelliteGauche, Satellite satelliteDroite)
        {
            if (satelliteGauche.CompareTo(satelliteDroite) == -1)
                return true;
            return false;
        }

        /**
         * Retourner (en utilisant le CompareTo) vrai si le satellite de gauche est plus grand ou égal, sinon faux.
         **/
        public static bool operator >=(Satellite satelliteGauche, Satellite satelliteDroite)
        {
            if (satelliteGauche.CompareTo(satelliteDroite) == 1 || satelliteGauche.Equals(satelliteDroite))
                return true;
            return false;
        }

        /**
         * Retourner (en utilisant le CompareTo) vrai si le satellite de droite est plus grand ou égal, sinon faux.
         **/
        public static bool operator <=(Satellite satelliteGauche, Satellite satelliteDroite)
        {
            if (satelliteGauche.CompareTo(satelliteDroite) == -1 || satelliteGauche.Equals(satelliteDroite))
                return true;
            return false;
        }

        // --Opérateurs arithmétiques--

        /**
         * Retourner un nouveau satellite en additionnant les caractéristiques des deux satellites (nom, rayon et masse).
         **/
        public static Satellite operator +(Satellite satelliteGauche, Satellite satelliteDroite)
        {
            return new Satellite(satelliteGauche.Nom + "Plus" + satelliteDroite.Nom, satelliteGauche.Rayon + satelliteDroite.Rayon, satelliteGauche.Masse + satelliteDroite.Masse);
        }

        /**
         * Retourner un nouveau satellite en soustrayant les caractéristiques des deux satellites (nom, rayon et masse), mettre à 0 les caractéristiques si celles du satellite de gauche sont plus petites.
         **/
        public static Satellite operator -(Satellite satelliteGauche, Satellite satelliteDroite)
        {
            int nouveauRayon = 0; // Nouveau rayon
            double nouvelleMasse = 0; // Nouvelle masse

            if (satelliteGauche.m_rayon > satelliteDroite.m_rayon)
                nouveauRayon = satelliteGauche.m_rayon - satelliteDroite.m_rayon;

            if (satelliteGauche.m_masse > satelliteDroite.m_masse)
                nouvelleMasse = satelliteGauche.m_masse - satelliteDroite.m_masse;

            return new Satellite(satelliteGauche.Nom + "Moins" + satelliteDroite.Nom, nouveauRayon, nouvelleMasse);
        }
    }
}

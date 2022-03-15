using System;

namespace Univers
{
    public class Satellite : CorpsCeleste
    {
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

        // --Méthodes--

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

        // --Opérateurs arithmétiques--

        /**
         * Retourner un nouveau satellite en additionnant les caractéristiques des deux (nom, rayon et masse).
         **/
        public static Satellite operator +(Satellite satelliteGauche, Satellite satelliteDroit)
        {
            return new Satellite(satelliteGauche.Nom + "Plus" + satelliteDroit.Nom, satelliteGauche.Rayon + satelliteDroit.Rayon, satelliteGauche.Masse + satelliteDroit.Masse);
        }

        /**
         * Retourner un nouveau satellite en soustrayant les caractéristiques des deux  (nom, rayon et masse), mettre à 0 les caractéristiques si celles du satellite de gauche sont plus petites.
         **/
        public static Satellite operator -(Satellite satelliteGauche, Satellite satelliteDroit)
        {
            int nouveauRayon = 0; // Nouveau rayon
            double nouvelleMasse = 0; // Nouvelle masse

            if (satelliteGauche.m_rayon > satelliteDroit.m_rayon)
                nouveauRayon = satelliteGauche.m_rayon - satelliteDroit.m_rayon;

            if (satelliteGauche.m_masse > satelliteDroit.m_masse)
                nouvelleMasse = satelliteGauche.m_masse - satelliteDroit.m_masse;

            return new Satellite(satelliteGauche.Nom + "Moins" + satelliteDroit.Nom, nouveauRayon, nouvelleMasse);
        }
    }
}

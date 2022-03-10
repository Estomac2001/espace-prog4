/**
* But: Classe Planete, qui contient et retourne les caractéristiques physiques et des méthodes de comparaison.
* Auteur: Thomas Laporte
* Date: 23/02/2022 
**/

using System;
using System.Collections.Generic;

namespace Atelier3_Planete
{
    public class Planete : IComparable
    {
        const double MASSE_TERRESTRE = 5.9722 * 10e+24; // Constante de la masse terrestre, unité de mesure.

        private String m_nom; // Nom de la planète.
        private int m_rayon; // Rayon de la planète, en km.
        private double m_masse; // Masse de la planète, en masses terrestres.
        private List<Satellite> m_satellites; // Liste des satellites de la planète.

        // --Constructeurs--

        /**
         * Constructeur avec le nom seulement.
         * Paramètre est le nom en String.
         **/
        public Planete(String nom)
        {
            m_nom = nom.Trim();
        }

        /**
         * Constructeur avec le nom et la rayon.
         * Paramètres sont le nom en String et le rayon en int.
         * On vérifie que le rayon est positif.
         **/
        public Planete(String nom, int rayon)
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
        public Planete(String nom, int rayon, double masse)
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

        /**
         * Accesseur des satellites en lecture-écriture.
         * Retourne le satellite à l'indice envoyé.
         * Modifie le satellite à l'indice envoyé.
         * Ajoute le satellite à la fin de la liste.
         **/
        public Satellite this[int i]
        {
            get { if (m_satellites != null && i < m_satellites.Count && i >= 0) { return m_satellites[i]; }  else { return null; } }
            set { if (m_satellites == null) { m_satellites = new List<Satellite>() { value }; } else if (i < m_satellites.Count && i >= 0) { m_satellites[i] = value; } else { m_satellites.Add(value); } }
        }

        // --Méthodes--

        /**
        * Retourner la planète la plus volumineuse.
        * Paramètre de la planète à comparer.
        **/
        public Planete PlusVolumineuse(Planete planete)
        {
            if (this.Volume > planete.Volume)
                return this;

            return planete;
        }

        /**
         * Retourner la planète la plus dense (celle avec la plus grande masse volumique).
         * Paramètre de la planète à comparer.
         **/
        public Planete PlusDense(Planete planete)
        {
            if (this.MasseVolumique > planete.MasseVolumique)
                return this;

            return planete;
        }

        // --Overrides--

        /**
         * Comparer les deux planètes selon la masse. Retourne -1 si plus petite que celle en paramètre, 0 si égale, 1 si masse est plus grande, 1 si masse égale mais rayon plus grand.
         * Paramètre de la planète à comparer.
         **/
        public int CompareTo(Object planete)
        {
            if ((this.Masse < ((Planete)planete).Masse))
                return -1;
            else if (this.Masse > ((Planete)planete).Masse)
                return 1;
            else if ((this.Masse == ((Planete)planete).Masse) && (this.Rayon > ((Planete)planete).Rayon))
                return 1;
            else
                return 0;
        }

        /**
         * Retourner vrai si la planète a les même caractéristiques à celle envoyée en paramètre, faux si elle ne l'est pas.
         * Paramètre de la planète à comparer.
         **/
        public override bool Equals(Object planete)
        {
            if ((this.Rayon == ((Planete)planete).Rayon) && (this.Nom == ((Planete)planete).Nom) && (this.Masse == ((Planete)planete).Masse))
                return true;

            return false;
        }

        /**
         * Retourner l'indice de la planète en paramètre dans le tableau de planète en paramètre. Retourne -1 si pas trouvée.
         * Paramètre de la planète à trouver et la tableau dans lequel chercher.
         **/
        public static int IndexOf(Planete[] planetes, Planete planete)
        {
            for (int i = 0; i < planetes.Length; i++)
            {
                if(planete.Equals(planetes[i]))
                    return i;
            }
            return -1;
        }

        /**
         * Retourner les informations de la planète sous forme de chaine de caractères.
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
         * Retourner (en utilisant le Equals) vrai si les deux planètes sont équivalentes, sinon faux.
         **/
        public static bool operator == (Planete planeteGauche, Planete planeteDroite)
        {
            return planeteGauche.Equals(planeteDroite);
        }

        /**
         * Retourner (en utilisant le Equals) vrai si les deux planètes ne sont pas équivalentes, sinon faux.
         **/
        public static bool operator != (Planete planeteGauche, Planete planeteDroite)
        {
            if (planeteGauche.Equals(planeteDroite))
                return false;
            else 
                return true;
        }

        /**
         * Retourner (en utilisant le CompareTo) vrai si la planète de gauche est plus grande, sinon faux.
         **/
        public static bool operator > (Planete planeteGauche, Planete planeteDroite)
        {
            if (planeteGauche.CompareTo(planeteDroite) == 1)
                return true;
            return false;
        }

        /**
         * Retourner (en utilisant le CompareTo) vrai si la planète de droite est plus grande ou égale, sinon faux.
         **/
        public static bool operator < (Planete planeteGauche, Planete planeteDroite)
        {
            if (planeteGauche.CompareTo(planeteDroite) == -1)
                return true;
            return false;
        }

        /**
         * Retourner (en utilisant le CompareTo) vrai si la planète de gauche est plus grande ou égale, sinon faux.
         **/
        public static bool operator >= (Planete planeteGauche, Planete planeteDroite)
        {
            if (planeteGauche.CompareTo(planeteDroite) == 1 || planeteGauche.Equals(planeteDroite))
                return true;
            return false;
        }

        /**
         * Retourner (en utilisant le CompareTo) vrai si la planète de droite est plus grande ou égale, sinon faux.
         **/
        public static bool operator <= (Planete planeteGauche, Planete planeteDroite)
        {
            if (planeteGauche.CompareTo(planeteDroite) == -1 || planeteGauche.Equals(planeteDroite))
                return true;
            return false;
        }

        // --Opérateurs arithmétiques--

        /**
         * Retourner une nouvelle planète en additionnant les caractéristiques des deux planètes (nom, rayon et masse).
         **/
        public static Planete operator + (Planete planeteGauche, Planete planeteDroite)
        {
            return new Planete(planeteGauche.Nom + "Plus" + planeteDroite.Nom, planeteGauche.Rayon + planeteDroite.Rayon, planeteGauche.Masse + planeteDroite.Masse);
        }

        /**
         * Retourner une nouvelle planète en soustrayant les caractéristiques des deux planètes (nom, rayon et masse), mettre à 0 les caractéristiques si celles de la planète de gauche sont plus petites.
         **/
        public static Planete operator - (Planete planeteGauche, Planete planeteDroite)
        {
            int nouveauRayon = 0; // Nouveau rayon
            double nouvelleMasse = 0; // Nouvelle masse

            if (planeteGauche.m_rayon > planeteDroite.m_rayon)
                nouveauRayon = planeteGauche.m_rayon - planeteDroite.m_rayon;

            if (planeteGauche.m_masse > planeteDroite.m_masse)
                nouvelleMasse = planeteGauche.m_masse - planeteDroite.m_masse;

            return new Planete(planeteGauche.Nom + "Moins" + planeteDroite.Nom, nouveauRayon, nouvelleMasse);
        }
    }
}
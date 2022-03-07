/**
* But: Classe Planete, qui contient et retourne les caractéristiques physiques et des méthodes de comparaison.
* Auteur: Thomas Laporte
* Date: 23/02/2022 
**/

using System;
using System.Collections.Generic;

namespace Atelier3_Planete
{
    class Planete
    {
        const double MASSE_TERRESTRE = 5.9722 * 10e+24; // Constante de la masse terrestre, unité de mesure.

        private String m_nom; // Nom de la planète.
        private int m_rayon; // Rayon de la planète, en km.
        private double m_masse; // Masse de la planète, en masses terrestres.
        private List<string> satellites;

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
    }
}
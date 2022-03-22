/**
* But: Classe Etoile, qui contient et retourne les caractéristiques physiques et des méthodes de comparaison.
* Auteur: Thomas Laporte
* Date: 22/03/2022 
**/

using System;
using System.Collections.Generic;

namespace Univers
{
    public class Etoile : CorpsCelesteNoyau
    {
        private int m_couronne;
        private Galaxie m_parent;
        private List<Planete> m_planetes; // Liste des planetes de l'étoile.

        // --Constructeurs--

        /**
         * Constructeur avec le nom seulement.
         * Paramètre est le nom en String.
         **/
        public Etoile(String nom)
        {
            m_nom = nom.Trim();
        }

        /**
         * Constructeur avec le nom et la rayon.
         * Paramètres sont le nom en String et le rayon en int.
         * On vérifie que le rayon est positif.
         **/
        public Etoile(String nom, int rayon)
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
        public Etoile(String nom, int rayon, double masse)
        {
            m_nom = nom.Trim();

            if (rayon > 0)
                m_rayon = rayon;

            if (masse > 0)
                m_masse = masse;
        }

        /**
         * Constructeur avec le nom et la rayon, masse et couronne.
         * Paramètres sont le nom en String, le rayon en int et la masse en double.
         * On vérifie que le rayon et la masse sont positifs.
         **/
        public Etoile(String nom, int rayon, double masse, int couronne)
        {
            m_nom = nom.Trim();

            if (rayon > 0)
                m_rayon = rayon;

            if (masse > 0)
                m_masse = masse;

            if (couronne > 0)
                m_couronne = couronne;
        }

        /**
         * Constructeur avec le nom et la rayon, masse et couronne.
         * Paramètres sont le nom en String, le rayon en int et la masse en double.
         * On vérifie que le rayon et la masse sont positifs.
         **/
        public Etoile(String nom, int rayon, double masse, int couronne, int noyau)
        {
            m_nom = nom.Trim();

            if (rayon > 0)
                m_rayon = rayon;

            if (masse > 0)
                m_masse = masse;

            if (couronne > 0)
                m_couronne = couronne;

            if (noyau > 0)
                m_couronne = noyau;
        }

        // --Accesseurs--

        /**
         * Accesseur des planètes en lecture-écriture.
         * Retourne la planète à l'indice envoyé.
         **/
        public Planete this[int i]
        {
            get { if (m_planetes != null && i < m_planetes.Count && i >= 0) { return m_planetes[i]; } else { return null; } }
        }

        /**
         * Ajouter la planète à la fin de la liste.
         * Si la liste est vide, créer un liste et ajouter le satellite.
         **/
        public void ajouterPlanete(Planete newPlanete)
        {
            if (m_planetes == null)
            {
                newPlanete.Parent = this;
                m_planetes = new List<Planete>() { newPlanete };
            }
            else
            {
                newPlanete.Parent = this;
                m_planetes.Add(newPlanete);
            }

        }

        /**
         * Accesseur du parent en lecture-écriture.
         * Retourne le parent.
         * Modifie le parent.
         **/
        public Galaxie Parent
        {
            get { return m_parent; }
            set { m_parent = value; }
        }

        /**
         * Accesseur de la couronne en lecture-écriture.
         * Retourne la couronne (en km).
         * Modifie la couronne si elle est positive.
         **/
        public int Couronne
        {
            get { return m_couronne; }
            set { if (value > 0) { m_couronne = value; } }
        }

        // --Méthodes et overrides--

        /**
         * Retourner les informations de la planète sous forme de chaine de caractères.
         **/
        public override String ToString()
        {
            String informations; // Chaine de caractère qui contient toutes les informations sur la planète.

            informations = "Nom : " + this.Nom;

            if (this.Noyau != 0)
            {
                informations += "\nNoyau : " + this.Noyau + " km";
            }

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

            if (this.Couronne != 0)
            {
                informations += "\nCouronne : " + this.Couronne + " km";
            }

            return informations;
        }

        // --Opérateurs arithmétiques--

        /**
         * Retourner une nouvelle étoile en additionnant les caractéristiques des deux (nom, rayon et masse).
         **/
        public static Etoile operator +(Etoile etoileGauche, Etoile etoileDroite)
        {
            return new Etoile(etoileGauche.Nom + "Plus" + etoileDroite.Nom, etoileGauche.Rayon + etoileDroite.Rayon, etoileGauche.Masse + etoileDroite.Masse, etoileGauche.Couronne + etoileDroite.Couronne, etoileGauche.Noyau + etoileDroite.Noyau);
        }

        /**
         * Retourner une nouvelle étoile en soustrayant les caractéristiques des deux (nom, rayon et masse), mettre à 0 les caractéristiques si celles du corps de gauche sont plus petites.
         **/
        public static Etoile operator -(Etoile etoileGauche, Etoile etoileDroite)
        {
            int nouveauRayon = 0; // Nouveau rayon
            double nouvelleMasse = 0; // Nouvelle masse
            int nouvelleCouronne = 0; // Nouveau rayon
            int nouveauNoyau = 0; // Nouveau rayon

            if (etoileGauche.m_rayon > etoileDroite.m_rayon)
                nouveauRayon = etoileGauche.m_rayon - etoileDroite.m_rayon;

            if (etoileGauche.m_masse > etoileDroite.m_masse)
                nouvelleMasse = etoileGauche.m_masse - etoileDroite.m_masse;

            if (etoileGauche.m_couronne > etoileDroite.m_couronne)
                nouvelleCouronne = etoileGauche.m_couronne - etoileDroite.m_couronne;

            if (etoileGauche.m_noyau > etoileDroite.m_noyau)
                nouveauNoyau = etoileGauche.m_noyau - etoileDroite.m_noyau;

            return new Etoile(etoileGauche.Nom + "Moins" + etoileDroite.Nom, nouveauRayon, nouvelleMasse, nouvelleCouronne, nouveauNoyau);
        }

    }
}

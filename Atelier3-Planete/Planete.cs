/**
* But: Classe Planete, qui contient et retourne les caractéristiques physiques et des méthodes de comparaison.
* Auteur: Thomas Laporte
* Date: 23/02/2022 
**/

using System;
using System.Collections.Generic;

namespace Univers
{
    public class Planete : CorpsCelesteNoyau, IComparable
    {
        private Etoile m_parent;
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

        /**
         * Constructeur avec le nom et la rayon et noyau.
         * Paramètres sont le nom en String, le rayon en int et la masse en double et noyau.
         * On vérifie que le rayon et la masse et le noyau sont positifs.
         **/
        public Planete(String nom, int rayon, double masse, int noyau)
        {
            m_nom = nom.Trim();

            if (rayon > 0)
                m_rayon = rayon;

            if (masse > 0)
                m_masse = masse;

            if (noyau > 0)
                m_noyau = noyau;
        }

        // --Accesseurs--

        /**
         * Accesseur des satellites en lecture-écriture.
         * Retourne le satellite à l'indice envoyé.
         **/
        public Satellite this[int i]
        {
            get { if (m_satellites != null && i < m_satellites.Count && i >= 0) { return m_satellites[i]; }  else { return null; } }
        }

        /**
         * Accesseur du parent en lecture-écriture.
         * Retourne le parent.
         * Modifie le parent.
         **/
        public Etoile Parent
        {
            get { return m_parent; }
            set { m_parent = value; }
        }

        /**
         * Ajouter le satellite à la fin de la liste.
         * Si la liste est vide, créer un liste et ajouter le satellite.
         **/
        public void ajouterSatellite(Satellite newSatellite)
        {
            if (m_satellites == null)
            {
                newSatellite.Parent = this;
                m_satellites = new List<Satellite>() { newSatellite };
            }
            else
            {
                newSatellite.Parent = this;
                m_satellites.Add(newSatellite);
            }
               
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

            return informations;
        }

        // --Opérateurs arithmétiques--

        /**
         * Retourner une nouvelle planète en additionnant les caractéristiques des deux (nom, rayon et masse).
         **/
        public static Planete operator +(Planete planeteGauche, Planete planeteDroite)
        {
            return new Planete(planeteGauche.Nom + "Plus" + planeteDroite.Nom, planeteGauche.Rayon + planeteDroite.Rayon, planeteGauche.Masse + planeteDroite.Masse, planeteGauche.Noyau + planeteDroite.Noyau);
        }

        /**
         * Retourner une nouvelle planète en soustrayant les caractéristiques des deux  (nom, rayon et masse), mettre à 0 les caractéristiques si celles du corps de gauche sont plus petites.
         **/
        public static Planete operator -(Planete planeteGauche, Planete planeteDroite)
        {
            int nouveauRayon = 0; // Nouveau rayon
            double nouvelleMasse = 0; // Nouvelle masse
            int nouveauNoyau = 0; // Nouveau rayon

            if (planeteGauche.m_rayon > planeteDroite.m_rayon)
                nouveauRayon = planeteGauche.m_rayon - planeteDroite.m_rayon;

            if (planeteGauche.m_masse > planeteDroite.m_masse)
                nouvelleMasse = planeteGauche.m_masse - planeteDroite.m_masse;

            if (planeteGauche.m_noyau > planeteDroite.m_noyau)
                nouveauNoyau = planeteGauche.m_noyau - planeteDroite.m_noyau;

            return new Planete(planeteGauche.Nom + "Moins" + planeteDroite.Nom, nouveauRayon, nouvelleMasse, nouveauNoyau);
        }
    }
}
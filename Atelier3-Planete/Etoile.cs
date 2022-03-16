﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univers
{
    public class Etoile : CorpsCeleste
    {
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

        // --Accesseurs--

        /**
         * Accesseur des satellites en lecture-écriture.
         * Retourne le satellite à l'indice envoyé.
         * Modifie le satellite à l'indice envoyé.
         * Ajoute le satellite à la fin de la liste.
         **/
        public Planete this[int i]
        {
            get { if (m_planetes != null && i < m_planetes.Count && i >= 0) { return m_planetes[i]; } else { return null; } }
        }

        /**
         * Ajouter le satellite à la fin de la liste.
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

        // --Méthodes et overrides--

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

        // --Opérateurs arithmétiques--

        /**
         * Retourner une nouvelle planète en additionnant les caractéristiques des deux (nom, rayon et masse).
         **/
        public static Planete operator +(Planete planeteGauche, Planete planeteDroite)
        {
            return new Planete(planeteGauche.Nom + "Plus" + planeteDroite.Nom, planeteGauche.Rayon + planeteDroite.Rayon, planeteGauche.Masse + planeteDroite.Masse);
        }

        /**
         * Retourner une nouvelle planète en soustrayant les caractéristiques des deux  (nom, rayon et masse), mettre à 0 les caractéristiques si celles du corps de gauche sont plus petites.
         **/
        public static Planete operator -(Planete planeteGauche, Planete planeteDroite)
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
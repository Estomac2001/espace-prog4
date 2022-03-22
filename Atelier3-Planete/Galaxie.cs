/**
* But: Classe Galaxie, qui contient et retourne les caractéristiques physiques et des méthodes de comparaison.
* Auteur: Thomas Laporte
* Date: 22/03/2022 
**/

using System;
using System.Collections.Generic;

namespace Univers
{
    public class Galaxie : ObjetCeleste
    {
        private List<Etoile> m_etoiles; // Liste des planetes de la galaxie.

        // --Constructeurs--

        /**
         * Constructeur avec le nom seulement.
         * Paramètre est le nom en String.
         **/
        public Galaxie(String nom)
        {
            m_nom = nom.Trim();
        }

        // --Accesseurs--

        /**
         * Accesseur des étoiles en lecture-écriture.
         * Retourne l'étoile à l'indice envoyé.
         **/
        public Etoile this[int i]
        {
            get { if (m_etoiles != null && i < m_etoiles.Count && i >= 0) { return m_etoiles[i]; } else { return null; } }
        }

        /**
         * Ajouter l'étoile à la fin de la liste.
         * Si la liste est vide, créer un liste et ajouter l'étoile.
         **/
        public void ajouterEtoile(Etoile newEtoile)
        {
            if (m_etoiles == null)
            {
                newEtoile.Parent = this;
                m_etoiles = new List<Etoile>() { newEtoile };
            }
            else
            {
                newEtoile.Parent = this;
                m_etoiles.Add(newEtoile);
            }

        }
    }
}

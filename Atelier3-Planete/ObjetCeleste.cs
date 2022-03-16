/**
* But: Classe ObjetCeleste, qui correspond au parent de tout ce qui a dans l'espace. Contient seulement le nom.
* Auteur: Thomas Laporte
* Date: 14/03/2022 
**/

using System;

namespace Univers
{
    public class ObjetCeleste
    {
        protected String m_nom; // Nom du corps céleste.

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
    }
}

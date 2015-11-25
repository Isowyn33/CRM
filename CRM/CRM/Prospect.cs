using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Prospect
    {
        private int Id;
        private String Nom;
        private String Prenom;
        private String Adresse;
        private int CodePostal;
        private int Telephone;

        public Prospect(int theId, String theNom, String thePrenom, String theAdresse, int theCodePostal, int theTelephone)
        {
            Id = theId;
            Nom = theNom;
            Prenom = thePrenom;
            Adresse = theAdresse;
            CodePostal = theCodePostal;
            Telephone = theTelephone;
        }

        public int getId()
        {
            return Id;
        }

        public String getNom()
        {
            return Nom;
        }

        public String getPrenom()
        {
            return Prenom;
        }

        public String getAdresse()
        {
            return Adresse;
        }

        public int getCodePostal()
        {
            return CodePostal;
        }

        public int getTelephone()
        {
            return Telephone;
        }

    }
}

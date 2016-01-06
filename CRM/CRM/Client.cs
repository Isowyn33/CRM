using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    public class Client
    {
        private int Id;
        private String Nom;
        private String Prenom;
        private String Adresse;
        private int CodePostal;
        private int Telephone;

        public Client(int theId, String theNom, String thePrenom, String theAdresse, int theCodePostal, int theTelephone)
        {
            Id = theId;
            Nom = theNom;
            Prenom = thePrenom;
            Adresse = theAdresse;
            CodePostal = theCodePostal;
            Telephone = theTelephone;
        }

        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public String NOM
        {
            get { return Nom; }
            set { Nom = value; }
        }

        public String PRENOM
        {
            get { return Prenom; }
            set { Prenom = value; }
        }

        public String ADRESSE
        {
            get { return Adresse; }
            set { Adresse = value; }
        }

        public int CP
        {
            get { return CodePostal; }
            set { CodePostal = value; }
        }

        public int TEL
        {
            get { return Telephone; }
            set { Telephone = value; }
        }

    }
}

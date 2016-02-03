using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
   public class Historique
    {
        private int Id;
        private String Date;
        private String Libelle;
        private int IdClientt;
        
        public Historique(int theId, String theDate, int theIdClient, String theLibelle)
        {
            Id = theId;
            Date = theDate;
            IdClientt = theIdClient;
            Libelle = theLibelle;
        }

        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public String DATE
        {
            get { return Date; }
            set { Date = value; }
        }

        public int IDCLIENT
        {
            get { return IdClientt; }
            set { IdClientt = value; }
        }

        public String LIBELLE
        {
            get { return Libelle; }
            set { Libelle = value; }
        }

    }
}

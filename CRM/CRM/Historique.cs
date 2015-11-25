using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Historique
    {
        private int Id;
        private DateTime Date;
        private int IdClient;
        private String Libelle;
        
        public Historique(int theId, DateTime theDate, int theIdClient, String theLibelle)
        {
            Id = theId;
            Date = theDate;
            IdClient = theIdClient;
            Libelle = theLibelle;
        }

    }
}

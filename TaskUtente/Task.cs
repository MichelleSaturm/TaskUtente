using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUtente
{
    //    I tasks sono oggetti che possiedono: 
    //- una descrizione
    //- una data di scadenza
    //- un livello di priorità(Alto, Medio, Basso)

    class Task
    {
        public string Descrizione { get; set; }
        public DateTime Data { get; set; }
        public LivelloPriorità Priorità { get; set; }


        public Task()
        {

        }

        public enum LivelloPriorità
        {
            Alta = 1,
            Media = 2,
            Bassa = 3
        }
    }
}

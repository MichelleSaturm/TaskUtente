using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskUtente.Task;

namespace TaskUtente
{

    //    L’utente può: 
    //- Visualizzare i tasks; 
    //- Aggiungere nuovi tasks; 
    //- Eliminare i tasks; 
    //- Filtrare i task per importanza; 
    //Un nuovo task può essere aggiunto solo se la sua data di scadenza è posteriore alla data di  inserimento del task.


    class TaskManager
    {
        static List<Task> impegni = new List<Task>();
        static string path = @"C:\Users\princ\OneDrive\Desktop\Test\Test_09072021\TaskUtente\GestioneTask.txt";

        //Agguunta Impegni
        public static void AggiungiTask()
        {
            Task task = new Task();
            Console.WriteLine();
            Console.WriteLine("Inserisci la Descrizione:");
            task.Descrizione = Console.ReadLine();

            Console.WriteLine("Inserisci la Data:");
            bool notToday;
            DateTime data = new DateTime();
            do
            {
                notToday = DateTime.TryParse(Console.ReadLine(), out data);
            } while (!notToday || data <= DateTime.Now);

            task.Data = data;

            Console.WriteLine("Inserisci la Priorità:");
            task.Priorità = InserisciPriorità();

            impegni.Add(task);
        }

        //Scelta del livello di priorità
        public static Task.LivelloPriorità InserisciPriorità()
        {
            bool isInt;
            int tipoTask;
            do
            {
                Console.WriteLine($"Premi {(int)LivelloPriorità.Alta} per dare una priorità {LivelloPriorità.Alta} al tuo impegno;");
                Console.WriteLine($"Premi {(int)LivelloPriorità.Media} per dare una priorità {LivelloPriorità.Media} al tuo impegno;");
                Console.WriteLine($"Premi {(int)LivelloPriorità.Bassa} per dare una priorità {LivelloPriorità.Bassa} al tuo impegno.");

                isInt = int.TryParse(Console.ReadLine(), out tipoTask);
            } while (!isInt || tipoTask < 1 || tipoTask > 3);

            return (LivelloPriorità)tipoTask;
        }

        public static void SalvaSuFile()
        {

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (Task task in impegni)
                {
                    sw.WriteLine($"Descrizione: {task.Descrizione} || Data : { task.Data} || Priorità: {task.Priorità}");
                }
            }
        }

        //Filtraggio gli impegni per priorità
        public static void FiltraTask()
        {
            Console.WriteLine("Scegli la priorità degli impegni da visualizzare");

            LivelloPriorità priorità = InserisciPriorità();

            List<Task> livelliSelezionati = new List<Task>();

            foreach (Task task in impegni)
            {
                if (task.Priorità == priorità)
                {
                    livelliSelezionati.Add(task);
                }
            }

            if (livelliSelezionati.Count > 0)
            {
                Console.WriteLine("Sono presenti i seguenti impegni: ");
                VisualizzaTask(livelliSelezionati);
            }
            else
            {
                Console.WriteLine($"Al momento non hai nessun impegno di priorità {priorità}");
            }
        }

        //Eliminazione impegno per numero
        public static void EliminaTask()
        {
            Console.WriteLine("Sono presenti i seguenti impegni: ");
            VisualizzaTask();

            Task ricercaNumero = RicercaNumero();

            impegni.Remove(ricercaNumero);
            Console.WriteLine("L'eliminazione è andata a buon fine.");
        }

        //Ricerca per numero (collegato a EliminaTask)
        public static Task RicercaNumero()
        {
            bool isInt;
            int ricerca;
            Console.Write("Inserisci il numero dell'impegno da rimuovere: ");
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out ricerca);
            } while (!isInt || ricerca < 0 || ricerca > impegni.Count);

            return impegni.ElementAt(ricerca - 1);
        }

        //Visualizzazione impegni con lista
        public static void VisualizzaTask(List<Task> impegni)
        {
            int numeroTask = 1;
            if (impegni.Count > 0)
            {
                foreach (Task task in impegni)
                {
                    //Vano tentativo di rendere tutto più carino
                    Console.WriteLine("___________________________________________");
                    Console.WriteLine($"N°{numeroTask}\nData : { task.Data}");
                    Console.WriteLine("___________________________________________");
                    Console.WriteLine($"Priorità: {task.Priorità}\nDescrizione: {task.Descrizione}");
                    Console.WriteLine("___________________________________________");
                    numeroTask++;
                }
            }
            else
            {
                Console.WriteLine("Non sono presenti impegni.");

            }
        }
        //Visualizzazione impegni
        public static void VisualizzaTask()
        {
            VisualizzaTask(impegni);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUtente
{
    class Menu
    {
        public static void Start()
        {
            Console.WriteLine("Gestione Impegni");
            bool continuare = true;
            do
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1 - Visualizza gli impegni");
                Console.WriteLine("2 - Aggiungi un nuovo impegno");
                Console.WriteLine("3 - Rimuovi impegni");
                Console.WriteLine("4 - Filtra per Priorità");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("-----------------------------");
                Console.WriteLine();
                Console.Write("Inserisci la tua scelta: ");


                int choice;
                bool isInt;
                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out choice);
                } while (!isInt);

                switch (choice)
                {
                    case 1:
                        TaskManager.VisualizzaTask();
                        break;
                    case 2:
                        TaskManager.AggiungiTask();
                        break;
                    case 3:
                        TaskManager.EliminaTask();
                        break;
                    case 4:
                        TaskManager.FiltraTask();
                        break;
                    case 0:
                        continuare = false;
                        TaskManager.SalvaSuFile();
                        break;
                    default:
                        Console.WriteLine("La tua scelta non è valida." +
                            "Ritenta.");
                        break;
                }
            } while (continuare);

        }
    }
}

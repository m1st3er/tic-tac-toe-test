using System;
class TicTacToe
{
    // Das Spielfeld als Array
    static string[] brett = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    // Der aktuelle Spieler
    static string spieler = "X";

    static void Main()
    {
        int spielerEingabe;
        int runden = 0;
        bool spielBeendet = false;

        while (!spielBeendet)
        {
            // Das Spielfeld anzeigen
            ZeigeBrett();

            // Eingabe vom Spieler
            Console.WriteLine($"Spieler {spieler}, wähle eine Zahl (1-9): ");
            spielerEingabe = Convert.ToInt32(Console.ReadLine()) - 1;

            // Überprüfen, ob die Eingabe gültig ist
            if (spielerEingabe >= 0 && spielerEingabe < 9 && brett[spielerEingabe] != "X" && brett[spielerEingabe] != "O")
            {
                // Das Spielfeld aktualisieren
                brett[spielerEingabe] = spieler;

                // Überprüfen, ob der Spieler gewonnen hat
                if (HatGewonnen())
                {
                    ZeigeBrett();
                    Console.WriteLine($"Spieler {spieler} hat gewonnen!");
                    spielBeendet = true;
                }
                else
                {
                    runden++;

                    // Überprüfen, ob das Spiel unentschieden endet
                    if (runden == 9)
                    {
                        ZeigeBrett();
                        Console.WriteLine("Das Spiel endet Unentschieden!");
                        spielBeendet = true;
                    }

                    // Wechsel zum anderen Spieler
                    spieler = (spieler == "X") ? "O" : "X";
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe, versuche es erneut.");
            }
        }

        Console.WriteLine("Drücke eine beliebige Taste, um das Spiel zu beenden.");
        Console.ReadKey();
    }

    // Das Spielfeld anzeigen
    static void ZeigeBrett()
    {
        Console.Clear();
        Console.WriteLine(" {0} | {1} | {2} ", brett[0], brett[1], brett[2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", brett[3], brett[4], brett[5]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", brett[6], brett[7], brett[8]);
        Console.WriteLine();
    }

    // Überprüfen, ob ein Spieler gewonnen hat
    static bool HatGewonnen()
    {
        // Alle möglichen Gewinnkombinationen
        int[,] gewinnKombinationen = new int[,] {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
        };

        // Überprüfen, ob eine Gewinnkombination erfüllt ist
        for (int i = 0; i < 8; i++)
        {
            if (brett[gewinnKombinationen[i, 0]] == brett[gewinnKombinationen[i, 1]] && brett[gewinnKombinationen[i, 1]] == brett[gewinnKombinationen[i, 2]])
            {
                return true;
            }
        }
        return false;
    }
}

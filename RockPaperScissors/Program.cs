using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RockPaperScissors
{
    internal class Program
    {

        /*
         * Rock,Paper,Scissors,Lizard,Spock
            1) ask player input
            2) program randomly selects one
            3) Output the program's selection
            4) tell the player who has won
            5) output how many times who won
            6) first to 5 wins
         */

        enum Choices
        {
            None, Rock, Paper, Scissors, Lizard, Spock
        }
        static void Main(string[] args)
        {
          
            int[] inputs = { 1, 2, 3, 4, 5 };
            bool stop;

            Choices playerChoice = Choices.None;
            Choices CpuChoice = Choices.None;

            int playerWinCount = 0;
            int CpuWinCount = 0;

            //GAME EXECUTION-------------------------------------------------------------------------------------------


            while ((playerWinCount < 5 && CpuWinCount < 5)) 
            {
                //input management: Player
                Console.WriteLine("insert input between: \n 1: Rock \n 2: Paper \n 3: Scissors \n 4: Lizard \n 5: Spock");
                string playerInput;
                int playerInputInt;
                stop = false;

                while (!stop)
                {
                    playerInput = Console.ReadLine();
                    playerInputInt = 0;

                    if (Int32.TryParse(playerInput, out playerInputInt))
                    {
                        if (playerInputInt <= 0 || playerInputInt > 5)
                        {
                            Console.WriteLine("Wrong input, try again: ");
                        }
                        else
                        {
                            foreach (int i in inputs)
                            {
                                if (playerInputInt == i)
                                {
                                    playerChoice = (Choices)(playerInputInt);
                                    stop = true;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!stop) { Console.WriteLine("Wrong input, try again: "); }
                    }
                }

                //Input management: CPU
                Random rnd = new Random();
                int RndChoiceCPU = rnd.Next(1, 5);
                CpuChoice = (Choices)(RndChoiceCPU);
                Console.WriteLine("Computer's Input : " + (Choices)RndChoiceCPU);
                  

                void ComputerWins()
                {
                    Console.WriteLine("\n Computer Wins");
                    CpuWinCount++;
                }

                void PlayerWins()
                {
                    Console.WriteLine("\n Player Wins");
                    playerWinCount++;
                }

                //Game execution
                if (playerChoice == CpuChoice) { Console.WriteLine("Tie"); }
                switch (playerChoice)
                {
                    case Choices.Rock:
                        if (CpuChoice == Choices.Spock || CpuChoice == Choices.Paper) { ComputerWins(); }
                        else if (CpuChoice == Choices.Scissors || CpuChoice == Choices.Lizard) { PlayerWins(); }
                        break;

                    case Choices.Lizard:
                        if (CpuChoice == Choices.Rock || CpuChoice == Choices.Scissors) { ComputerWins(); }
                        else if (CpuChoice == Choices.Spock || CpuChoice == Choices.Paper) { PlayerWins(); }
                        break;

                    case Choices.Spock:
                        if (CpuChoice == Choices.Paper || CpuChoice == Choices.Lizard) { ComputerWins(); }
                        else if (CpuChoice == Choices.Scissors || CpuChoice == Choices.Rock) { PlayerWins(); }
                        break;

                    case Choices.Paper:
                        if (CpuChoice == Choices.Lizard || CpuChoice == Choices.Scissors) { ComputerWins(); }
                        else if (CpuChoice == Choices.Rock || CpuChoice == Choices.Spock) { PlayerWins(); }
                        break;

                    case Choices.Scissors:
                        if (CpuChoice == Choices.Rock || CpuChoice == Choices.Spock) { ComputerWins(); }
                        else if (CpuChoice == Choices.Paper || CpuChoice == Choices.Lizard) { PlayerWins(); }
                        break;
                }

                Console.WriteLine("\n Player won: " + playerWinCount + "\t Computer won: " + CpuWinCount + "\n");
            }
        }
    }
}

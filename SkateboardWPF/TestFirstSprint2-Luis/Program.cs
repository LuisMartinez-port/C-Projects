namespace TestFirstSprint2_Luis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreetBoard streetBoard = new StreetBoard();
            Console.WriteLine(streetBoard.aboutBoardBuild());
            Console.WriteLine(streetBoard.aboutBoardPerformance());
            //get on board

            Console.WriteLine(streetBoard.PushOff());
            //push forward to get some speed
            Console.WriteLine(streetBoard.PushForward(30));

            Console.WriteLine(streetBoard.aboutBoardPerformance());

            Console.WriteLine(streetBoard.Ollie());
            Console.WriteLine(streetBoard.Kickflip());
            //tighten trucks to a point where it causes methods to break
            Console.WriteLine(streetBoard.trucks.TightenTrucks(80));
            Console.WriteLine("Hit enter to clear screen");
            Console.ReadKey();
            Console.Clear();
            //program will tell you to loosen trucks
            Console.WriteLine(streetBoard.PushForward(15));
            // we will loosen them too far
            Console.WriteLine(streetBoard.trucks.LoosenTrucks(130));
            Console.WriteLine("");
            //now we tighten them to the point where we get a warning but actions work
            Console.WriteLine(streetBoard.trucks.TightenTrucks(70));
            Console.WriteLine(streetBoard.PushForward(5));
            Console.WriteLine("Hit enter to clear screen");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(streetBoard.SlowDown(40));
            Console.WriteLine(streetBoard.Ollie());
            Console.WriteLine(streetBoard.trucks.Grind("railing",5));
            Console.WriteLine(streetBoard.DolphinFlip());
            CruiserBoard board = new CruiserBoard();
            Console.WriteLine("");
            Console.WriteLine(board.aboutBoardBuild());
            Console.WriteLine(board.aboutBoardPerformance());

        }
    }
}

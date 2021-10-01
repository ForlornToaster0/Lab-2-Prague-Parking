using System;

namespace Lab_2_Prague_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1;)
            {
                {
                    Console.WriteLine("Put in a command\n(N)ew vehicle\n(F)ind vehicle\n(R)emove vehicle\n(A)ll spots\n(Q)uite");
                    string MainInput = Console.ReadLine();
                    ParkingSorting(MainInput);
                    //if (MainInput == "N")
                    //{
                    //    Console.WriteLine("What kind of vehicle do you have and what is it's registration number?");
                    //    string MainInput2 = Console.ReadLine();
                    //    ParkingSorting(MainInput2);
                    //}
                    //else if (MainInput == "Q")
                    //{
                    //    Environment.Exit(0);
                    //}
                }
            }
            Console.WriteLine("Are you parking a car or a MC?");
            string input = (Console.ReadLine());
        }

        public static string[] parkingGarage = new string[100];
        static void ParkingSorting(string Input)
        {
            string test="";
            int i = 0;
            while (i < parkingGarage.Length)
            {
                for (int length = 0; length < Input.Length; length++)
                {
                    if (char.IsWhiteSpace(Input[length]))
                    {
                        test = Input.Replace(" ", "#");
                        //Console.WriteLine(test);
                    }
                }

                Random random = new Random();
                int R = random.Next(0, parkingGarage.Length);

                if (parkingGarage[R] == null)
                {
                    i++;
                    parkingGarage[R] = test;

                    int ind = Array.IndexOf(parkingGarage, Input);

                    Console.WriteLine("your spot is {0} {1}", ind, parkingGarage[R]);
                }
                else
                {
                    Console.WriteLine("IT WORKS!!!!");
                    i = 0;
                }
                break;
            }
        }
        static void ParkingRemoving(string Input)
        {

        }
    }
}


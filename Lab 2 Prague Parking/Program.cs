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
                    string subInout1 = Console.ReadLine();
                    string mainInput1 = subInout1.ToUpper();
                    ParkingSorting(mainInput1);
                    //if (mainInput1 == "N")
                    //{
                    //    Console.WriteLine("What kind of vehicle do you have and what is it's registration number?");
                    //    string subInput2 = Console.ReadLine();
                    //    string mainInput2 = subInput2.ToUpper();
                    //    ParkingSorting(mainInput2);
                    //}
                    //else if (mainInput1 == "Q")
                    //{
                    //    Environment.Exit(0);
                    //}
                }
            }
        }
        public static string[] parkingGarage = new string[100];       //Parking spaces
        static void ParkingSorting(string Input)
        {
            string test = "";
            int activeProgram = 0;
            Random random = new Random();               //Generatng random number for the parkin spaces
            int R = random.Next(0, 2);
            while (activeProgram < parkingGarage.Length)
            {
                for (int length = 0; length < Input.Length; length++)     //Adding CAR# och MC# before the registration plate.
                {
                    if (char.IsWhiteSpace(Input[length]))
                    {
                        test = Input.Replace(" ", "#");
                    }
                }
                if (parkingGarage[R] == null)
                {
                    activeProgram++;                                       //Filling parking space if it's empty
                    parkingGarage[R] = test;
                    Console.WriteLine("your spot is {0} {1}", R + 1, parkingGarage[R]);



                }
                else if (parkingGarage[R].IndexOf("MC", 0, 2) > -1 && test.IndexOf("MC", 0, 2) > -1)      // checking if the spot is occupied by a MC. If it's one more MC can park there.
                {

                    if (test != parkingGarage[R] && !parkingGarage[R].Contains("|"))
                    {
                        parkingGarage[R] = parkingGarage[R] + "|" + test;


                        Console.WriteLine("your spot is {0} {1}", R + 1, parkingGarage[R]);

                    }

                    break;
                }
                else
                {

                    break;
                }
            }
        }
        static void ParkingRemoving(string Input)
        {

        }
    }
}

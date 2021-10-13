using System;

namespace testing_things
{
    class test
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

        public static string[] parkingGarage = new string[100];
        static void ParkingSorting(string Input)
        {
            string test = "";
            int activeProgram = 0;
            Random random = new Random();
            int R = random.Next(0, 4);
            while (activeProgram < parkingGarage.Length)
            {
                for (int length = 0; length < Input.Length; length++)
                {
                    if (char.IsWhiteSpace(Input[length]))
                    {
                        test = Input.Replace(" ", "#");
                    }
                }
                if (parkingGarage[R] == null)
                {
                    activeProgram++;
                    parkingGarage[R] = test;
                    Console.WriteLine("your spot is {0} {1}", R + 1, parkingGarage[R]);



                }
                else if (parkingGarage[R].IndexOf("MC", 0, 2) > -1 && test.IndexOf("MC",0,2) >-1)
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

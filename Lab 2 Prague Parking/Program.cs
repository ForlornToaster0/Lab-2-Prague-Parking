using System;

namespace Lab_2_Prague_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            test();
            AddingForTesting("CAR#ABC123", 10);
            AddingForTesting("MC#THR739|MC#HRO240", 28);
            AddingForTesting("MC#HEJ123|MC#AHA123", 78);

            for (int i = 0; i < 1;)
            {
                {
                    Console.WriteLine("Put in a command\n(N)ew vehicle\n(F)ind vehicle\n(R)emove vehicle\n(A)ll spots\n(Q)uite");
                    string subInout1 = Console.ReadLine();
                    string mainInput1 = subInout1.ToUpper();

                    if (mainInput1 == "N")
                    {
                        Console.WriteLine("What kind of vehicle do you have and what is it's registration number?");
                        string subInput2 = Console.ReadLine();
                        string mainInput2 = subInput2.ToUpper();
                        ParkingSorting(mainInput2);
                    }
                    else if (mainInput1 == "F")
                    {
                        Console.WriteLine("What kind of vehicle do you have and what is it's registration number?");
                        string subInput3 = Console.ReadLine();
                        string mainInput3 = subInput3.ToUpper();
                        ParkingFinding(mainInput3);
                    }
                    else if (mainInput1 == "R")
                    {
                        Console.WriteLine("What is the registration number for the vehicle you want to remove?");
                        string subInput4 = Console.ReadLine();
                        string mainInput4 = subInput4.ToUpper();
                        ParkingRemove(mainInput4);
                    }
                    else if (mainInput1 == "A")
                    {
                        ParkingAll();
                    }
                    else if (mainInput1 == "Q")
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
        public static string[] parkingGarage = new string[100];
        static void test()
        {
            for (int i = 0; i < parkingGarage.Length; i++)
                parkingGarage[i] = "";
        }
        static void AddingForTesting(string Input, int pos)
        {
            parkingGarage[pos] = Input;
        }
        static void ParkingSorting(string Input)
        {
            string stringCombined = "";
            int activeProgram = 0;
            Random random = new Random();
            int R = random.Next(0, 100);
            while (activeProgram < parkingGarage.Length)
            {
                for (int length = 0; length < Input.Length; length++)
                {
                    if (char.IsWhiteSpace(Input[length]))
                    {
                        stringCombined = Input.Replace(" ", "#");
                    }
                }
                if (parkingGarage[R].Length == 0)
                {

                    parkingGarage[R] = stringCombined;
                    Console.WriteLine("your spot is {0} {1}", R + 1, parkingGarage[R]);

                }
                else if (parkingGarage[R].IndexOf("MC", 0, 2) > -1 && stringCombined.IndexOf("MC", 0, 2) > -1)
                {
                    if (stringCombined != parkingGarage[R] && !parkingGarage[R].Contains("|"))
                    {
                        parkingGarage[R] = parkingGarage[R] + "|" + stringCombined;
                        Console.WriteLine("your spot is {0} {1}", R + 1, parkingGarage[R]);
                    }

                }
                break;
            }
        }
        static void ParkingFinding(string Input)
        {
            for (int search = 0; search < parkingGarage.Length; search++)
            {
                if (parkingGarage[search] == Input)
                {
                    Console.WriteLine(search + 1);
                }
                else if (parkingGarage[search].Contains("|"))
                {
                    string[] subs = parkingGarage[search].Split("|", 2);
                    if (subs[0] == Input)
                        Console.WriteLine(search + 1);
                    else if (subs[1] == Input)
                        Console.WriteLine(search + 1);
                }
            }

        }
        static void ParkingRemove(string Input)
        {
            for (int search = 0; search < parkingGarage.Length; search++)
            {
                if (parkingGarage[search] == Input)
                {
                    parkingGarage[search] = "";
                }
                else if (parkingGarage[search].Contains("|"))
                {
                    string[] subs = parkingGarage[search].Split("|", 2);
                    if (subs[0] == Input)
                        parkingGarage[search] = subs[1];
                    else if (subs[1] == Input)
                        parkingGarage[search] = subs[0];
                }
            }
        }
        static void ParkingAll()
        {
            //for(int i1=0; i1<  49; i1++)
            //{
                for(int i2 =75 ; i2< 100; i2++)
                {
                    Console.WriteLine($"spot {i2-74}{parkingGarage[i2-75]} : spot {i2-49}{parkingGarage[i2-50]}" +
                        $" : spot {i2 - 24}{parkingGarage[i2 - 25]} : spot {i2+1 }{parkingGarage[i2]}");
                }

             
            //}

        }
    }
}

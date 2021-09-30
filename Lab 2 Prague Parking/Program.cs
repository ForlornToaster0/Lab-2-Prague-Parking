using System;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_2_Prague_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1;)
            {
                {
                    Console.WriteLine("put in what Vechal it is and it's regristation number\n MC or CAR");
                    string inout = Console.ReadLine();
                    if (inout == "n")
                        Environment.Exit(0);
                    else
                        PragueParking(inout);

                }
            }
        }


        static void PragueParking(string Input)
        {
            for (int length = 0; length < Input.Length; length++)
                if (char.IsWhiteSpace(Input[length]))
                {
                    string test = Input.Replace(" ", "#");
                    Console.WriteLine(test);
                }
                else if (!char.IsWhiteSpace(Input[length]))
                {

                }
            //string[] parkingGarage = new string[100];
            //Random random = new Random();
            //int R = random.Next(0, parkingGarage.Length);

            //for (int i = 0; parkingGarage.Length > i; i++)
            //{
            //    parkingGarage[R] = Input;

            //    int ind = Array.IndexOf(parkingGarage, Input);

            //    Console.WriteLine(parkingGarage[R]);
            //    Console.WriteLine(ind + 1);
            //    break;
            //}
        }
    }
}

using System;

namespace Lab_2_Prague_Parking
{
    class Program
    {

        static void Main(string[] args)
        {
            emptyArray();
            AddingForTesting("CAR#ABC123", 10);
            AddingForTesting("MC#THR739|MC#HRO240", 28);
            AddingForTesting("MC#HEJ123|MC#AHA123", 78);
            AddingForTesting("CAR#AA1234BB", 33);
            AddingForTesting("MC#YRA850", 74);
            AddingForTesting("CAR#BÜMA31", 10);


            for (int i = 0; i < 1;)
            {
                {
                    ParkingAll();
                    Console.WriteLine("Put in a command\n(N)ew vehicle\n(F)ind vehicle\n(R)emove vehicle\n(M)ove vehicle\n(Q)uite");
                    string subInout1 = Console.ReadLine();
                    string mainInput1 = subInout1.ToUpper();

                    if (mainInput1 == "N")
                    {
                        Console.Clear();
                        Console.WriteLine("What kind of vehicle do you have and what is it's registration number?");
                        string subInput2 = Console.ReadLine();
                        if (subInput2.Length < 14)
                        {
                            string mainInput2 = subInput2.ToUpper();
                            ParkingSorting(mainInput2);
                        }
                        else
                        { Console.WriteLine("string to long"); }
                    }
                    else if (mainInput1 == "F")
                    {
                        Console.Clear();
                       
                        Console.WriteLine("What kind of vehicle do you want to find and what is its registration number ?");
                        string subInput3 = Console.ReadLine();
                        if (subInput3.Length < 14)
                        {
                            string mainInput3 = subInput3.ToUpper();
                            ParkingFinding(mainInput3);
                        }
                        else
                        { Console.WriteLine("string to long"); }
                    }

                    else if (mainInput1 == "R")
                    {
                        Console.Clear();
                      
                        Console.WriteLine("What is the registration number for the vehicle you want to remove?");
                        string subInput4 = Console.ReadLine();
                        if (subInput4.Length < 14)
                        {
                            string mainInput4 = subInput4.ToUpper();
                            ParkingRemove(mainInput4);
                        }
                        else
                        { Console.WriteLine("string to long"); }
                    }
                   
                    else if (mainInput1 == "M")
                    {
                        Console.Clear();
                      
                        Console.WriteLine("What is the registration number for the car you want to move?");
                        string subInput5 = Console.ReadLine();
                        if (subInput5.Length < 14)
                        {
                            Console.WriteLine("Which parking space do you want to move the vehicle to?");
                            int newSpot = int.Parse(Console.ReadLine());
                            string mainInput5 = subInput5.ToUpper();
                            ParkingMove(mainInput5, newSpot);
                        }
                        else
                        { Console.WriteLine("string to long"); }
                    }
                    else if (mainInput1 == "Q")
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
        public static string[] parkingGarage = new string[100];
        static void emptyArray()             //This method turns the spaces to empty spaces instead of NULL.
        {
            for (int i = 0; i < parkingGarage.Length; i++)
                parkingGarage[i] = "";
        }
        static void AddingForTesting(string Input, int pos)     //Pre parked vehicles for testing.
        {
            parkingGarage[pos] = Input;
        }
        static void ParkingSorting(string Input)  //This method sorts all the parking spaces. It takes information about the vehicle and return a parking space.
        {
            string stringCombined = "";
            int activeProgram = 0;                  /* the necessery variabels to randomize */
            Random random = new Random();              /*and retun a parking space. */
            int R = random.Next(0, 100);
            while (activeProgram < parkingGarage.Length)    //This loop loops throught a the parking spaces.
            {
                for (int length = 0; length < Input.Length; length++)
                {
                    if (char.IsWhiteSpace(Input[length]))                //Add a # between the vehicle type and the reg-number.
                    {
                        stringCombined = Input.Replace(" ", "#");
                    }
                }
                if (parkingGarage[R].Length == 0)         //Checks if the randomized space is empty.
                {
                    parkingGarage[R] = stringCombined;
                    Console.WriteLine("your spot is {0} {1}", R + 1, parkingGarage[R]);  //return an empty parking space.
                }
                else if (parkingGarage[R].IndexOf("MC", 0, 2) > -1 && stringCombined.IndexOf("MC", 0, 2) > -1) //This checks if the occupied space is taken by a MC.
                {
                    if (stringCombined != parkingGarage[R] && !parkingGarage[R].Contains("|")) //and if it only one mc, 
                    {                                                                           //this if statment allows another MC to be parked there.
                        parkingGarage[R] = parkingGarage[R] + "|" + stringCombined;
                        Console.WriteLine("your spot is {0} {1}", R + 1, parkingGarage[R]);
                    }
                }
                break;
            }
        }
        static void ParkingFinding(string Input)   //This method finds the parking space for specific vehices.
        {
            string stringCombined = "";
            for (int length = 0; length < Input.Length; length++)   //This loop loops throught the input which is the registration number.
            {
                if (char.IsWhiteSpace(Input[length]))            // It then replaces the space between the vehicle type and the registration number with a '#'.
                {
                    stringCombined = Input.Replace(" ", "#");
                }
            }

            for (int search = 0; search < parkingGarage.Length; search++) // This loops through the parking garage to find the specific vehicle.
            {
                if (parkingGarage[search] == stringCombined)
                {
                    Console.WriteLine(search + 1);       //when found the parking space number is increased by one.
                }
                else if (parkingGarage[search].Contains("|")) // This else-if statment is doing the same thing but it's for MC. Reasin being MC can be parked two by two.
                {
                    string[] subs = parkingGarage[search].Split("|", 2);      //This splits the parking space in to two, so that each MC gets half.
                    if (subs[0] == stringCombined)            //if the first when is the one that is being looked for,
                        Console.WriteLine(search + 1);       //it returns the reg-number and the parking space increased by 1.
                    else if (subs[1] == stringCombined)       // - || - 
                        Console.WriteLine(search + 1);
                }
            }
        }
        static void ParkingRemove(string Input)   // This method removes vehicles.
        {
            string stringCombined = "";
            for (int length = 0; length < Input.Length; length++)
            {
                if (char.IsWhiteSpace(Input[length]))
                {
                    stringCombined = Input.Replace(" ", "#");
                }
            }

            for (int search = 0; search < parkingGarage.Length; search++)  // Loops through the parking garage trying to find the car that being looked for.
            {
                if (parkingGarage[search] == stringCombined)  // compare the input(reg-number) and the vehicle that is found. 
                {
                    parkingGarage[search] = "";               // If they match the vehicle is removed. And the space is empty once more.
                    Console.WriteLine("The car has been successfully removed!");
                }
                else if (parkingGarage[search].Contains("|"))
                {
                    string[] subs = parkingGarage[search].Split("|", 2);  //This does the same but it's for MC.
                    if (subs[0] == stringCombined)
                    {
                        parkingGarage[search] = subs[1];
                        Console.WriteLine("The MC has been successfully removed!");
                    }
                    else if (subs[1] == stringCombined)
                    {
                        parkingGarage[search] = subs[0];
                        Console.WriteLine("The MC has been successfully removed!");
                    }
                }
            }
        }
        static void ParkingAll() // This show the entire parking garage. It shows both empty and occupied spaces.
        {
            for (int i2 = 75; i2 < 100; i2++) // This diveds the list into four parts 1-24, 25-49, 50-74, 74-100.
            {
                Console.WriteLine($"spot[{i2 - 74}]: {parkingGarage[i2 - 75]}  spot[{i2 - 49}]: {parkingGarage[i2 - 50]}" +
                    $"  spot [{i2 - 24}]: {parkingGarage[i2 - 25]}  spot[{i2 + 1 }]: {parkingGarage[i2]}");
            }
        }
        static void ParkingMove(string Input, int newPos) // Manually moves vehicles.
        {
            newPos = newPos - 1;
            string newRegPos;
            string stringCombined = "";
            for (int length = 0; length < Input.Length; length++)
            {
                if (char.IsWhiteSpace(Input[length]))
                {
                    stringCombined = Input.Replace(" ", "#");
                }
            }

            for (int search = 0; search < parkingGarage.Length; search++)  // loops through the parking garage looking for a vehicle.
            {
                if (parkingGarage[search] == stringCombined && parkingGarage[newPos].Length == 0)  // Compares the car it found and the wanted one. 
                {
                    newRegPos = parkingGarage[search];
                    parkingGarage[search] = "";          // This removes the car from the old space. It turns the space into an empty one.
                    parkingGarage[newPos] = newRegPos;   // Gives new position to the car / moves car.
                }
                else if (parkingGarage[search].Contains("|")) // This does the same but for MC.
                {

                    string[] subs = parkingGarage[search].Split("|", 2); //Divides the space into two because MC can be parked two by two.
                    if (subs[0] == stringCombined)
                    {
                        newRegPos = subs[0];  //sub[0] = first part or first MC.
                        if (parkingGarage[newPos].Contains("M") && !parkingGarage[newPos].Contains("|")) //If the new positions isn't empty and it doesn't contain to MC 
                        {                                                                               //it enters the if statment.

                            parkingGarage[newPos] = parkingGarage[newPos] + "|" + stringCombined;   // Moves mc to a new position, and seperates the two mc's with a '|'.
                            parkingGarage[search] = subs[1];

                        }
                        else if (parkingGarage[newPos].Length == 0) // if the new position is empty enter the else if statment.
                        {
                            parkingGarage[search] = subs[1];   //Moves mc to the new position.
                            parkingGarage[newPos] = newRegPos;
                        }
                    }
                    else if (subs[1] == stringCombined)     //this does the same as the previous if statment but it's for the second part or the second MC.
                    {
                        newRegPos = subs[1];
                        if (parkingGarage[newPos].Contains("M") && !parkingGarage[newPos].Contains("|"))
                        {

                            parkingGarage[newPos] = parkingGarage[newPos] + "|" + newRegPos;
                            parkingGarage[search] = subs[0];

                        }
                        else if (parkingGarage[newPos].Length == 0)
                        {
                            parkingGarage[search] = subs[0];
                            parkingGarage[newPos] = newRegPos;

                        }
                    }


                }
            }
        }
    }
}
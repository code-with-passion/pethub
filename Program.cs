using System;

// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
bool validEntry = false;
int petAge = 0;
decimal decimalDonation = 0.00m;
// update to "waiting/searching" animation 
string[] searchingIcons = { ". ", "..", "..." };
// user entered search term array
string[] searchArray = new string[0];
int currentIndex = 0;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "49.99";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "puss";
            suggestedDonation = "40.00";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
    {
        decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
    }
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}

do
{
    // display the top-level menu options
    Console.Clear();
    Console.WriteLine("Welcome To Binoy's Pethub App. Your Main Menu Options Are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    Console.WriteLine($"You selected menu option {menuSelection}.");
    Console.WriteLine("Press the ENTER key to continue.");

    // pause code execution
    readResult = Console.ReadLine();
   

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }

            Console.WriteLine("Press the ENTER key to continue.");
            readResult = Console.ReadLine();
            break;

        case "2":
            // Add a new animal friend to the ourAnimals array
            string anotherPet = "y";
            int petCount = 0;

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            while (anotherPet == "y" && petCount < maxPets)
            {

                // get species (cat or dog) - string animalSpecies is a required field 
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                    // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                    animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                // get the pet's age. can be ? at initial entry.
                do
                {
                    Console.WriteLine("Enter the pet's age or enter (?) if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }
                } while (animalPhysicalDescription == "");

                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }
                } while (animalPersonalityDescription == "");

                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }
                } while (animalNickname == "");

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                petCount += 1;

                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet?
                    do
                    {
                        Console.WriteLine("Do you want to enter info for another pet (y/n)?");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.\n");
            }

            Console.WriteLine("\nNew pet has been added successfully.\n");
            Console.WriteLine("Press the ENTER key to continue.");
            readResult = Console.ReadLine();
            break;

        case "3":
            // Ensure animal ages and physical descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    if (ourAnimals[i, 2] == "Age: ?" || ourAnimals[i, 2] == "Age: " || ourAnimals[i, 4] == "Personality description: " || ourAnimals[i, 4] == "Personality description: tbd")
                    {
                        while (true)
                        {
                            if (ourAnimals[i, 2] == "Age: ?" || ourAnimals[i, 2] == "Age: ")
                            {
                                Console.WriteLine($"Enter an age for our pet {ourAnimals[i, 0]}");

                                do
                                {
                                    readResult = Console.ReadLine();
                                    if (readResult != null)
                                    {
                                        validEntry = int.TryParse(readResult, out petAge);
                                        if (!validEntry)
                                        {
                                            Console.WriteLine($"Enter an age for our pet {ourAnimals[i, 0]}");
                                        }
                                        else
                                        {
                                            ourAnimals[i, 2] = "Age: " + petAge;
                                            break;
                                        }
                                    }
                                } while (!validEntry);
                            }

                            if (ourAnimals[i, 4] == "Physical description: " || ourAnimals[i, 4] == "Physical description: tbd")
                            {
                                Console.WriteLine($"Enter a physical description of the pet {ourAnimals[i, 0]} (size, color, gender, weight, housebroken)");
                                do
                                {
                                    readResult = Console.ReadLine();

                                    if (readResult != null)
                                    {
                                        animalPhysicalDescription = readResult.ToLower();
                                        if (animalPhysicalDescription == "" || animalPhysicalDescription == "tbd")
                                        {
                                            Console.WriteLine($"Enter a physical description of the pet {ourAnimals[i, 0]} (size, color, gender, weight, housebroken)");
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                } while (true);
                            }
                            
                            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                            break;  // Exit the inner loop
                        }
                    }
                }
                else
                {
                    break; // Exit the loop when encountering the pet with no ID
                }
            }
            Console.WriteLine("All information are complete.\n");
            Console.WriteLine("Press the ENTER key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    if (ourAnimals[i, 3] == "Nickname: ?" || ourAnimals[i, 3] == "Nickname: " || ourAnimals[i, 5] == "Personality description: " || ourAnimals[i, 5] == "Personality description: tbd")
                    {
                        do
                        {
                            Console.WriteLine($"Enter a nickname for pet {ourAnimals[i, 0]}");

                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                animalNickname = readResult.ToLower();
                                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                            }
                        } while (animalNickname == "");

                        do
                        {
                            Console.WriteLine($"Enter a personality description for pet {ourAnimals[i, 0]} (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPersonalityDescription = readResult.ToLower();
                                ourAnimals[i, 5] = "Personality description: " + animalPersonalityDescription;
                            }
                        } while (animalPersonalityDescription == "");

                        break; // exit inner loop
                    }
                }
                else
                {
                    break; // exit outer loop
                }
            }

            Console.WriteLine("All information are complete.\n");
            Console.WriteLine("Press the ENTER key to continue.");
            readResult = Console.ReadLine();
            break;

        case "5":
            // Edit an animal’s age
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    // Display all pet info
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                    // Do loop edit message if not valid entry
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Do you want to edit this pet's age (y/n)?");
                        readResult = Console.ReadLine();

                        if (readResult == "y")
                        {
                            // Do loop enter age message if not valid entry
                            do
                            {
                                Console.WriteLine($"Enter an age for our pet {ourAnimals[i, 0]}");
                                readResult = Console.ReadLine();                         

                                if (readResult != null)
                                {
                                    
                                    validEntry = int.TryParse(readResult, out petAge);
                                    if (!validEntry)
                                    {
                                        continue;
                                    } 
                                    else
                                    {
                                        // If user entry is (y) display all current pet info with updated pet age
                                        ourAnimals[i, 2] = "Age: " + petAge;
                                        Console.WriteLine();
                                        for (int j = 0; j < 7; j++)
                                        {
                                            Console.WriteLine(ourAnimals[i, j]);
                                        }
                                        Console.WriteLine("\nPet age has been updated successfully!");
                                        Console.WriteLine("\nPress ENTER key to continue...");
                                        Console.ReadLine();
                                    }         
                                }
                            } while (!validEntry);
                        }
                        else if (readResult == "n")
                        {
                            Console.WriteLine("\nPress ENTER key to continue...");
                            Console.ReadLine();
                        }
                        else
                            continue;

                        break; // Exit edit age loop when valid entry 
                    } while (readResult == "" || readResult != "y" || readResult != "n" || !validEntry); 
                }
                else
                {
                    break; // Exit the loop when encountering the pet with no ID
                }
            }

            Console.WriteLine("\nAll information are complete.\n");
            Console.WriteLine("Press the ENTER key to continue.");
            readResult = Console.ReadLine();
            break;

        case "6":
            // Edit an animal’s personality description
            bool petFound = false;
            do
            {
                Console.Write("Enter pet ID to search: ");
                readResult = Console.ReadLine();
            } while (readResult == "");

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i,0] != "ID #: ")
                {
                    if (ourAnimals[i,0] == $"ID #: {readResult}")
                    {
                        petFound = true;
                        Console.WriteLine();
                        for (int j = 0; j < 7; j++)
                        {
                            Console.WriteLine(ourAnimals[i,j]);
                        }

                        do
                        {
                            Console.Write("\nDo you want to edit this pet's personality description? (y/n): ");
                            readResult = Console.ReadLine();
                            
                            if (readResult != null)
                            {
                                if (readResult == "y")
                                {
                                    Console.WriteLine();
                                    do
                                    {
                                        Console.WriteLine("Update the pet's personality description below.");
                                        readResult = Console.ReadLine();
                                        
                                        if (readResult == "")
                                        {                                            
                                            validEntry = false;
                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            ourAnimals[i,5] = $"Personality: {readResult?.ToLower()}";
                                            for (int k = 0; k < 7; k++)
                                            {
                                                Console.WriteLine(ourAnimals[i,k]);
                                            }
                                            Console.WriteLine("\nChanges has been applied to pet personality description.\n");
                                            validEntry = true;
                                        }
                                    } while (!validEntry);

                                }
                                else if (readResult == "n")
                                {
                                    validEntry = true;
                                    Console.WriteLine("\nNo changes made to the pet's personality description.\n");
                                }
                                else
                                {
                                    validEntry = false;
                                }    
                            }
                            else
                            {
                                break;
                            }

                        } while (!validEntry);

                        break;
                    }
                    else
                    {
                        petFound = false;
                    }
                } 
            }

            if (!petFound)
            {
                Console.WriteLine($"\nNo match found for the pet ID #: {readResult}\n");
            }
           
            Console.WriteLine("Press the ENTER key to continue.");
            readResult = Console.ReadLine();
            break;

        case "7":
            // Display all cats with a specified characteristic
            string catCharacteristic = "";
            string catDescription = "";
            bool noMatchesCat = true;
            
            while (catCharacteristic == "")
            {
                // have user enter multiple comma separated characteristics to search for
                Console.WriteLine($"\rEnter cat characteristic to search for separated by commas");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    catCharacteristic = readResult.ToLower().Trim();
                    Console.WriteLine();
                }
            }
            // split user search terms for sorting
            searchArray = catCharacteristic.Split(',');
            Array.Sort(searchArray);

            for (int i = 0; i < maxPets; i++)
            {
                bool catMatch = true;

                if (ourAnimals[i, 1].Contains("cat"))
                {
                    if (catMatch == true)
                    {
                        // Search combined descriptions and report results
                        catDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                        string[] splitCatDescription = catDescription.Split(" ");

                        foreach (string searchTerm in searchArray)
                        {
                            for (int j = 5; j > -1; j--)
                            {
                                // "searching" message animation 
                                foreach (string icon in searchingIcons)
                                {
                                    Console.Write($"\rsearching for {searchTerm} {searchingIcons[currentIndex]}");
                                    Thread.Sleep(250);

                                    // Move the current icon to the end of the array
                                    string temp = searchingIcons[currentIndex];
                                    for (int k = currentIndex; k < searchingIcons.Length - 1; k++)
                                    {
                                        searchingIcons[k] = searchingIcons[k + 1];
                                    }
                                    searchingIcons[searchingIcons.Length - 1] = temp;

                                    // Update the current index for the next iteration
                                    currentIndex = (currentIndex) % searchingIcons.Length;
                                }
                                Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                            }

                            if (splitCatDescription.Contains(searchTerm))
                            {

                                string outputMatch = $"{ourAnimals[i, 3]} is a {searchTerm} match!";

                                // Find the index of the colon character
                                int colonIndex = outputMatch.IndexOf(":");

                                // Extract the name by removing "Nickname:" and any leading/trailing whitespace
                                string output = outputMatch.Substring(colonIndex + 1).Trim();
                                Console.WriteLine($"\rOur cat {output}");
                                noMatchesCat = false;
                            }
                        }

                        if (noMatchesCat == false)
                        {
                            if (ourAnimals[i, 4] == "Physical description: tbd" || ourAnimals[i, 5] == "Personality: tbd" || ourAnimals[i,4] == "Physical description: " || ourAnimals[i,5] == "Personality: ")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"\n{ourAnimals[i, 3]} ({ourAnimals[i, 0]})");
                                Console.WriteLine(catDescription);
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }

            if (noMatchesCat)
            {
                Console.WriteLine($"None of our cats are a match found for: {catCharacteristic}\n");
            }

            Console.WriteLine("Search complete.\n");
            Console.WriteLine("Press the ENTER key to continue.");
            readResult = Console.ReadLine();
            break;

        case "8":
            // Display all dogs with a specified characteristic
            string dogCharacteristic = "";
            string dogDescription = "";
            bool noMatchesDog = true;

            while (dogCharacteristic == "")
            {
                // have user enter multiple comma separated characteristics to search for
                Console.WriteLine($"\rEnter dog characteristic to search for separated by commas");
                readResult = Console.ReadLine();
                
                if (readResult != null)
                {
                    dogCharacteristic = readResult.ToLower().Trim();
                    Console.WriteLine();
                }
            }
            // split user search terms for sorting
            searchArray = dogCharacteristic.Split(',');
            Array.Sort(searchArray);

            for (int i = 0; i < maxPets; i++)
            {
                bool dogMatch = true;

                if (ourAnimals[i, 1].Contains("dog"))
                {
                    if (dogMatch == true)
                    {
                        // Search combined descriptions and report results
                        dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                        string[] splitDogDescription = dogDescription.Split(" ");

                        foreach (string searchTerm in searchArray)
                        {
                            for (int j = 5; j > -1; j--)
                            {
                                // "searching" message animation 
                                foreach (string icon in searchingIcons)
                                {
                                    Console.Write($"\rsearching for {searchTerm} {searchingIcons[currentIndex]}");
                                    Thread.Sleep(250);
                                    // Move the current icon to the end of the array
                                    string temp = searchingIcons[currentIndex];
                                    for (int k = currentIndex; k < searchingIcons.Length-1; k++)
                                    {
                                        searchingIcons[k] = searchingIcons[k + 1];
                                    }
                                    searchingIcons[searchingIcons.Length - 1] = temp;

                                    // Update the current index for the next iteration
                                    currentIndex = (currentIndex) % searchingIcons.Length;
                                }
                                Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                            }
                            
                            if (splitDogDescription.Contains(searchTerm))
                            {

                                string outputMatch = $"{ourAnimals[i, 3]} is a {searchTerm} match!";

                                // Find the index of the colon character
                                int colonIndex = outputMatch.IndexOf(":");

                                // Extract the name by removing "Nickname:" and any leading/trailing whitespace
                                string output = outputMatch.Substring(colonIndex + 1).Trim();
                                Console.WriteLine($"\rOur dog {output}");
                                noMatchesDog = false;  
                            }
                        }

                        if (noMatchesDog == false)
                        {
                            if (ourAnimals[i, 4] == "Physical description: tbd" || ourAnimals[i,5] == "Personality: tbd")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"\n{ourAnimals[i, 3]} ({ourAnimals[i, 0]})");
                                Console.WriteLine(dogDescription);
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }

            if (noMatchesDog)
            {
                Console.WriteLine($"None of our dogs are a match found for: {dogCharacteristic}\n");
            }

            Console.WriteLine("Search complete.\n");
            Console.WriteLine("\nPress the ENTER key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }
} while (menuSelection != "exit");
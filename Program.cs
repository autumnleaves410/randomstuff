namespace Lab_2;

class Program
{
    static void Main(string[] args)
    {
        List<VideoGame> listofGames = new List<VideoGame>(); //makes a new list for video games...referencing the video game class. 

        Dictionary<int, VideoGame> gameDictionary = new Dictionary<int, VideoGame>();  //creates a int key and game object..using this to 

        
        string rootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString(); //makes a new directory so that it can find the csv file easier?
        string filePath = $"{rootFolder}{Path.DirectorySeparatorChar}videogames.csv";  //establishes a file path to videogames.csv

        using (var sr = new StreamReader(filePath))
        {
            string[] fileReader = File.ReadAllLines(filePath);

            

            for (int gameNumber = 1; gameNumber < fileReader.Length; gameNumber++)
            {
                string line = fileReader[gameNumber];

                string[] lineElements = line.Split(',');

                VideoGame Games = new VideoGame
                {
                    Name = lineElements[0],
                    Platform = lineElements[1],
                    Genre = lineElements[3],
                    Publisher = lineElements[4],
    
                };

                gameDictionary.Add(gameNumber, Games);
               

                

               try
                {
                    Console.WriteLine("Hey! Welcome to the Random Game Picker! How this is works is you pick a random number," +
                        "and the number you pick is the game you'll play! So! Pick any number between 1 - 16328.");

                    int userNum = Int32.Parse(Console.ReadLine());

                    if (userNum < 1 || userNum > 16328)
                    {
                        Console.WriteLine("Enter a valid number.");
                    }
                    else
                    {
                        Console.WriteLine($"Great, you've chosen the number {userNum}");



                        if (gameDictionary.TryGetValue(userNum, out VideoGame chosenGame))
                        {

                       


                            Console.WriteLine("-----------------------");
                            Console.WriteLine("Congrats! The game you'll be playing is..");

                             Console.WriteLine($"Game: {chosenGame.Name}");
                             Console.WriteLine($"Game Publisher: {chosenGame.Publisher}");
                             Console.WriteLine($"Game Genre: {chosenGame.Genre}");
                             Console.WriteLine($"Have fun!");
                             Console.WriteLine("-----------------------"); 
                            
                        }

                        else
                        {
                            Console.WriteLine("Game not found. There was a problem retrieving the data.");
                        }


                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("There was an error.");
                } 

                
          

            }

            Console.WriteLine("Press Enter to Clear");
            Console.Read();
            Console.Clear();
            
        }

       /* using (var sr = new StreamReader(filePath))
        {
            try
            {

            }

            catch (Exception ex)
            {
                Console.WriteLine("There was an error. Please try again.");
            }
        }*/
      







    }

}


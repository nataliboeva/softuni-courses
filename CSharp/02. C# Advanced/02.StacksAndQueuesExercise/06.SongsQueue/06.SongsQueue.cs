namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(input);

            while (songs.Any())
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Play")
                {
                    songs.Dequeue();
                }
                else if (command[0] == "Add")
                {
                    string addedSong = string.Join(" ", command.Skip(1));
                    if(songs.Contains(addedSong))
                    {
                        Console.WriteLine($"{addedSong} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(addedSong);
                    }   
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}

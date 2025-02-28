
namespace _01.OddLines
{
    public class OddLines
    {
        static void Main(string[] args)
        {
            string inputFileReader = @"..\..\..\Files\input.txt";
            string outputFileWriter = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFileReader, outputFileWriter);

        }
        public static void ExtractOddLines(string inputFileReader, string outputFileWriter)
        {
            using (StreamReader reader = new StreamReader(inputFileReader))
            {
                using (StreamWriter writer = new(outputFileWriter))
                {
                    int counter = 0;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (counter % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                    }
                }
            }
        }
    }
}

namespace _25_probna
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int length = number.Length;
            
            List<int> list = new List<int>();
            for (int i = 0; i < length; i++)
            {
                list.Add(number[i]);
            }
            List<int> reverse = new List<int>();
            for (int i = length - 1;  i > 0;  i--)
            {
                reverse.Add(number[i]);
            }

            if(list == reverse)
            {
                Console.WriteLine(string.Join("", list) + "is a palindrome");
            }
            else
            {
                Console.WriteLine(string.Join("", list) + "is NOT a palindrome");
            }
            
        }
    }
}

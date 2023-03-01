using System;
using System.Security.Cryptography.X509Certificates;

namespace Indexer_Assignment
{
    class Program
    {

        public const int Size = 15;  // global variable
        class ClubMembers
        {
            private string[] Members = new string[Size];
            public string ClubType { get; set; }
            public string ClubLocation { get; set; }
            public string MeetingDate { get; set; }

            // constructor
            public ClubMembers()
            {
                for (int i = 0; i < Size; i++)
                    Members[i] = string.Empty;

                ClubType = string.Empty;
                MeetingDate = string.Empty;
                ClubLocation = string.Empty;

            }

            //indexer get and set methods
            public string this[int index]
            {
                get
                {
                    string temp;

                    if (index >= 0 && index <= Size - 1)
                        temp = Members[index];

                    else
                        temp = " ";

                    return temp;
                }
                set
                {
                    if (index >= 0 && index <= Size - 1)
                        Members[index] = value;
                }
            }
        }
        public static void Main(string[] args)
        {
            ClubMembers clubMembers = new ClubMembers();
            bool isDone = false;
    
            while (!isDone)
            {
                int response = 0;

                while (response > Size || response < 1) // Some error handling for indexer size
                {
                    Console.WriteLine($"What club member do you want to enter? 1-{Size}");
                    while (!int.TryParse(Console.ReadLine(), out response))
                        Console.WriteLine($"Enter a value between 1 - {Size}");
                }

                Console.WriteLine("Please enter the name of the club member."); //Fills in indexer with user input
                clubMembers[response - 1] = Console.ReadLine();
                Console.WriteLine("Please press any key to continue with new names or press 'q' to stop.");
                string isStop = Console.ReadLine();
                if (isStop == "q")
                    isDone = true;
            }
            // Fills in remaining information for object clubMembers
            Console.WriteLine("What is the club type?");
            clubMembers.ClubType = Console.ReadLine();
            Console.WriteLine("What is the meeting date?");
            clubMembers.MeetingDate = Console.ReadLine();
            Console.WriteLine("Where is the club location?");
            clubMembers.ClubLocation = Console.ReadLine();

            Console.Clear();

            //Displays information about the club
            Console.WriteLine("Club Members:");

            for(int i = 0; i < Size; i++)
                if (clubMembers[i] != string.Empty)
                    Console.WriteLine(clubMembers[i]);
            Console.WriteLine();
            Console.WriteLine("Club Information:");
            Console.WriteLine($"Club Type: {clubMembers.ClubType}");
            Console.WriteLine($"Club Location: {clubMembers.ClubLocation}");
            Console.WriteLine($"Meeting Date: {clubMembers.MeetingDate}");
            
        }
    }
}
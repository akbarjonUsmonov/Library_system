using System.Xml;

public class Library
{
    int BookIndex = 0;
    private Dictionary<int, Book> storage = new Dictionary<int, Book>();

    public void AddBook()
    {
        Book tmp = new Book();
        tmp.status = 0;

        Console.Write("\nEnter book title: ");
        tmp.Title = Console.ReadLine();

        Console.Write("Enter author name: ");
        tmp.Author = Console.ReadLine();

        storage.Add(BookIndex++, tmp);
    }

    public void Borrow()
    {
        Console.Write("\nEnter the index of the book to borrow: ");
        string input = "";
        while ((input = Console.ReadLine()) != null)
        {
            if (int.TryParse(input, out _) == false)
            {
                Console.Write("\nIndex must contain only digits!\n");
            }
            else
            {
                int number = int.Parse(input);
                if (number + 1 > BookIndex || number < 0)
                {
                    Console.WriteLine($"No such a book under the index of {number}");
                }
                else
                {
                    Book tmp = storage[number];
                    tmp.status = 1;
                    storage[number] = tmp;
                    return;
                }
            }
            Console.Write("\nEnter the index of the book to borrow: ");
        }
    }

    public void Return()
    {
        Console.Write("\nEnter the index of the book to return: ");
        string input = "";
        while ((input = Console.ReadLine()) != null)
        {
            if (int.TryParse(input, out _) == false)
            {
                Console.Write("\nIndex must contain only digits!\n");
            }
            else
            {
                int number = int.Parse(input);
                if (number + 1 > BookIndex || number < 0)
                {
                    Console.WriteLine($"No such borrowed book under the index of {number}");
                }
                else
                {
                    Book tmp = storage[number];
                    tmp.status = 0;
                    storage[number] = tmp;
                    return;
                }
            }
            Console.Write("\nEnter the index of the book to return: ");
        }
    }

    public void Booklist()
    {
        Console.WriteLine("\n-----Booklist-----");
        foreach (KeyValuePair<int, Book> i in storage)
        {
            Console.WriteLine($"{i.Key}.");
            Console.WriteLine($"  Title: {i.Value.Title}");
            Console.WriteLine($"  Author: {i.Value.Author}");
            if (i.Value.status == 0)
            {
                Console.WriteLine($"  Status: avalible");
            }
            else
            {
                Console.WriteLine($"  Status: not avalible (borrowed)");
            }
            Console.WriteLine();

        }
        Console.WriteLine("\n------------------");
    }
}
namespace calculator_ns;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Число для перевода: ");
        string start_num = Console.ReadLine();
        Console.Write("В какой системе счисления число? ");
        int start_ns = int.Parse(Console.ReadLine());
        Console.Write("В какую систему счисления хотите перевести? ");
        int new_ns = int.Parse(Console.ReadLine());
        string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        if (start_ns == 10)
        {
            Console.WriteLine(FromTenToAnother(start_num, start_ns, new_ns));
        }
        
        else if (new_ns == 10)
        {
            Console.WriteLine(FromSomeToTen(start_num, start_ns, new_ns));
        }
        
        else
        {
            Console.WriteLine(FromSomeToSome(start_num, start_ns, new_ns));
        }
    }

    public static string FromTenToAnother(string start_num, int start_ns, int new_ns)
    {
        string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        long start_num_2 = long.Parse(start_num);
        string temp_num = "";
            
        while (start_num_2 > 0)
        {
            temp_num += digits[(int)(start_num_2 % new_ns)];
            start_num_2 /= new_ns;
        }

        char[] dig = temp_num.ToCharArray();
        Array.Reverse(dig); 
        temp_num = new string(dig);
        return temp_num;
    }

    public static long FromSomeToTen(string start_num, int start_ns, int new_ns)
    {
        string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string start_num_2 = start_num;
        long temp_num = 0;
        int len = start_num_2.Length;
        int count = 0;

        for (int i = len - 1; i >= 0; i--)
        {
            int dig = digits.IndexOf([start_num_2[count]]);
            count += 1;
            temp_num += (dig * (long)(Math.Pow(start_ns, i)));
        }
        
        return temp_num;
    }

    public static string FromSomeToSome(string start_num, int start_ns, int new_ns)
    {
        long i = FromSomeToTen(start_num, start_ns, 10);
        string res = FromTenToAnother(i.ToString(), 10, new_ns);

        return res;
    }
}

using System;

namespace Stadsarkiv
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = Type.GetType("int");
            Console.WriteLine(type.ToString());
            Console.ReadLine();
        }
    }
}

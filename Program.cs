using System;

namespace Dump
{
    class Program
    {
		public delegate double myDel(int x); 

        static void Main(string[] args)
        {
			Console.WriteLine("Enter a number:"); 
			int number = 0; 

			try { 
				string num = Console.ReadLine(); 
				number = Convert.ToInt32(num); 
			} 
			catch (Exception e) 
			{ 
				Console.WriteLine(e.Message); 
			} 
			
            Console.WriteLine("Hello World!");
	
			myDel addd = (x) => x + 10; 
			Console.WriteLine($"The number {number} plus 10  is {addd.Invoke(number)}"); 

			myDel power = delegate(int x) { return Math.Pow(x, 10);}; 
			Console.WriteLine($"The number {number} to power 10 is {power.Invoke(number)}"); 
        }
    }
}

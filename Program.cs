using System;

namespace Dump
{
    class Program
    {
		public delegate double myDel(int x); 
        static void Main(string[] args)
        {
			try { 
				int number = Convert.ToInt32(Console.ReadLine()); 
			} 
			catch (Exception e) 
			{ 
				Console.WriteLine(e.Message); 
			} 
			
            Console.WriteLine("Hello World!");
	
			myDel addd = (x) => x + 10; 
			Console.WriteLine(addd.Invoke(20)); 

			myDel counter = delegate(int x) { return Math.Pow(x, 10);}; 
        }
    }
}

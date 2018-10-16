using System; 
using System.Collections.Generic;
using System.Threading.Tasks; 



namespace Simple 
{ 
	public class Bank 
	{ 
		private readonly object padlock = new object(); 

		private int balance; 

		public Bank() 
		{ 

		} 
		public int Balance
		{ 
			get
			{	
				return balance;  
			} 
			set 
			{ 
				lock(padlock)  
				{
					balance += value; 
				} 
			} 
		} 
		public int Withdraw
		{ 
			get { 
				return balance; 
			} 
			set { 
					
			lock(padlock) 
				{		
				if (value > balance) 
				{		
					throw new Exception ("Funds low!"); 
				} 	
				else  
				{ 
						balance -= value; 
				} 
				} 
			} 

		} 
	} 
	public class Run
	{ 

		public static void Main(string [] args) 
		{ 
			Bank b = new Bank(); 
			/// List<Task> tsks = new List<Task>(); 

			Task tsk1 = new Task( delegate() { 
						for(int i = 0; i < 20; i++) 
						{ 
							Console.WriteLine($"i = {i}");
							b.Balance = 10; 

						}
			});  

			Task tsk2 = new Task ( () => { 

					for(int i = 0; i < 20; i++) 
					{ 
						
						Console.WriteLine($"i = {i}"); 
						b.Withdraw = 10; 
					}

			}); 
			tsk1.Start(); 
			tsk2.Start(); 
			tsk1.Wait(); 
			Console.WriteLine("Starts tsk2"); 
			tsk2.Wait(); 
			Console.WriteLine($"Final balance is {b.Balance}"); 



		} 
	}


} 

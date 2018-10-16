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
		public void Withdraw(int amount) 
		{ 
			if (amount > balance ) 
				throw new Exception("Funds too low!"); 
			else 
				Balance -= amount; 
		} 
		public void Deposit(int amount) 
		{ 
			Balance += amount; 
		} 
		public int Balance
		{ 
			set 
			{ 
				balance = value;
			} 
			get
			{	
				return balance;  
			} 
		} 
	} 
	public class Run
	{ 

		public static void Main(string [] args) 
		{ 
			Bank b = new Bank(); 
			Task tsk1 = new Task( delegate() { 
						for(int i = 0; i < 20; i++) 
						{ 
							Console.WriteLine($"i = {i}");
							b.Deposit(10); 

						}
			});  

			Task tsk2 = new Task ( () => { 

					for(int i = 0; i < 20; i++) 
					{ 
						
						Console.WriteLine($"i = {i}"); 
						b.Withdraw(10); 
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

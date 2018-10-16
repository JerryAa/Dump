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
				lock(padlock) 
				{ 
					Balance -= amount; 
				} 
		} 
		public void Deposit(int amount) 
		{ 
			lock(padlock) 
			{ 
				Balance += amount; 
			}
		} 
		public int Balance
		{ 
			private set 
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
			Task tsk1 = Task.Factory.StartNew( () => 
			{  
						for(int i = 0; i < 20; i++) 
						{ 
							// Console.WriteLine($"i = {i}");
							b.Deposit(10); 

						}
			});  

			Task tsk2 = Task.Factory.StartNew( () => 
			{   

					for(int i = 0; i < 20; i++) 
					{ 
						
						b.Withdraw(10); 
					}

			}); 

			tsk1.Wait(); 
			Console.WriteLine($"Task Id {tsk1.Id}"); 
			tsk2.Wait(); 
			Console.WriteLine($"Final balance is {b.Balance}"); 



		} 
	}


} 

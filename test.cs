using System; 
using System.Threading.Tasks; 



namespace Simple 
{ 
	public class Bank 
	{ 

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
				balance += value; 
			} 
		} 
		public int Withdraw  
		{ 
			get { 
				return balance; 
			} 
			set { 
				if (value > balance) 
				{		
					throw new Exception ("Funds low!"); 
				} 	
				else 
					balance -= value; 
			} 

		} 
	} 
	public class Run
	{ 

		public static void Main(string [] args) 
		{ 
			Bank b = new Bank(); 
			b.Balance = 45; 
			b.Balance = 15; 


			b.Withdraw = 45; 
		
		
			Task tsk1 = new Task( delegate() { 
						Console.WriteLine("new task!");
			});  
			tsk1.Start(); 
			Console.WriteLine($"Inside Main {0}"); 
			tsk1.Wait(); 



			Console.WriteLine($"Final balance is {b.Balance}"); 
		} 
	}


} 

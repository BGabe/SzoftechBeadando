namespace BeadandoBeseGabor
{
	
	class Invoice
	{
		private int _id;
		private string _owner;
		private int _amount;

		public int id { get; set; }
		public string owner { get; set; }
		public int amount { get; set; }

		public Invoice(int id, string owner, int amount)
		{
			this.id = id;
			this.owner = owner;
			this.amount = amount;
		}
	}
}

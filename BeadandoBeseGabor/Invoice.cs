namespace BeadandoBeseGabor
{
	
	class Invoice
	{
		private int _id;
		private string _owner;
		private int _amount;

		public int id { get; set; }
		public int owner { get; set; }
		public int amount { get; set; }

		public Invoice(int id, string owner, int amount)
		{
			_id = id;
			_owner = owner;
			_amount = amount;
		}
	}
}

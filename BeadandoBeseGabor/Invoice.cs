namespace BeadandoBeseGabor
{
	
	class Invoice
	{
		private int _id { get; set; }
		private string _owner { get; set; }
		private int _amount { get; set; }

		public Invoice(int id, string owner, int amount)
		{
			_id = id;
			_owner = owner;
			_amount = amount;
		}
	}
}

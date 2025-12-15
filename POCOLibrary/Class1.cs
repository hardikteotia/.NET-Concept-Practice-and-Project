namespace POCOLibrary
{
    public class Product
    {
		private int _number;
		private string _name;
		private int _price;

		public int price
		{
			get { return _price; }
			set { _price = value; }
		}


		public string name
		{
			get { return _name; }
			set { _name = value; }
		}

		public int number
		{
			get { return _number; }
			set { _number = value; }
		}


	}
}

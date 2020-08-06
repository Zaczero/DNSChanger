namespace DNSChanger.Structs
{
	public class ComboBoxItem
	{
		private readonly string _text;
		public readonly object Value;
		
		public ComboBoxItem(string text)
		{
			_text = text;
			Value = text;
		}

		public ComboBoxItem(string text, object value)
		{
			_text = text;
			Value = value;
		}

		public override string ToString()
		{
			return _text;
		}
	}
}

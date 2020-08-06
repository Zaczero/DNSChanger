namespace DNSChanger.Structs
{
	public class ComboBoxItem
	{
		public readonly string Text;
		public readonly object Value;

		public ComboBoxItem(string text, object value)
		{
			Text = text;
			Value = value;
		}

		public override string ToString()
		{
			return Text;
		}
	}
}

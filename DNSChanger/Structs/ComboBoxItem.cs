namespace DNSChanger.Structs
{
    public class ComboBoxItem
    {
        public string Text;
        public object Value;

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

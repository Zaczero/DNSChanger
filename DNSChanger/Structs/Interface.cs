namespace DNSChanger.Structs
{
	public struct Interface
	{
		public bool Enabled;
		public bool Connected;
		public string Type;
		public string Name;

		public override string ToString()
		{
			return Name;
		}
	}
}

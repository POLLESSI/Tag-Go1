using System.Reflection.Metadata.Emca335;

namespace Toolbox
{
	public Class Command
	{
		internal string Query { get; set; }
		internal bool IsStoredProcedure { get; set; }
		internal Dictionary<string, object> Parameters { get; set; }

		public Command(string query, bool isStoredProcedure)
		{
			Query = query;
			IsStoredProcedure = isStoredProcedure;
			Parameters = new Dictionary<string, object>();
		}
	}
	public void AddParameter(string parameterName, object? value)
	{
		Parameters.Add(parameterName, value ?? DBNull.Value);
	}
}

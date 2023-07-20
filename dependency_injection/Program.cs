using System.Buffers.Text;

namespace dependency_injection
{
	class Program
	{
		static void Main(string[] args)
		{
			BaseDatabase baseDatabase = new BaseDatabase(new Oracle());
			baseDatabase.Connect();
        }
	}

	interface IDatabase
	{
		void Connect();
	}

	abstract class Database : IDatabase
	{
		protected string? basedatabase;

        public void Connect()
		{
			Console.WriteLine(basedatabase + " " + "Connected.");
		}
	}

	class BaseDatabase
	{
		IDatabase usingdatabase;
        public BaseDatabase(IDatabase database)
        {
            usingdatabase = database;
        }
        public void Connect()
		{
            usingdatabase.Connect();
        }
    }

	class Oracle : Database
	{
        public Oracle()
        {
			basedatabase = "Oracle";
        }
    }

    class MSsql : Database
    {
        public MSsql()
        {
            basedatabase = "MSsql";
        }
    }
}
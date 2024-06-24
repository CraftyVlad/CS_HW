class ApplicationException : Exception
{
    public ApplicationException(string message) : base(message)
    {
    }
}

class DatabaseException : ApplicationException
{
    public DatabaseException(string message) : base(message)
    {
    }
}

class ConnectionException : DatabaseException
{
    public ConnectionException(string message) : base(message)
    {
    }
}

class QueryException : DatabaseException
{
    public QueryException(string message) : base(message)
    {
    }
}

class Database
{
    public void Connect()
    {
        throw new ConnectionException("Failed to connect.");
    }

    public void ExecuteQuery()
    {
        throw new QueryException("Query error.");
    }
}

class Program
{
    static void Main()
    {
        Database db = new Database();

        try
        {
            db.Connect();
        }
        catch (ConnectionException ex)
        { 
            Console.WriteLine(ex.Message);
        }

        try
        {
            db.ExecuteQuery();
        }
        catch (QueryException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
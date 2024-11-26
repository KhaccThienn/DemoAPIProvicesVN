namespace DemoAPIProvicesVN.Infrastuctures.Abstracts
{
    public abstract class BaseScopeDbService : IDisposable
    {
        protected readonly OracleConnection Connection;

        protected BaseScopeDbService(string connectionString)
        {
            Connection = new OracleConnection(connectionString);
            Connection.Open();
        }

        protected OracleCommand CreateSpCommand(string spName)
        {
            var command = Connection.CreateCommand();
            command.CommandText = spName;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        protected Task<ResponseModel> ExecuteSpCommand(
        string spName,
        string paraMessName,
        string paraCodeName,
        Action<OracleParameterCollection> setParamAction = null)
        {
            var command = CreateSpCommand(spName);
            var parameters = command.Parameters;
            setParamAction?.Invoke(parameters);
            parameters.SetOutputParameter(paraCodeName, paraMessName);

            // Execute the Stored Procedure
            command.ExecuteNonQuery();

            // Get the output values
            var response = parameters.GetResponseModel(paraMessName, paraCodeName);
            return Task.FromResult(response);
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}

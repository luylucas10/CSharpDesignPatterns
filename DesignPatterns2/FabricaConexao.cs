//Factory
using System.Data;
using System.Data.SqlClient;

public class FabricaConexao
{
	// nomes abstratos
	public IDbConnection Nova() => new SqlConnection("");
}

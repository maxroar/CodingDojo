using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Options;
using loginReg.Models;

namespace loginReg.Factory
{
    public class UserFactory : IFactory<User> {
    private readonly IOptions<MySqlOptions> mysqlConfig;
    
    public UserFactory(IOptions<MySqlOptions> conf) {
            mysqlConfig = conf;
    }
    
    internal IDbConnection Connection {
      get {
         return new MySqlConnection(mysqlConfig.Value.ConnectionString);
      }
    }
    
}
}
 

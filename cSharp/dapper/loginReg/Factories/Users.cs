using Microsoft.Extensions.Options;
// Other usings

namespace loginReg
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
 

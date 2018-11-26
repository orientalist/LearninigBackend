using CoreMVCBackend.Model.SQL;
using Microsoft.Extensions.Options;
using MySql.Data;

namespace CoreMVCBackend.Utility
{
    public class ConfigHelper{

        private readonly IOptions<MySqlConnection> _MySqlConnection;        

        public ConfigHelper(IOptions<MySqlConnection> Connection){
            _MySqlConnection=Connection;
        }

        public string ConnectionString{
            get{    
                string str=string.Format("server={0};user={1};database={2};port={3};password={4};charset={5};",
                _MySqlConnection.Value.RDS_Hostname,
                _MySqlConnection.Value.RDS_User,
                _MySqlConnection.Value.RDS_DBName,
                "3306",
                _MySqlConnection.Value.RDS_Password,
                _MySqlConnection.Value.RDS_Charset);
                
                return str;
            }
        }
    }
}
using CoreMVCBackend.Model.User;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CoreMVCBackend.Service.User{
    public class MemberData:BaseData{
        
        public AccountModel Create(string Acc,string Pass,string Conn){            

            AccountModel result=new AccountModel();

            
            using(MySqlConnection conn=new MySqlConnection(Conn)){
                conn.Open();

                SQLs.Clear();
                SQLs.AppendLine("SELECT * ");
                SQLs.AppendLine("FROM CoreMVCBackend.Account ");

                MySqlCommand cmd=new MySqlCommand(SQLs.ToString(),conn);
                MySqlDataReader rdr=cmd.ExecuteReader();
                                
            }

            return null;
        }
    }
}
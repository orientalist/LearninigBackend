using CoreMVCBackend.Model.User;
using MySql.Data.MySqlClient;
using Dapper;

namespace CoreMVCBackend.Service.User{
    public class MemberData:BaseData{
        
        public AccountModel Create(string Acc,string Pass,string Conn){            

            AccountModel result=new AccountModel();

            using(MySqlConnection conn=new MySqlConnection(Conn)){
                
                SQLs.Clear();
                SQLs.AppendLine("SELECT * ");
                SQLs.AppendLine("FROM CoreMVCBackend.Account ");
                SQLs.AppendLine("WHERE Account_Account LIKE @Account_Account ");

                var query=conn.QueryFirstOrDefault<AccountModel>(SQLs.ToString(),new {Account_Account="%"+Acc+"%"});
                string a="";
            }

            return null;
        }
    }
}
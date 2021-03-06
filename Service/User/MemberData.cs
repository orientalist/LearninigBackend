using CoreMVCBackend.Model.User;
using MySql.Data.MySqlClient;
using Dapper;
using System;
using CoreMVCBackend.Service.Core;
using System.Collections.Generic;
using CoreMVCBackend.Utility;

namespace CoreMVCBackend.Service.User{
    public class MemberData:BaseData{
        
        public AccountModel Create(string Acc,string Pass,string Conn){            

            AccountModel result=new AccountModel();


            using(MySqlConnection conn=new MySqlConnection(Conn)){
                
                    SQLs.Clear();
                    SQLs.AppendLine("SELECT * ");
                    SQLs.AppendLine("FROM CoreMVCBackend.Account ");
                    SQLs.AppendLine("WHERE Account_Account=@Account_Account ");

                    List<AccountModel> query=conn.Query<AccountModel>(SQLs.ToString(),new {Account_Account=Acc})
                    .AsList();

                    if(query.Count==0){
                        throw new LogInException("202","查無該帳號");
                    }                    

                    if(query.Count>1){
                        throw new LogInException("202","帳號異常,重複註冊");                    
                    }


                    #region 重複嘗試失敗
                    #endregion 重複嘗試失敗

                    var User=query[0];
                    if(!EncodeHelper.Encode(EncodeEnum.SHA1,Pass).Equals(User.Account_Password)){
                        throw new LogInException("202","密碼錯誤");
                    }

                    result=User;
                }
            return result;
        }

        public bool CheckDBStatus(string conn){

            bool result=false;

            using(MySqlConnection sConn=new MySqlConnection(conn)){
                try{
                    sConn.Open();
                    result=true;
                }                
                catch(Exception ex){
                    result=false;
                }                
            }
            return result;
        }
    }
}
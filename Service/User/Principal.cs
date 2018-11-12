using System.Security.Principal;
using CoreMVCBackend.Model.User;
using Microsoft.Extensions.Options;
using CoreMVCBackend.Model.SQL;

namespace CoreMVCBackend.Service.User{
    public class Principal:IPrincipal,IUserModel{
        #region IPrincipal
        ///<summary>
        ///目前使用者識別
        ///</summary>
        public IIdentity Identity{get;set;}
        ///<summary>
        ///判斷目前使用者角色
        ///</summary>
        public bool IsInRole(string role){return false;}
        #endregion

        #region IUserModel
        public string Account_ID{get;set;}
        public string Account_Account{get;set;}
        public string Account_Name{get;set;}        
        #endregion

        public Principal(){}

        public static AccountModel Create(string Acc,string Pass,string conn){

            AccountModel result=new MemberData().Create(Acc,Pass,conn);

            return result;
        }        

        public static bool CheckDBStatus(string conn){
            return new MemberData().CheckDBStatus(conn);
        }
    }
}
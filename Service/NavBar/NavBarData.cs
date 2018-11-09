using CoreMVCBackend.Model.NavBar;
using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;

namespace CoreMVCBackend.Service.NavBar{
    public class NavBarData:BaseData{

        public bool CreateNavBarItem(NavBarItemModel model,string conn){

            using(MySqlConnection sConn=new MySqlConnection(conn)){

                bool result=false;
                SQLs.Clear();
                SQLs.AppendLine("INSERT INTO CoreMVCBackend.NavBarItems ");
                SQLs.AppendLine("(ItemName,ItemController,ItemAction,ItemStatus) ");
                SQLs.AppendLine("Values ");
                SQLs.AppendLine("(@ItemName,'NavBar',@ItemAction,@ItemStatus) ");

                object param=new{
                    ItemName=model.ItemName,                    
                    ItemAction=model.ItemAction,
                    ItemStatus=model.ItemStatus
                };

                result=sConn.Execute(SQLs.ToString(),param)==0?false:true;

                return result;
            }
        }

        public IEnumerable<NavBarItemModel> QueryNavBarItem(string conn){

            using(MySqlConnection sConn=new MySqlConnection(conn)){
                SQLs.Clear();
                SQLs.AppendLine("SELECT * ");
                SQLs.AppendLine("FROM CoreMVCBackend.NavBarItems ");            
            
                var items=sConn.Query<NavBarItemModel>(SQLs.ToString());

                return items;
            }            
        }
    }
}
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
        
        public bool ModifyNavBarItem(NavBarItemModel model,string conn){

            using(MySqlConnection sConn=new MySqlConnection(conn)){

                bool result=false;
                SQLs.Clear();
                SQLs.AppendLine("UPDATE CoreMVCBackend.NavBarItems ");
                SQLs.AppendLine("SET ItemName=@ItemName,ItemController=@ItemController, ");
                SQLs.AppendLine("ItemAction=@ItemAction,ItemStatus=@ItemStatus ");
                SQLs.AppendLine("WHERE ");
                SQLs.AppendLine("ID=@ID ");

                object param=new{
                    ID=model.ID,
                    ItemName=model.ItemName,
                    ItemController=model.ItemController,                    
                    ItemAction=model.ItemAction,
                    ItemStatus=model.ItemStatus
                };

                result=sConn.Execute(SQLs.ToString(),param)==0?false:true;

                return result;
            }

        }

        public bool DeleteNavBarItem(int id,string conn){
            using(MySqlConnection sConn=new MySqlConnection(conn)){

                bool Result=false;
                SQLs.Clear();
                SQLs.AppendLine("UPDATE CoreMVCBackend.NavBarItems ");
                SQLs.AppendLine("SET ItemStatus=3 ");
                SQLs.AppendLine("WHERE ID=@ID ");

                object param=new{
                    ID=id
                };

                Result=sConn.Execute(SQLs.ToString(),param)==0?false:true;

                return Result;
            }
        }

        public IEnumerable<NavBarItemModel> QueryNavBarItem(string conn){

            using(MySqlConnection sConn=new MySqlConnection(conn)){
                SQLs.Clear();
                SQLs.AppendLine("SELECT * ");
                SQLs.AppendLine("FROM CoreMVCBackend.NavBarItems "); 
                SQLs.AppendLine("WHERE ItemStatus!=3 ");           
            
                var items=sConn.Query<NavBarItemModel>(SQLs.ToString());

                return items;
            }            
        }
    }
}
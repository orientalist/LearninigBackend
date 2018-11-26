using CoreMVCBackend.Model.DailyNews;
using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;

namespace CoreMVCBackend.Service.DailyNews{
    public class DailyNewsData:BaseData{
        public bool CreateDailyNews(CoreMVCBackend.Model.DailyNews.DailyNews DailyNews,string Conn){
            using(MySqlConnection sqlConnection=new MySqlConnection(Conn)){
                bool result=false;
                SQLs.Clear();
                SQLs.AppendLine("INSERT into CoreMVCBackend.DailyNews ");
                SQLs.AppendLine("(NewsDate,Subject,Context,Status) ");
                SQLs.AppendLine("VALUES ");
                SQLs.AppendLine("(@NewsDate,@Subject,@Context,@Status) ");

                object param=new{
                    NewsDate=DailyNews.NewsDate,
                    Subject=DailyNews.Subject,
                    Context=DailyNews.Context,
                    Status=DailyNews.Status
                };

                result=sqlConnection.Execute(SQLs.ToString(),param)==0?false:true;

                return result;
            }
        }
    }
}
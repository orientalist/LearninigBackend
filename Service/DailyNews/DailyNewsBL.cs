using CoreMVCBackend.Model.DailyNews;
using System.Collections.Generic;
using System;

namespace CoreMVCBackend.Service.DailyNews{
    public class DailyNewsBL{
        private DailyNewsData _dailyNewsData;

        public DailyNewsBL(){
            _dailyNewsData=new DailyNewsData();
        }

        public bool CreateDailyNews(CoreMVCBackend.Model.DailyNews.DailyNews DailyNews,string Conn){
            if(DailyNews.NewsDate==null||string.IsNullOrWhiteSpace(DailyNews.Subject)||string.IsNullOrWhiteSpace(DailyNews.Context)){
                throw new Exception("參數遺失");
            }
            else{
                return _dailyNewsData.CreateDailyNews(DailyNews,Conn);
            }
        }
    }
}
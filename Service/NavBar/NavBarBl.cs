using CoreMVCBackend.Model.NavBar;
using System.Collections.Generic;

namespace CoreMVCBackend.Service.NavBar{
    public class NavBarBl{
        private NavBarData _navBarData;

        public NavBarBl(){
            _navBarData=new NavBarData();
        }

        public bool CreateNavBarItem(NavBarItemModel model,string conn){
            if(string.IsNullOrWhiteSpace(model.ItemName)){
                throw new System.Exception("名稱未填");
            }
            if(string.IsNullOrWhiteSpace(model.ItemController)){
                throw new System.Exception("控制器未填");
            }
            if(string.IsNullOrWhiteSpace(model.ItemAction)){
                throw new System.Exception("方法未填");
            }
            return _navBarData.CreateNavBarItem(model,conn);
        }

        public bool ModifyNavBarItem(NavBarItemModel model,string conn){
            if(string.IsNullOrWhiteSpace(model.ItemName)){
                throw new System.Exception("名稱未填");
            }
            if(string.IsNullOrWhiteSpace(model.ItemController)){
                throw new System.Exception("控制器未填");
            }
            if(string.IsNullOrWhiteSpace(model.ItemAction)){
                throw new System.Exception("方法未填");
            }
            return _navBarData.ModifyNavBarItem(model,conn);
        }

        public bool DeleteNavBarItem(int id,string conn){
            return _navBarData.DeleteNavBarItem(id,conn);
        }
        public IEnumerable<NavBarItemModel> QueryNavBarItem(string conn){
            return _navBarData.QueryNavBarItem(conn);
        }
    }
}
using CoreMVCBackend.Model.NavBar;
using System.Collections.Generic;

namespace CoreMVCBackend.Service.NavBar{
    public class NavBarBl{
        private NavBarData _navBarData;

        public NavBarBl(){
            _navBarData=new NavBarData();
        }

        public bool CreateNavBarItem(NavBarItemModel model,string conn){

            return _navBarData.CreateNavBarItem(model,conn);
        }

        public IEnumerable<NavBarItemModel> QueryNavBarItem(string conn){
            return _navBarData.QueryNavBarItem(conn);
        }
    }
}
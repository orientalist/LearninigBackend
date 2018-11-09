namespace CoreMVCBackend.Model.NavBar{
    public class NavBarItemModel{
        public int ID{get;set;}

        public string ItemName{get;set;}

        public string ItemController{get;set;}

        public string ItemAction{get;set;}

        public int ItemStatus{get;set;}

        public string ItemStatus_Desc{
            get{
                if(ItemStatus==1){
                    return "顯示";
                }
                else{
                    return "隱藏";
                }
            }
        }
    }
}
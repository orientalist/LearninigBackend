namespace CoreMVCBackend{
    public class ResponseModel{

        public ResponseModel(){}
        public ResponseModel(string status,string msg){
            this.HttpStatus=status;
            this.Message=msg;
        }

        public string HttpStatus{get;set;}

        public string Message{get;set;}

        public object Data{get;set;}
    }
}
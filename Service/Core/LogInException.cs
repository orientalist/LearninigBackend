using System;

namespace CoreMVCBackend.Service.Core{
    public class LogInException:Exception{
        private string _Key=string.Empty;

        public string Key{
            get{return _Key;}
        }

        private string _Param=string.Empty;

        public string Param{
            get{return _Param;}
        }

        public LogInException(string key,string message)
        :base(message){
            _Key=key;
        }

        public LogInException(string key,string message,string param)
        :base(message){
            _Key=key;
            _Param=param;
        }
    }
}
using System.Text;
using CoreMVCBackend.Utility;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using CoreMVCBackend.Model.SQL;

namespace CoreMVCBackend.Service{
    public class BaseData{        
        protected StringBuilder SQLs=new StringBuilder();        
        
        public BaseData(){            
        }
    }
}
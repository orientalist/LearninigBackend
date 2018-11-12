using Microsoft.AspNetCore.Mvc;
using CoreMVCBackend.Utility;
using CoreMVCBackend.Model.SQL;
using Microsoft.Extensions.Options;

namespace CoreMVCBackend.Backend{
    public class BaseController:Controller{
        protected IOptions<MySqlConnection> _MySqlConnection;
        protected ConfigHelper ConfigHelper;          
        
    }
}
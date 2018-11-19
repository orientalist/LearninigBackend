using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using CoreMVCBackend.Models;
using Microsoft.Extensions.Options;
using CoreMVCBackend.Model.SQL;

namespace CoreMVCBackend.Backend{
    public class BackendController:BaseController{        

        public IActionResult Index(){            
            
            if(!CheckAccount(HttpContext)){
                return View("LogIn");
            }

            
            return View();
        }

        public IActionResult NavBar(){
            return PartialView();
        }
        private bool CheckAccount(HttpContext context){
            try{
                string str=context.Session.GetString(Key_Storage.UserName);
                if(string.IsNullOrWhiteSpace(str)){
                    return false;
                }
                return true;
            }
            catch(Exception ex){
                return false;
            }
        }
    }
}
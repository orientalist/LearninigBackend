using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CoreMVCBackend.Models;
using CoreMVCBackend.Service.User;
using CoreMVCBackend.Model.User;
using System;
using Microsoft.Extensions.Options;
using CoreMVCBackend.Model.SQL;
using CoreMVCBackend.Utility;

namespace CoreMVCBackend.Backend{
    public class WebAPIsController:BaseController{

        private readonly IOptions<MySqlConnection> _MySqlConnection;
        public WebAPIsController(IOptions<MySqlConnection> Connection){
            _MySqlConnection=Connection;
        }

        [HttpPost]        
        public IActionResult LogIn(){

            ResponseModel Result=new ResponseModel();

            LogInModel account=new LogInModel(){
                Account_Account=Request.Form["Account_Account"],
                Account_Password=Request.Form["Account_Password"]
            };

            AccountModel user;

            try{
                if(ModelState.IsValid){

                    ConfigHelper cof=new ConfigHelper(_MySqlConnection);
                    user=Principal.Create(account.Account_Account,account.Account_Password,cof.ConnectionString);
                }
            }
            catch(Exception ex){

            }
            

            return null;
        }
    }
}
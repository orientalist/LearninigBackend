using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CoreMVCBackend.Models;
using CoreMVCBackend.Service.User;
using CoreMVCBackend.Model.User;
using System;
using Microsoft.Extensions.Options;
using CoreMVCBackend.Model.SQL;
using CoreMVCBackend.Utility;
using CoreMVCBackend.Service.Core;
using Newtonsoft.Json;
using CoreMVCBackend.Model.NavBar;
using CoreMVCBackend.Service.NavBar;
using System.Collections.Generic;

namespace CoreMVCBackend.Backend{
    public class WebAPIsController:BaseController{

        private readonly IOptions<MySqlConnection> _MySqlConnection;              
        private ConfigHelper ConfigHelper;          
        public WebAPIsController(IOptions<MySqlConnection> Connection){
            _MySqlConnection=Connection;
            ConfigHelper=new ConfigHelper(_MySqlConnection);
        }        

        private NavBarBl navBarBl;

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
                    user=Principal.Create(account.Account_Account,account.Account_Password,ConfigHelper.ConnectionString);
                    
                    SetUserSession(user);
                    Result.HttpStatus="1";   
                    Result.Message="ok";                
                }
            }
            catch(LogInException ex){
                Result.HttpStatus=ex.Key;
                Result.Message=ex.Message;                
            }
            catch(Exception ex){
                switch(ex.Source){
                    case "MySql.Data":
                    throw new LogInException("510","伺服器發生錯誤。");                    
                }                                
            }    
            return Json(Result);
        }

        [HttpPost]
        public IActionResult CreateNavBarItem(){
            
            ResponseModel Result=new ResponseModel();

            NavBarItemModel model=new NavBarItemModel(){
                ItemName=Request.Form["NavName"],
                ItemAction=Request.Form["ActionName"],
                ItemStatus=Int32.Parse(Request.Form["NavStatus"])
            };

            try{
                navBarBl=new NavBarBl();
                if(navBarBl.CreateNavBarItem(model,ConfigHelper.ConnectionString)){
                    Result.HttpStatus="1";
                    Result.Message="OK";
                }
                else{
                    Result.HttpStatus="0";
                    Result.Message="NOK";
                }
            }
            catch(Exception ex){}

            return Json(Result);
        }

        [HttpPost]
        public IActionResult QueryNavBarItem(){
            ResponseModel Result=new ResponseModel();
            try{
                navBarBl=new NavBarBl();
                IEnumerable<NavBarItemModel> Items=navBarBl.QueryNavBarItem(ConfigHelper.ConnectionString);
                Result.HttpStatus="1";
                Result.Message="OK";
                Result.Data=Items;
            }
            catch(Exception ex){

            }
            return Json(Result);
        }
        public void SetUserSession(AccountModel user){
            HttpContext.Session.SetString(Key_Storage.UserAccount,user.Account_Account);
        }
    }
}
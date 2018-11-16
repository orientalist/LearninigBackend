using Microsoft.AspNetCore.Mvc;
using CoreMVCBackend.Utility;
using System;

namespace CoreMVCBackend.Backend{
    public class WebAPIs_ToolsController:BaseController{
        public IActionResult Encode(){
            ResponseModel Result=new ResponseModel();            
            try{
                var TxtToEncode=Request.Form["txt"];
                if(!string.IsNullOrWhiteSpace(TxtToEncode)){                                        
                    object EncodeType=Enum.Parse(typeof(EncodeEnum),Request.Form["CMD"].ToString());
                    TxtToEncode=EncodeHelper.Encode(EncodeType,TxtToEncode);                    
                }
                if(!string.IsNullOrWhiteSpace(TxtToEncode)){
                    Result.HttpStatus="1";
                    Result.Message=TxtToEncode;
                }
            }
            catch(Exception ex){
                Result.HttpStatus="0";
                Result.Message=ex.Message;
            }            
            return Json(Result);
        }
    }
}
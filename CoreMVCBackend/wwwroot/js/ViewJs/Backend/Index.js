$(document).ready(function(){
    $("#MenuList").accordion();
    $("#MenuList button").button();
    fnGetUserName();
});
var GetPage=function(Controller,Action){
    var urlStr="/"+Controller+"/"+Action;        
    $.ajax({
        type:"POST",
        url:urlStr
    }).done(function(content){
        $("#Content").html(content);
    });
}
var fnLogOut=function(){
    if(confirm("確定登出?")){
        location.href="/WebAPIs/LogOut";
    }
}
var fnGetUserName=function(){
    $.ajax({
        url:"/WebAPIs/GetUserName",
        type:"POST"
    }).done(function(result){
        if(result.httpStatus==1){
            $("#UserName").text("歡迎"+result.message);
        }
    });
}
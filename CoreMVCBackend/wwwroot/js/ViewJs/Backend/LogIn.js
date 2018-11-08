$(document).ready(function(){
    InitView();
    $("#btnLogIn").click(function(){
        if(ValidateInpit()){
            var Data={
                Account_Account:$("#Account_Account").val(),
                Account_Password:$("#Account_Password").val()
            };
            
            $.ajax({
                url:"/WebAPIs/Login",
                type:"POST",                
                data:Data
            }).done(function(result){
                console.log(result);
            });
        }
    });
                
});
var InitView=function(){
    var width=$("#divForm").width();
    var height=$("#divForm").height();
    width=width+50;
    height=height+50;
    $("#loginForm").width(width);
    $("#loginForm").height(height);
}
var ValidateInpit=function(){
    if($("#Account_Account").val().length==0){
        $("#ErrorMsg").text("帳號未輸入");
            return false;
        }                
        if($("#Account_Password").val().length==0){
            $("#ErrorMsg").text("密碼未輸入");
            return false;
        }
    return true;
}
$(document).ready(function(){
    $(".PageBody button").button();
    //fnGetControllers();

});
var OpenCreateTable=function(){
    $("#NavBarItemCreate").show();
    $("#NavBarItemQuery").hide();
}
var QueryNavItem=function(){
    $("#NavBarItemCreate").hide();
    $("#NavBarItemQuery").show();
    fnQueryNavBarItem();
}
var CreateAction=function(){     
    var Data={
            ItemName:$("#NavName").val(),
            ItemController:"NavBar",
            ItemAction:$("#ActionName").val(),
            ItemStatus:$("input[type=radio]:checked").val()
        };   
    if(fnValidate(Data)){
        $.ajax({
            url:"/WebAPIs/CreateNavBarItem",
            type:"POST",
            data:Data
        }).done(function(result){
            alert(result.message);
        });
    }                
}    
var fnQueryNavBarItem=function(){
    $("#NavBarItemTh").nextAll().remove();
    $.ajax({
        url:"/WebAPIs/QueryNavBarItem",
        type:"POST"                
    }).done(function(result){            
        $.each(result.data,function(index,value){                
            var tr="<tr id='NavItem"+value.id+"'>"
                    +"<td>"+value.id+"</td>"
                    +"<td><input name='NavBarName' type='text' value='"+value.itemName+"'></td>"
                    +"<td><input name='NavBarController' type='text' value='"+value.itemController+"'></td>"
                    +"<td><input name='NavBarAction' type='text' value='"+value.itemAction+"'></td>"
                    +"<td><input name='NavStatus_"+value.id+"' type='radio' value='1' name='NavStatus_"+value.id+"'>顯示<br><input type='radio' value='0' name='NavStatus_"+value.id+"'>隱藏</td>"
                    +"<td><button onclick='fnModefyNavBarItem("+value.id+")'>修改</button><button onclick='fnDeleteNavBarItem("+value.id+")''>刪除</button></td>"
                +"<tr/>";                                        
            $("#NavBarItemTh").after(tr);
            var radioName="NavStatus_"+value.id;
            if(value.itemStatus==1){                    
                $("input[name='"+radioName+"']")[0].checked=true;
            }
            else{                    
                $("input[name='"+radioName+"']")[1].checked=true;
            }                
        });
    });
}
var fnModefyNavBarItem=function(id){
    if(confirm("確定修改?")){
        var idName="#NavItem"+id;
        var radioName="NavStatus_"+id;
        var NavBarItem={
            ID:id,
            ItemName:$(idName).find("input[name='NavBarName']").val(),
            ItemController:$(idName).find("input[name='NavBarController']").val(),
            ItemAction:$(idName).find("input[name='NavBarAction']").val(),
            ItemStatus:$(idName).find("input[name='"+radioName+"']:checked").val()
        };
        if(fnValidate(NavBarItem)){
            $.ajax({
                url:"/WebAPIs/ModifyNavBarItem",
                type:"POST",
                data:NavBarItem
            }).done(function(result){
                alert(result.message);
                fnQueryNavBarItem();
            });
        }   
    }
}
var fnDeleteNavBarItem=function(id){
    if(confirm("確定刪除?")){
        $.ajax({
            url:"/WebAPIs/DeleteNavBarItem",
            type:"POST",
            data:{id:id}
        }).done(function(result){
            alert(result.message);
            fnQueryNavBarItem();
        });
    }
}
var fnValidate=function(NavBarItem){
    if(NavBarItem.ItemName.length==0){
        alert("名稱未填");
        return false;
    }
    if(NavBarItem.ItemController.length==0){
        alert("控制器未填");
        return false;
    }
    if(NavBarItem.ItemAction.length==0){
        alert("方法未填");
        return false;
    }
    return true;
}
var fnGetControllers=function(){
    $.ajax({
        type:"POST",
        url:"/WebAPIs/GetControllers"
    }).done(function(result){
        
    });
}
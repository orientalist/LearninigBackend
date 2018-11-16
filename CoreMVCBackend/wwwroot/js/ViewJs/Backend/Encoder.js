$(document).ready(function(){
    $(".PageBody button").button();
    $(".btnEncode").click(fnEncode);
});
var fnEncode=function(){    
    var type=$(this).text();
    var input="#"+type+"Txt";
    var resultSpan="#"+type+"_ed";
    var Data={
        CMD:type,
        txt:$(input).val(),        
    }    
    if(Data.txt.length>0){
        $.ajax({
            url:"/WebAPIs_Tools/Encode",
            type:"POST",
            data:Data
        }).done(function(result){            
            $(resultSpan).text(result.message);
        });
    }
}
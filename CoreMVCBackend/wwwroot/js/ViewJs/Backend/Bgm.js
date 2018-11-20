var audio;
$(document).ready(function(){
    audio=new Audio("../../Resources/LogIn.mp3");
    audio.pause();
    var AudioStopImg="/images/speaker-stop.png";
    var AudioPlayingImg="/images/speaker.png";
    $("#audio").click(function(){
        if($(this).hasClass("playing")){
            $(this).removeClass("playing");
            $(this).addClass("stop");
            $(this).attr("src",AudioStopImg);
            audio.pause();
        }
        else if($(this).hasClass("stop")){
            $(this).removeClass("stop");
            $(this).addClass("playing");
            $(this).attr("src",AudioPlayingImg);
            audio.play();
        }
    });
});
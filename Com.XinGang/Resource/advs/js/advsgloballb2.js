
$(document).ready(function() {
	
	var AO=$("#advsLbDiv");

		AO.css({background:$(".advsLbList:eq(0)")[0].style.background}); 
		AO.find("a").attr("href",$(".advsLbList:eq(0)").find("a").attr("href"));


	setInterval("$().advsLbRoll()", 5000);


	(function($){

		$.fn.advsLbRoll = function(){
			var AO=$("#advsLbDiv");
			var nextI;

			var T=$(".advsLbList").size();
			
			for(i=0;i<T;i++){
				if($(".advsLbList:eq("+i+")")[0].style.backgroundImage==AO[0].style.backgroundImage){
					if(i>=T-1){
						nextI=0;
					}else{
						nextI=i+1;
					}
					
					AO.animate({opacity: '0'},500,function(){
						AO.css({background:$(".advsLbList:eq("+nextI+")")[0].style.background}); 
						AO.animate({opacity: '1'},500);
						AO.find("a").attr("href",$(".advsLbList:eq("+nextI+")").find("a").attr("href"));
					});
					break;
				}
			}

		};

	})(jQuery);

});



$(document).ready(function(){
  $("img").click(function(){
    $(this).attr("src",$(this).data("alt-src"));
  });
});

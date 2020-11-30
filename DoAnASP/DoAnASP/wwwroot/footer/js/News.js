let iconResponsive = document.getElementById("icon-responsive")
let menuResponsive = document.getElementsByClassName("menu-responsive")
menuResponsive[0].style.display="none";
iconResponsive.addEventListener("click", function(){
  if(menuResponsive[0].style.display=="none"){
    menuResponsive[0].style.display="block";
  }
  else{
    menuResponsive[0].style.display="none";
  }
});
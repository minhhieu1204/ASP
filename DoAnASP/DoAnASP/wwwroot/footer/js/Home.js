// let src = ["../img/1.jpg", "../img/2.jpg", "../img/3.jpg", "../img/4.jpg"];

// let counter = 1;
// setInterval(function () {
//   if (document.getElementById('r1').checked == true) {
//     document.getElementById("click1").style.background = "#02A388";
//     document.getElementById("click2").style.background = "white";
//     document.getElementById("click3").style.background = "white";
//     document.getElementById("click4").style.background = "white";
//     document.getElementById("img-animation").src = src[0];
//     // document.getElementById("img-animation").classList.remove("demo-animation");
//     document.getElementById("img-animation").classList.add("demo-animation");

//   }
//   if (document.getElementById('r2').checked == true) {
//     document.getElementById("click2").style.background = "#02A388";
//     document.getElementById("click1").style.background = "white";
//     document.getElementById("click3").style.background = "white";
//     document.getElementById("click4").style.background = "white";
//     document.getElementById("img-animation").src = src[1];
//     document.getElementById("img-animation").classList.remove("demo-animation");
//     document.getElementById("img-animation").classList.add("demo-animation");
//   }
//   if (document.getElementById('r3').checked == true) {
//     document.getElementById("click3").style.background = "#02A388";
//     document.getElementById("click2").style.background = "white";
//     document.getElementById("click1").style.background = "white";
//     document.getElementById("click4").style.background = "white";
//     document.getElementById("img-animation").src = src[2];
//     document.getElementById("img-animation").classList.remove("demo-animation");
//     document.getElementById("img-animation").classList.add("demo-animation");
//   }
//   if (document.getElementById('r4').checked == true) {
//     document.getElementById("click4").style.background = "#02A388";
//     document.getElementById("click2").style.background = "white";
//     document.getElementById("click3").style.background = "white";
//     document.getElementById("click1").style.background = "white";
//     document.getElementById("img-animation").src = src[3];
//     document.getElementById("img-animation").classList.remove("demo-animation");
//     document.getElementById("img-animation").classList.add("demo-animation");
//   }
//   document.getElementById('r' + counter).checked = true;
//   counter++;
//   if (counter > 4) {
//     counter = 1;
//   }
// }, 2000);

function openSearch() {
  closeSearch();
  var y = document.getElementById("close-search");
  if (y.className === "fas fa-search") {
    y.className = "fas fa-times";
  } else {
    y.className = "fas fa-search";
  }
}


let x = document.getElementById("search");
x.style.display = "none";

function closeSearch() {
  if (x.style.display === "none") {
    x.style.display = "block";
  } else {
    x.style.display = "none";
  }
}


function myTrailer() {
  let x = document.getElementById("hide-img-trailer");
  let y = document.getElementById("hide-btn-play-trailer");
  let z = document.getElementById("open-iframe-trailer");
  x.style.visibility = "hidden";
  y.style.display = "none";
  z.style.display = "block";
}


function showMenu() {
  let iconResponsive = document.getElementById("icon-responsive")
  let menuResponsive = document.getElementsByClassName("menu-responsive")
  menuResponsive[0].style.display = "none";
  iconResponsive.addEventListener("click", function () {
    if (menuResponsive[0].style.display == "none") {
      menuResponsive[0].style.display = "block";
    } else {
      menuResponsive[0].style.display = "none";
    }
  });
}
showMenu();


let btnNext = document.getElementsByClassName("next")[0];
let btnPrev = document.getElementsByClassName("prev")[0];
let carousel = document.getElementsByClassName("carousel-inner")[0];
function Sroll(){
  btnNext.addEventListener("click" , function(){
    carousel.style.transform = "translate3d(-280px, 0px, 0px)";
  });
}

let maskLogin = document.getElementById("mask-login");
let bannerButtonLogin = document.getElementById("banner-btn-login");
let popupLogin = document.getElementsByClassName("popup-login")[0];
function showPopupLogin(){
  bannerButtonLogin.addEventListener("click" , function(){
    popupLogin.style.display = "block";
    maskLogin.style.display ="block";
  });
}
showPopupLogin();

let btnClosePopupLogin = document.getElementsByClassName("close-login-popup")[0];
function closePopupLogin(){
  btnClosePopupLogin.addEventListener("click" , function(){
    popupLogin.style.display = "none";
    maskLogin.style.display ="none";
  });
}
closePopupLogin();


let btnOnTop = document.getElementById("back-top");
btnOnTop.addEventListener("click", topFunction);
window.onscroll = function() {scrollFunction()};

function scrollFunction() {
  if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
    btnOnTop.style.display = "block";
  } else {
    btnOnTop.style.display = "none";
  }
}
function topFunction() {
  document.documentElement.scrollTo({top:0,behavior:'smooth'});
}





let src = document.getElementsByClassName("img-animation");

let counter = 1;
document.getElementById('r1').checked == true;
document.getElementById("click1").style.background = "#02A388";
setInterval(function () {
  if (document.getElementById('r1').checked == true) {
    document.getElementById("click1").style.background = "#02A388";
    document.getElementById("click2").style.background = "white";
    document.getElementById("click3").style.background = "white";
    document.getElementById("click4").style.background = "white";
    src[0].style.display="block";
    src[1].style.display="none";
    src[2].style.display="none";
    src[3].style.display="none";
    counter = 2;
  }
  if (document.getElementById('r2').checked == true) {
    document.getElementById("click2").style.background = "#02A388";
    document.getElementById("click1").style.background = "white";
    document.getElementById("click3").style.background = "white";
    document.getElementById("click4").style.background = "white";
    src[1].style.display="block";
    src[0].style.display="none";
    src[2].style.display="none";
    src[3].style.display="none";
    counter = 3;
  }
  if (document.getElementById('r3').checked == true) {
    document.getElementById("click3").style.background = "#02A388";
    document.getElementById("click2").style.background = "white";
    document.getElementById("click1").style.background = "white";
    document.getElementById("click4").style.background = "white";
    src[2].style.display="block";
    src[0].style.display="none";
    src[1].style.display="none";
    src[3].style.display="none";
    counter = 4;
  }
  if (document.getElementById('r4').checked == true) {
    document.getElementById("click4").style.background = "#02A388";
    document.getElementById("click2").style.background = "white";
    document.getElementById("click3").style.background = "white";
    document.getElementById("click1").style.background = "white";
    src[3].style.display="block";
    src[0].style.display="none";
    src[1].style.display="none";
    src[2].style.display="none";
    counter = 1;
  }
  document.getElementById('r' + counter).checked = true;
  counter++;
  if (counter > 4) {
    counter = 1;
  }
}, 5000);


let iconSortDown =document.getElementsByClassName("fa-sort-down");
let iconSortUp = document.getElementsByClassName("fa-sort-up");
let btnMidResponsive = document.getElementsByClassName("sort-down");
let contentInResponsive = document.getElementsByClassName("start-movie-responsive");
let tam = 0;
function sortDown(){
  for(let i=0 ; i< btnMidResponsive.length ; i++)
  {
    const styles = window.getComputedStyle(contentInResponsive[i]);
    btnMidResponsive[i].addEventListener("click" , function(){
      btnMidResponsive[i].style.background= "#1D2526";
      if( styles.display=="none"){
        contentInResponsive[tam].style.display="none";
        btnMidResponsive[tam].style.background= "black";
        contentInResponsive[i].style.display="block";
        tam = i;
      }
      else{
        contentInResponsive[i].style.display="none";
        btnMidResponsive[i].style.background= "black";
      }
    });
  }
}
sortDown();
let x = document.getElementById("search");
x.style.display = "none";
function openCloseInputSearch() {
  if (x.style.display === "none") {
    x.style.display = "block";
  } else {
    x.style.display = "none";
  }
}

function openCloseIconSearch() {
    openCloseInputSearch();
    let y = document.getElementById("close-search");
    if (y.className === "fas fa-search") {
      y.className = "fas fa-times";
    } else {
      y.className = "fas fa-search";
    }
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

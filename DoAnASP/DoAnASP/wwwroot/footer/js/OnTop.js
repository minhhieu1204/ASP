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




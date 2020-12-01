let btnMidSeries = document.getElementsByClassName("sort-down");
let contentInSeries = document.getElementsByClassName("end-movie-responsive");
let tamSeries = 0;
function sortDownSeries(){
  for(let i=0 ; i< btnMidSeries.length ; i++)
  {
    const styles = window.getComputedStyle(contentInSeries[i]);
    btnMidSeries[i].addEventListener("click" , function(){
      btnMidSeries[i].style.background= "#1D2526";
      if( styles.display=="none"){
        contentInSeries[tamSeries].style.display="none";
        btnMidSeries[tamSeries].style.background= "black";
        contentInSeries[i].style.display="block";
        tamSeries = i;
      }
      else{
        contentInSeries[i].style.display="none";
        btnMidSeries[i].style.background= "black";
      }
    });
  }
}
sortDownSeries();



let row = document.getElementsByTagName("tr");
console.log(row);
for (let i = 0; i < row.length; i++){
    if(i%2 != 0){
        row[i].style.backgroundColor="#F5F5F5";
    }
}

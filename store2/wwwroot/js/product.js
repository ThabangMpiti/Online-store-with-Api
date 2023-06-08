window.addEventListener('load', () => {
    
    document.getElementById("DproductName").textContent = localStorage.getItem("GetPName");
      
    document.getElementById("DproductPrice").textContent = localStorage.getItem("GetPPrice");
     
    document.getElementById("tot").textContent = localStorage.getItem("GetPPrice");
    
    document.getElementById("getPic").src = localStorage.getItem("imgP1");
    
    document.getElementById("PassName").value = localStorage.getItem("GetPName");
   
    document.getElementById("PassPrice").value = localStorage.getItem("GetPPrice").replace("R", "");
    
    document.getElementById("PassQuanity").value = 1;
   
    document.getElementById("ref").value = localStorage.getItem("GetPName");



})

function quantity() {
   
    var qValue = document.querySelector('#getQ').value;
    alert(qValue);
  
    var originalAmount = document.getElementById("DproductPrice").textContent.replace("R", "");
    var pPrice = originalAmount;
    
    var FAmountToPay = pPrice * qValue;
    
    document.getElementById("tot").textContent = "R" + FAmountToPay;

    var qValue = document.querySelector('#getQ').value;
    document.getElementById("PassQuanity").value = qValue;
    document.getElementById("price").value = FAmountToPay;




 

    
}

function order() {

    var passtot = document.getElementById("tot").textContent.replace("R", "");
    document.getElementById("PassPrice").value = passtot;

}




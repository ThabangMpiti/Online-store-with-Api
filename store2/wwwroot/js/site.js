// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function p1() {
    //passing my images
    var img1 = document.getElementById('img-1').src;
    localStorage.setItem("imgP1", img1);
    //geting my product id
    var pName = document.getElementById('productName').textContent;
    var pPrice = document.getElementById('productPrice').textContent;
    localStorage.setItem("GetPName", pName);
    localStorage.setItem("GetPPrice", pPrice);
    //actionredirection
    window.location.href = "home/html2";



}

function p2() {
    //passing my images
    var img1 = document.getElementById('img-2').src;
    localStorage.setItem("imgP1", img1);
    //geting my product id
    var pName = document.getElementById('productName2').textContent;
    var pPrice = document.getElementById('productPrice2').textContent;
    localStorage.setItem("GetPName", pName);
    localStorage.setItem("GetPPrice", pPrice);
    //actionredirection
    window.location.href = "home/html2";

}

function p3() {
    //passing my images
    var img1 = document.getElementById('img-3').src;
    localStorage.setItem("imgP1", img1);
    //geting my product id
    var pName = document.getElementById('productName3').textContent;
    var pPrice = document.getElementById('productPrice3').textContent;
    localStorage.setItem("GetPName", pName);
    localStorage.setItem("GetPPrice", pPrice);
    //actionredirection
    window.location.href = "home/html2";

}

function p4() {
     //passing my images
    var img1 = document.getElementById('img-4').src;
    localStorage.setItem("imgP1", img1);
    //geting my product id
    var pName = document.getElementById('productName4').textContent;
    var pPrice = document.getElementById('productPrice4').textContent;
    localStorage.setItem("GetPName", pName);
    localStorage.setItem("GetPPrice", pPrice);
    //actionredirection
    window.location.href = "home/html2";

}










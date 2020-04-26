// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ButtClickOrdersNotEnd() {
    document.getElementsByClassName('informationOrdersEnd')[0].style = "display: none;";
    document.getElementsByClassName('informationOrdersNotEnd')[0].style = "display: table; width: 100%";
    document.getElementsByClassName('inputOrderNotEnd')[0].style = "background: white";
    document.getElementsByClassName('inputOrderEnd')[0].style = "background:  #f0f0f5";
}
function ButtClickOrdersEnd() {
    document.getElementsByClassName('informationOrdersNotEnd')[0].style = "display: none;";
    document.getElementsByClassName('informationOrdersEnd')[0].style = "display: table; width: 100%";
    document.getElementsByClassName('inputOrderEnd')[0].style = "background: white";
    document.getElementsByClassName('inputOrderNotEnd')[0].style = "background:  #f0f0f5";
}
function ViewAllDrivers()
{
    document.getElementsByClassName('visibleHidDrivers')[0].style = "display: table";
    document.getElementsByClassName('aPositionLeft')[0].style = "display: none";
    document.getElementsByClassName('aPositionRight')[0].style = "display: block";
}
function ViewNotAllDrivers() {
    document.getElementsByClassName('visibleHidDrivers')[0].style = "display: none";
    document.getElementsByClassName('aPositionRight')[0].style = "display: none";
    document.getElementsByClassName('aPositionLeft')[0].style = "display: block";

}

function ViewAllDrivers2() {
    document.getElementsByClassName('visibleHidDrivers2')[0].style = "display: table";
    document.getElementsByClassName('aPositionLeft2')[0].style = "display: none";
    document.getElementsByClassName('aPositionRight2')[0].style = "display: block";
}
function ViewNotAllDrivers2() {
    document.getElementsByClassName('visibleHidDrivers2')[0].style = "display: none";
    document.getElementsByClassName('aPositionRight2')[0].style = "display: none";
    document.getElementsByClassName('aPositionLeft2')[0].style = "display: block";

}
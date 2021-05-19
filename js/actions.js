var navHeight = document.getElementById("spacenav").clientHeight + "px";
var marHeight = (document.getElementsByTagName("body")[0].clientHeight / 45) + "px";
var navWidth = document.getElementsByTagName("nav")[0].clientWidth;
var parallax = document.getElementsByClassName("parallax-container");


//Event Listeners
window.addEventListener("scroll", scrollFunction);
window.addEventListener("load", parallaxHeightChange);
window.addEventListener("resize", parallaxHeightChange);

if(navWidth < 601)
{
    var speedtosize = 3;
}
else if (navWidth < 993)
{
    var speedtosize = 4.5;
}
else
{
    var speedtosize = navWidth / 250;
}

document.documentElement.style.setProperty("--navheight", navHeight);
document.documentElement.style.setProperty("--marginHeight", marHeight);
document.documentElement.style.setProperty("--shipspeed", speedtosize + "s");
document.body.style.setProperty("--navheight", navHeight);
document.body.style.setProperty("--marginHeight", marHeight);
document.body.style.setProperty("--shipspeed", speedtosize + "s");


//Scroll funkció, érzékeli ha a toTop gombnak meg kell-e jelennie
var topBtn = document.getElementById("toTopButton");

function scrollFunction() 
{
    if (document.documentElement.scrollTop > 20 || document.body.scrollTop > 20)
    {
        topBtn.style.display = "block";
    }
    else
    {
        topBtn.style.display = "none";
    }
}

function toTop()
{
    document.querySelector('header').scrollIntoView({behavior: "smooth"});
}

function parallaxHeightChange()
{
    for (i = 0; i < parallax.length; i++)
    {
        parallax[i].clientHeight =  ((window.innerHeight - document.getElementById("top").clientHeight - document.getElementById("content1").clientHeight) / 2);
    }
}

//jQuery

$(document).ready(function()
{
    $('.sidenav').sidenav();
    $('.collapsible').collapsible();
    $('.parallax').parallax();
});
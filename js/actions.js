$(document).ready(function()
{
    $('.sidenav').sidenav();
    $('.parallax').parallax();
}
);

document.documentElement.style.setProperty("--navheight", document.getElementById("spacenav").clientHeight + "px");
document.documentElement.style.setProperty("--navwidth", document.getElementsByTagName("nav").clientWidth + "px");

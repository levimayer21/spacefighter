var speedtosize = document.getElementsByTagName("nav")[0].clientWidth / 210;

$(document).ready(function()
{
    $('.sidenav').sidenav();
    $('.parallax').parallax();
}
);

document.documentElement.style.setProperty("--navheight", document.getElementById("spacenav").clientHeight + "px");
document.documentElement.style.setProperty("--shipspeed", speedtosize + "s");

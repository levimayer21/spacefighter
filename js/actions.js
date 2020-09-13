var speedtosize = document.getElementsByTagName("nav")[0].clientWidth / 210;

$(document).ready(function()
{
    $('.sidenav').sidenav();
    $('.collapsible').collapsible();
}
);

document.documentElement.style.setProperty("--navheight", document.getElementById("spacenav").clientHeight + "px");
document.documentElement.style.setProperty("--marginHeight", (document.getElementsByTagName("body")[0].clientHeight / 45) + "px");
document.documentElement.style.setProperty("--shipspeed", speedtosize + "s");

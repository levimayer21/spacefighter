$(document).ready(function()
{
    $('.sidenav').sidenav();
    $('.parallax').parallax();
}
);

window.addEventListener('scroll', () => {
    document.body.style.setProperty('--scroll',window.pageYOffset / (document.body.offsetHeight - window.innerHeight));
  }, false);
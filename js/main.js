const swURL = require("./sw.js")

if ('serviceWorker' in navigator)
{
    window.addEventListener("load", 
    async () =>
    {
        try
        {
            const reg = await navigator.serviceWorker.register(swURL);
            console.log("Service worker successfully registered: " + reg);
        }
        catch (err)
        {
            console.log("Service worker failed registration: " + err);
        }
    });
}
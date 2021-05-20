const cacheName = "pwa";
const precacheResources = ["/", 'index.php', 'scoreboard.php', 'game.php', 'css/style.css', 'css/materialize.min.css', 'js/main.js', 'js/actions.js', 'js/materialize.min.js', 'js/aos.js', 'js/jquery.js'];

self.addEventListener("install", 
(event) =>
{
    console.log('Service worker installer event');
    event.waitUntil(caches.open(cacheName).then((cache) => cache.addAll(precacheResources)));
});

self.addEventListener("activate", 
(event) =>
{
    console.log("Service worker activate event");
});

self.addEventListener("fetch", 
(event) =>
{
    console.log("Fetch event intercepted for: " + event.request.url);
    event.respondWith(
        caches.match(event.request).then(
            (cachedResponse) =>
            {
                if (cachedResponse)
                {
                    return cachedResponse;
                }
                return fetch(event.request)
            }),
    );
});
const cacheName = "pwa";
const pwa_url = "offline.php";
const precacheResources = ['/', '/index.php', '/scoreboard.php', '/game.php', '/css/', '/js/', '/game/'];

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
    event.waitUntil((
        async () =>
        {
            if ("navigationPreload" in self.registration)
            {
                await self.registration.navigationPreload.enable();
            }
        }));

    self.clients.claim();
});

self.addEventListener("fetch", function(event) {
    event.respondWith(checkResponse(event.request).catch(function() {
      return returnFromCache(event.request);
    }));
    event.waitUntil(addToCache(event.request));
  });
  
  var checkResponse = function(request){
    return new Promise(function(fulfill, reject) {
      fetch(request).then(function(response){
        if(response.status !== 404) {
          fulfill(response);
        } else {
          reject();
        }
      }, reject);
    });
  };
  
  var addToCache = function(request){
    return caches.open(cacheName).then(function (cache) {
      return fetch(request).then(function (response) {
        console.log(response.url + " was cached");
        return cache.put(request, response);
      });
    });
  };
  
  var returnFromCache = function(request){
    return caches.open(cacheName).then(function (cache) {
      return cache.match(request).then(function (matching) {
       if(!matching || matching.status == 404) {
         return cache.match(pwa_url);
       } else {
         return matching;
       }
      });
    });
  };
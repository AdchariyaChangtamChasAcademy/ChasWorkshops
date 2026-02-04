const CACHE_VERSION = 'v1'
const CACHE_NAME = `workers-cache-${CACHE_VERSION}`

const ASSETS = [
  '/public/',
  '/public/index.html',
  '/public/styles.css',
  '/public/main.js',
  '/public/worker.js',
  '/public/offline.html',
  '/public/manifest.webmanifest',
]

// Install
self.addEventListener('install', (event) => {
  event.waitUntil(
    caches.open(CACHE_NAME).then((cache) => cache.addAll(ASSETS))
  )
  self.skipWaiting()
})

// Activate
self.addEventListener('activate', (event) => {
  event.waitUntil(
    caches.keys().then((keys) =>
      Promise.all(
        keys.filter((key) => key !== CACHE_NAME).map((key) => caches.delete(key))
      )
    )
  )
  self.clients.claim()
})

// Fetch
self.addEventListener('fetch', (event) => {
  const request = event.request

  if (request.method !== 'GET') return

  event.respondWith(handleRequest(request))
})

async function handleRequest(request) { 
    const cache = await caches.open(CACHE_NAME) 
    const cached = await cache.match(request) 
    
    // Stale-while-revalidate 
    if (cached) { 
        fetch(request).then(res => { 
            if (res.ok) cache.put(request, res.clone()) 
        }) 
        return cached 
    } 
    
    try { 
        const response = await fetch(request) 
        if (response.ok) cache.put(request, response.clone()) 
        return response 
    } catch (error) { 
        // Offline fallback ONLY for navigation requests 
        if (request.mode === 'navigate') { 
            return cache.match('/offline.html') 
        } 
        
        // Always return a valid Response 
        return new Response('Offline', { status: 503 }) 
    } 
}

async function fetchAndUpdate(request, cache) {
  try {
    const response = await fetch(request)
    if (response.ok) cache.put(request, response.clone())
  } catch {
    // Quietly ignore
  }
}

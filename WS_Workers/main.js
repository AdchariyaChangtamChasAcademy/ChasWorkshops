function createLargeArray(size = 5_000_000) {
  const arr = new Array(size)
  for (let i = 0; i < size; i++) {
    arr[i] = Math.random()
  }
  return arr
}

function blockingSort() {
  const numbers = createLargeArray()
  const sorted = numbers.sort((a, b) => a - b)
  return sorted[0]
}

const sortBlockingBtn = document.querySelector('#sort-blocking')
const pingBtn = document.querySelector('#ping')
const statusBlocking = document.querySelector('#status-blocking')

sortBlockingBtn.addEventListener('click', () => {
  statusBlocking.textContent = 'Sorterar… (UI kommer frysa)'
  const start = performance.now()
  const smallest = blockingSort()
  const end = performance.now()

  statusBlocking.textContent =
    `Klar! Minsta tal: ${smallest.toFixed(5)} – tog ${(end - start).toFixed(0)} ms`
})

pingBtn.addEventListener('click', () => {
  alert('Ping från main thread!')
})


// --- Web Worker ---

const sortWorkerBtn = document.querySelector('#sort-worker')
const pingWorkerBtn = document.querySelector('#ping-worker')
const statusWorker = document.querySelector('#status-worker')

const worker = new Worker('./worker.js', { type: 'module' })

worker.onmessage = (event) => {
  const { smallest, durationMs } = event.data
  statusWorker.textContent =
    `Klar! Minsta tal: ${smallest.toFixed(5)} – tog ${durationMs.toFixed(0)} ms (worker)`
}

worker.onerror = (err) => {
  console.error('Worker error:', err)
  statusWorker.textContent = 'Ett fel uppstod i workern.'
}

sortWorkerBtn.addEventListener('click', () => {
  statusWorker.textContent = 'Sorterar i worker… (UI är responsivt)'
  worker.postMessage({})
})

pingWorkerBtn.addEventListener('click', () => {
  alert('Ping medan worker jobbar!')
})


// --- Service Worker ---

if ('serviceWorker' in navigator) {
  window.addEventListener('load', () => {
    navigator.serviceWorker.register('./sw.js')
  })
}
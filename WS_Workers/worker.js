function createLargeArray(size = 5_000_000) {
  const arr = new Array(size)
  for (let i = 0; i < size; i++) {
    arr[i] = Math.random()
  }
  return arr
}

function sortInWorker() {
  const numbers = createLargeArray()
  const sorted = numbers.sort((a, b) => a - b)
  return sorted[0]
}

self.onmessage = () => {
  const start = performance.now()
  const smallest = sortInWorker()
  const end = performance.now()

  self.postMessage({
    smallest,
    durationMs: end - start,
  })
}

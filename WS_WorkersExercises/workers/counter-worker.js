self.addEventListener("message", (event) => {
    const startTime = performance.now();
    
    const { start, end } = event.data;
    let count = start;
    for (; count <= end; count++) {
        // ...
    }

    const endTime = performance.now()

    self.postMessage({
        result: count - 1,
        durationMs: endTime - startTime,
    });
});
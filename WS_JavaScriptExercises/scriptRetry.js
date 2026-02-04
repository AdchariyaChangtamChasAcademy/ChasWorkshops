const sleep = (ms) => new Promise(resolve => setTimeout(resolve, ms));

async function fetchWithRetry(url, maxRetries = 3, timeoutMs = 3000) {
    let attempt = 0;

    while (attempt <= maxRetries) {
        attempt++;
        console.log(`Attempt ${attempt} for URL: ${url}`);

        const controller = new AbortController();
        const timeout = setTimeout(() => controller.abort(), timeoutMs);

        try {
            const response = await fetch(url, { signal: controller.signal });

            clearTimeout(timeout);

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }

            const data = await response.json();
            return data;

        } catch (error) {
            clearTimeout(timeout);

            if (attempt > maxRetries) {
                console.error(`Failed after ${maxRetries} attempts:`, error);
                throw error;
            }

            const delay = 3000;
            console.warn(`Retrying in ${delay / 1000}s...`);

            await sleep(delay);
        }
    }
}

fetchWithRetry("https://jsonplaceholder.typicode.com/posts/1", 3, 3000)
    .then(data => console.log("Success:", data))
    .catch(err => console.error("Final Error:", err));

fetchWithRetry("https://jsonplaceholder.typicode.com/invalidUrl", 3, 3000)
    .then(data => console.log("Success:", data))
    .catch(err => console.error("Final Error:", err));

self.addEventListener("message", (event) => {
    const text = event.data;
    const upperCaseText = text.toUpperCase();
    self.postMessage(upperCaseText);
});
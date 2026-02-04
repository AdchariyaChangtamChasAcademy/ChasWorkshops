self.addEventListener("message", (event) => {
    const { array1, array2, array3 } = event.data;

    const sortedArray1 = array1.slice().sort((a,b) => a-b);
    const sortedArray2 = array2.slice().sort((a,b) => a-b);
    const sortedArray3 = array3.slice().sort((a,b) => a-b);

    self.postMessage({sortedArray1, sortedArray2 ,sortedArray3});
});
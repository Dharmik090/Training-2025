onmessage = function (e) {
    let sum = 0;

    for (let i = 0; i < 2e9; i++) {
        sum += i;
    }

    // postMessage from worker thread
    // to onmessage in main thread
    postMessage(sum);
};

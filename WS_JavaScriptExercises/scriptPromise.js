const checkStock = (product) => {
    return new Promise((resolve, reject) => {
    setTimeout(() => {
        const inStock = true;
        if (inStock) {
            resolve(`${product} in stock`);
        } else {
            reject(`${product} not in stock`);
        }
    }, 2000);
  });
}

const processPayment = (userId, amount) => {
    return new Promise((resolve, reject) => {
    setTimeout(() => {
            if (amount > 1000) {
                resolve(sendConfirmationEmail(userId));
            } else {
                reject(`${amount} amount is not valid`);
            }
        }, 2000);
    });
}

const shipOrder = (orderId) => {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (orderId === "0") {
                resolve(`${orderId} orderId is valid`);
            } else {
                reject(`${orderId} orderId is not valid`);
            }
        }, 2000);
    });
}

const sendConfirmationEmail = (userId) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve({
                id: userId,
                name: 'Alice Alicesson',
                email: 'alice@email.com'
            });
        }, 1000);
    });
}
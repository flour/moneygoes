let user = JSON.parse(localStorage.getItem('user'));
let payments = JSON.parse(localStorage.getItem('payments'));

export const alertState = {};
export const registrationState = {};
export const userState = user ? user : {};
export const paymentState = payments ? payments : [];

export const appState = {
    alert: alertState,
    registration: registrationState,
    user: userState,
    payments: paymentState,
}
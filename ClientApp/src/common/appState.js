let user = JSON.parse(localStorage.getItem('user'));
let purchases = JSON.parse(localStorage.getItem('purchases'));

export const alertState = {};
export const registrationState = {};
export const userState = user ? user : {};
export const purchasesState = purchases ? purchases : [];

export const appState = {
    alert: alertState,
    registration: registrationState,
    user: userState,
    purchases: purchasesState,
}
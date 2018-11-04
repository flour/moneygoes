let user = JSON.parse(localStorage.getItem('user'));

export const alertState = {};
export const registrationState = {};
export const userState = user ? user : {};

export const appState = {
    alert: alertState,
    registration: registrationState,
    user: userState
}
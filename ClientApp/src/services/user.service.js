import { prepareHeaders, handleResponse, handleError, config } from '../common';

export const userService = {
    login: async (username, password) => {
        const requestOptions = {
            method: 'POST',
            headers: prepareHeaders(false, true),
            body: JSON.stringify({ username, password, email: username })
        };
        let user;
        try {
            const response = await fetch(config.loginUrl, requestOptions);
            user = await handleResponse(response);
        }
        catch (error) {
            return handleError(error);
        }
        if (user) {
            localStorage.setItem('user', JSON.stringify(user));
        }
        return user;
    },
    logout: async () => {
        const requestOptions = {
            method: 'POST',
            headers: prepareHeaders(true, true)
        };

        try {
            await fetch(config.logoutUrl, requestOptions);
            localStorage.removeItem('user');
        } catch (error) {
            handleError(error);
        }
    },
    register: async (user) => {
        const requestOptions = {
            method: 'POST',
            headers: prepareHeaders(false, true),
            body: JSON.stringify(user)
        };

        try {
            const response = await fetch(config.registerUrl, requestOptions);
            return handleResponse(response);
        }
        catch (error) {
            return handleError(error);
        }
    }
};
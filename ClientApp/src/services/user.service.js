import { authHeader, prepareHeaders, handleResponse, handleError, config } from '../common';

export const userService = {
    login,
    logout,
    register,
    getAll,
    getById,
    update,
    delete: remove
};

const login = async (username, password) => {
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
        // store user details and jwt token in local storage to keep user logged in between page refreshes        
        localStorage.setItem('user', JSON.stringify(user));
    }
    return user;
}

const logout = async () => {
    // remove user from local storage to log user out

    localStorage.removeItem('user');
}

const getAll = async () => {
    const requestOptions = {
        method: 'GET',
        headers: authHeader()
    };

    try {
        const response = await fetch(config.apiUrl + '/users', requestOptions);
        return handleResponse(response);
    }
    catch (error) {
        return handleError(error);
    }
}

const getById = async (id) => {
    const requestOptions = {
        method: 'GET',
        headers: authHeader()
    };

    try {
        const response = await fetch(config.apiUrl + '/users/' + id, requestOptions);
        return handleResponse(response);
    }
    catch (error) {
        return handleError(error);
    }
}

const register = async (user) => {
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

const update = async (user) => {
    const requestOptions = {
        method: 'PUT',
        headers: prepareHeaders(true, true),
        body: JSON.stringify(user)
    };

    try {
        const response = await fetch(config.apiUrl + '/users/' + user.id, requestOptions);
        return handleResponse(response);
    }
    catch (error) {
        return handleError(error);
    }
}

const remove = async (id) => {
    const requestOptions = {
        method: 'DELETE',
        headers: prepareHeaders(true, true)
    };

    try {
        const response = await fetch(config.apiUrl + '/users/' + id, requestOptions);
        return handleResponse(response);
    }
    catch (error) {
        return handleError(error);
    }
}

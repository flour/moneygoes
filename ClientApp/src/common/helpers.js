export const authHeader = () => {
    // return authorization header with jwt token
    let user = JSON.parse(localStorage.getItem('user'));

    if (user && user.token) {
        return { 'Authorization': 'Bearer ' + user.token };
    } else {
        return {};
    }
}

export const prepareHeaders = (auth, notGet) => {
    return {
        ...(auth ? authHeader() : {}),
        ...(notGet ? { 'Content-Type': 'application/json' } : {})
    }
}

export const handleResponse = (response) => {
    return new Promise((resolve, reject) => {
        if (response.ok) {
            // return json if it was returned in the response
            var contentType = response.headers.get("content-type");
            if (contentType && contentType.includes("application/json")) {
                response.json().then(json => resolve(json));
            } else {
                resolve();
            }
        } else {
            // return error message from response body
            response.text().then(text => reject(text));
        }
    });
}

export const handleError = (error) => {
    return Promise.reject(error && error.message);
}
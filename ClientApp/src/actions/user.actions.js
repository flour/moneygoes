import { userConstants } from '../constants';
import { userService } from '../services';
import { alertActions } from './';
import { history } from '../common'

const login = (username, password) => {
    return dispatch => {
        dispatch(request({ username }));

        userService.login(username, password)
            .then(
                user => {
                    dispatch(success(user));
                    history.push('/');
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error('Could not login'));
                }
            );
    };

    function request(login) { return { type: userConstants.LOGIN_REQ, login } }
    function success(user) { return { type: userConstants.LOGIN_OK, user } }
    function failure(error) { return { type: userConstants.LOGIN_FAIL, error } }
}

const logout = () => {
    userService.logout();
    return { type: userConstants.LOGOUT };
}

const register = (registration) => {
    return dispatch => {
        dispatch(request(registration));
        userService.register(registration)
            .then(
                () => {
                    dispatch(success());
                    history.push('/');
                    dispatch(alertActions.success('Registration successful'));
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
    };

    function request(registration) { return { type: userConstants.REGISTER_REQ, registration } }
    function success(registration) { return { type: userConstants.REGISTER_OK, registration } }
    function failure(error) { return { type: userConstants.REGISTER_FAIL, error } }
}

export const userActions = {
    login,
    logout,
    register,
};
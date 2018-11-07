import { paymentConstants } from '../constants';
import { paymentService } from '../services';
import { alertActions } from './';

const getAllgroups = () => {
    return async dispatch => {
        try {
            const data = await paymentService.getAllgroups();
            dispatch(success(data));
        } catch (error) {
            dispatch(failure(error));
            dispatch(alertActions.error(error));
        }
    };

    function success(data) { return { type: paymentConstants.GROUP_ALL_REQ_OK, data } }
    function failure(error) { return { type: paymentConstants.GROUP_ALL_REQ_FAIL, error } }
}

const createGroup = (name, description) => {
    return async dispatch => {
        try {
            const result = await paymentService.createGroup(name, description);
            dispatch(success(result));
        } catch (error) {
            dispatch(failure(error));
            dispatch(alertActions.error(error));
        }
    }
    function success(data) { return { type: paymentConstants.GROUP_CREATE_REQ_OK, data } }
    function failure(error) { return { type: paymentConstants.GROUP_CREATE_REQ_FAIL, error } }
}

export const paymentActions = {
    getAllgroups,
    createGroup
};
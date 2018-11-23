import { purchaseConstants } from '../constants';
import { purchasesService } from '../services';
import { alertActions } from '.';

const getAllGroups = () => {
    return async dispatch => {
        try {
            const data = await purchasesService.getAllPurchases();
            dispatch(success(data));
        } catch (error) {
            dispatch(failure(error));
            dispatch(alertActions.error(error));
        }
    };

    function success(data) { return { type: purchaseConstants.PURCHASE_ALL_OK, data } }
    function failure(error) { return { type: purchaseConstants.PURCHASE_ALL_FAIL, error } }
}

const createGroup = (name, description) => {
    return async dispatch => {
        try {
            const result = await purchasesService.createPurchase(name, description);
            dispatch(success(result));
        } catch (error) {
            dispatch(failure(error));
            dispatch(alertActions.error(error));
        }
    }
    function success(data) { return { type: purchaseConstants.PURCHASE_CREATE_OK, data } }
    function failure(error) { return { type: purchaseConstants.PURCHASE_CREATE_FAIL, error } }
}

export const paymentActions = {
    getAllGroups,
    createGroup
};
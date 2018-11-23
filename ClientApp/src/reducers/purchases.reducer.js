import { purchaseConstants } from '../constants';
import { purchasesState } from '../common/appState';

const ACTION_HANDLERS = {
    [purchaseConstants.PURCHASE_ALL_OK]: (state, action) => ([...action.data]),
    [purchaseConstants.PURCHASE_CREATE_OK]: (state, action) => ([...(state || [])]),
}

export const purchases = (state = purchasesState, action) => {
    const handler = ACTION_HANDLERS[action.type];
    return handler ? handler(state, action) : state;
};
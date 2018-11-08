import { paymentConstants } from '../constants';
import { paymentState } from '../common/appState';

const ACTION_HANDLERS = {
    [paymentConstants.GROUP_ALL_REQ_OK]: (state, action) => ([...action.data]),
    [paymentConstants.GROUP_CREATE_REQ_OK]: (state, action) => ([...(state || [])]),
}

export const payments = (state = paymentState, action) => {
    const handler = ACTION_HANDLERS[action.type];
    return handler ? handler(state, action) : state;
};
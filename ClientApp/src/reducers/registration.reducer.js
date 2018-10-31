import { registrationState } from '../common/appState';
import { userConstants } from '../constants';

const ACTION_HANDLERS = {
    [userConstants.REGISTER_REQUEST]: (state, action) => ({
        ...state,
        registration: { registering: true }
    }),
    [userConstants.REGISTER_SUCCESS]: (state, action) => ({
        ...state,
        registration: {}
    }),
    [userConstants.REGISTER_FAILURE]: (state, action) => ({
        ...state,
        registration: {}
    })
}

export const registration = (state = registrationState, action) => {
    const handler = ACTION_HANDLERS[action.type];
    return handler ? handler(state, action) : state;
};
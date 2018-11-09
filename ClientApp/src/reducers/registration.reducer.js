import { registrationState } from '../common/appState';
import { userConstants } from '../constants';

const ACTION_HANDLERS = {
    [userConstants.REGISTER_REQ]: (state, action) => ({ registering: true }),
    [userConstants.REGISTER_OK]: (state, action) => ({}),
    [userConstants.REGISTER_FAIL]: (state, action) => ({})
}

export const registration = (state = registrationState, action) => {
    const handler = ACTION_HANDLERS[action.type];
    return handler ? handler(state, action) : state;
};
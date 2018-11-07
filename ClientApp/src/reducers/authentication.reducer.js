import { userState } from '../common/appState';
import { userConstants } from '../constants';

const ACTION_HANDLERS = {
  [userConstants.LOGIN_REQ]: (state, action) => ({
    ...state,
    user: action.user
  }),
  [userConstants.LOGIN_OK]: (state, action) => ({
    ...state,
    user: action.user
  }),
  [userConstants.LOGIN_FAIL]: (state, action) => ({
    ...state,
    user: {}
  }),
  [userConstants.LOGOUT]: (state, action) => ({
    ...state,
    user: {}
  }),
};

export const user = (state = userState, action) => {
  const handler = ACTION_HANDLERS[action.type];
  return handler ? handler(state, action) : state;
};
import { userState } from '../common/appState';
import { userConstants } from '../constants';

const ACTION_HANDLERS = {
  [userConstants.LOGIN_REQUEST]: (state, action) => ({
    ...state,
    user: action.payload
  }),
  [userConstants.LOGIN_SUCCESS]: (state, action) => ({
    ...state,
    user: action.payload
  }),
  [userConstants.LOGIN_FAILURE]: (state, action) => ({
    ...state
  }),
  [userConstants.LOGOUT]: (state, action) => ({
    ...state
  }),
};

export const user = (state = userState, action) => {
  const handler = ACTION_HANDLERS[action.type];
  return handler ? handler(state, action) : state;
};
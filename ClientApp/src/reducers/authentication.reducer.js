import { userState } from '../common/appState';
import { userConstants } from '../constants';

const ACTION_HANDLERS = {
  [userConstants.LOGIN_REQUEST]: (state, action) => ({
    ...state,
    user: action.user
  }),
  [userConstants.LOGIN_SUCCESS]: (state, action) => ({
    ...state,
    user: action.user
  }),
  [userConstants.LOGIN_FAILURE]: (state, action) => ({
    ...state,
    user: {}
  }),
  [userConstants.LOGOUT]: (state, action) => ({
    ...state,
    user: action.user
  }),
};

export const user = (state = userState, action) => {
  const handler = ACTION_HANDLERS[action.type];
  return handler ? handler(state, action) : state;
};
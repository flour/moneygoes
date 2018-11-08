import { userState } from '../common/appState';
import { userConstants } from '../constants';

const ACTION_HANDLERS = {
  [userConstants.LOGIN_REQ]: (state, action) => ({
    ...action.user
  }),
  [userConstants.LOGIN_OK]: (state, action) => ({
    ...action.user
  }),
  [userConstants.LOGIN_FAIL]: (state, action) => ({}),
  [userConstants.LOGOUT]: (state, action) => ({}),
};

export const user = (state = userState, action) => {
  const handler = ACTION_HANDLERS[action.type];
  return handler ? handler(state, action) : state;
};
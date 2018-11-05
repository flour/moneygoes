import { alertState } from '../common/appState';
import { alertConstants } from '../constants';

const ACTION_HANDLERS = {
  [alertConstants.OK]: (state, action) => ({
    ...state,
    alert: {
      type: 'alert-success',
      message: action.message
    }
  }),
  [alertConstants.ERROR]: (state, action) => ({
    ...state,
    alert: {
      type: 'alert-danger',
      message: action.message
    }
  }),
  [alertConstants.CLEAR]: (state, action) => ({
    ...state
  }),
};

export const alert = (state = alertState, action) => {
  const handler = ACTION_HANDLERS[action.type];
  return handler ? handler(state, action) : state;
};
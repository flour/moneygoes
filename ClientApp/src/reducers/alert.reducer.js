import { alertState } from '../common/appState';
import { alertConstants } from '../constants';

const ACTION_HANDLERS = {
  [alertConstants.OK]: (state, action) => ({
    ...{
      type: 'alert-success',
      message: action.message
    }
  }),
  [alertConstants.ERROR]: (state, action) => ({
    ...{
      type: 'alert-danger',
      message: action.message
    }
  }),
  [alertConstants.CLEAR]: (state, action) => ({}),
};

export const alert = (state = alertState, action) => {
  const handler = ACTION_HANDLERS[action.type];
  return handler ? handler(state, action) : state;
};
import { combineReducers } from 'redux';

import { user } from './authentication.reducer';
import { registration } from './registration.reducer';
import { alert } from './alert.reducer';
import { purchases } from './purchases.reducer';

const rootReducer = combineReducers({
    user,
    registration,
    alert,
    purchases
});

export default rootReducer;
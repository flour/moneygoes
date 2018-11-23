import { combineReducers } from 'redux';

import { user } from './authentication.reducer';
import { registration } from './registration.reducer';
import { alert } from './alert.reducer';
import { purchase } from './purchase.reducer';

const rootReducer = combineReducers({
    user,
    registration,
    alert,
    purchase
});

export default rootReducer;
import { combineReducers } from 'redux';

import { user } from './authentication.reducer';
import { registration } from './registration.reducer';
import { alert } from './alert.reducer';
import { payments } from './payments.reducer';

const rootReducer = combineReducers({
    user,
    registration,
    alert,
    payments
});

export default rootReducer;
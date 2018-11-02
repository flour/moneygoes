import { combineReducers } from 'redux';

import { user } from './authentication.reducer';
import { registration } from './registration.reducer';
import { alert } from './alert.reducer';

const rootReducer = combineReducers({
    user,
    registration,
    alert
});

export default rootReducer;
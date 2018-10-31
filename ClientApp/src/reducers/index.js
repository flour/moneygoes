import { combineReducers } from 'redux';

import { user } from './authentication.reducer';
import { registration } from './registration.reducer';
import { users } from './users.reducer';
import { alert } from './alert.reducer';

const rootReducer = combineReducers({
    user,
    registration,
    users,
    alert
});

export default rootReducer;
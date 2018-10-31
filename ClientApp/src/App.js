import React from 'react';
import { Router, Route } from 'react-router-dom';
import { connect } from 'react-redux'

import { history } from './common';
import { alertActions } from './actions';

import { PrivateRoute, Layout } from './components';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { Register } from './components/Register';

class App extends React.Component {
  displayName = App.name

  constructor(props) {
    super(props);
    const { dispatch } = this.props;
    history.listen((location, action) => {
      // clear alert on location change
      dispatch(alertActions.clear());
    });
  }

  render() {
    const { alert, user } = this.props;
    return (
      <div className="col-sm-8 col-sm-offset-2">        
        {(alert.message || alert.alert) &&
          <div className={`alert ${alert.type}`}>{alert.message}</div>
        }
        <Router history={history}>
          <Layout>
            <PrivateRoute exact path="/" component={Home} />
            {!user.loggedIn &&
              <Route path="/login" component={Login} /> &&
              <Route path="/register" component={Register} />
            }
            {user.loggedIn &&
              <Route path="/profile" component={<div>qwerqwer</div>} />}
          </Layout>
        </Router>
      </div>
    );
  }
}

function mapStateToProps(state) {
  const { alert, user } = state;
  return {
    alert,
    user
  };
}

const connectedApp = connect(mapStateToProps)(App);
export { connectedApp as App }; 
import React from 'react';
import { Router, Route } from 'react-router-dom';
import { connect } from 'react-redux'

import { history } from './common';
import { alertActions } from './actions';

import {
  PrivateRoute,
  Layout,
} from './components';

import {
  HomePage,
  LoginPage,
  RegisterPage,
  ProfilePage,
  GroupsPage
} from './components/pages';

class App extends React.Component {
  displayName = App.name

  constructor(props) {
    super(props);
    const { dispatch } = this.props;
    history.listen((location, action) => {
      dispatch(alertActions.clear());
    });
  }

  render() {
    const { alert } = this.props;
    return (
      <div className="col-sm-8 col-sm-offset-2">
        <Router history={history}>
          <Layout alert={alert}>
            <PrivateRoute exact path="/" component={HomePage} />
            <Route path="/login" component={LoginPage} />
            <Route path="/register" component={RegisterPage} />
            <Route path="/profile" component={ProfilePage} />
            <Route path="/data" component={GroupsPage} />
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
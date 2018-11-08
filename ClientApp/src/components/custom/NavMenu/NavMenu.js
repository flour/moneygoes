import React from 'react';
import { connect } from 'react-redux'
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';
import { userActions } from '../../../actions';
import { history } from '../../../common';

const NavMenu = ({ user, dispatch }) => (
  <Navbar inverse fixedTop fluid collapseOnSelect>
    <Navbar.Header>
      <Navbar.Brand>
        <Link to={'/'}>moneygoes</Link>
      </Navbar.Brand>
      <Navbar.Toggle />
    </Navbar.Header>
    <Navbar.Collapse>
      <Nav>
        <LinkContainer to={'/'} exact>
          <NavItem>
            <Glyphicon glyph='home' /> Home
          </NavItem>
        </LinkContainer>
        {user.username &&
          <LinkContainer to={'/counter'}>
            <NavItem>
              <Glyphicon glyph='education' /> Counter
            </NavItem>
          </LinkContainer>
        }
        {user.username &&
          <LinkContainer to={'/data'}>
            <NavItem>
              <Glyphicon glyph='th-list' /> Payments
            </NavItem>
          </LinkContainer>
        }
        {!user.username &&
          <LinkContainer to={'/login'}>
            <NavItem>
              <Glyphicon glyph='log-in' /> Login
            </NavItem>
          </LinkContainer>
        }
        {!user.username &&
          <LinkContainer to={'/register'}>
            <NavItem>
              <Glyphicon glyph='th-list' /> Register
            </NavItem>
          </LinkContainer>
        }
        {user.username &&
          <LinkContainer to={'/profile'}>
            <NavItem>
              <Glyphicon glyph='user' /> Profile
            </NavItem>
          </LinkContainer>
        }
        {user.username &&
          <NavItem onClick={() => {
            dispatch(userActions.logout());
            history.push('login');
          }}>
            <Glyphicon glyph='log-out' /> Logout
          </NavItem>
        }
      </Nav>
    </Navbar.Collapse>
  </Navbar>
);

function mapStateToProps(state) {
  const { user, dispatch } = state;
  return {
    user,
    dispatch
  };
}

const connectedNavMenu = connect(mapStateToProps)(NavMenu);
export { connectedNavMenu as NavMenu }; 
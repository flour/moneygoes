import React from 'react';
import { connect } from 'react-redux'
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

const NavMenu = ({ user }) => (
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
        {user.loggedIn &&
          <LinkContainer to={'/counter'}>
            <NavItem>
              <Glyphicon glyph='education' /> Counter
                </NavItem>
          </LinkContainer>
        }
        {user.loggedIn &&
          <LinkContainer to={'/fetchdata'}>
            <NavItem>
              <Glyphicon glyph='th-list' /> Fetch data
                </NavItem>
          </LinkContainer>
        }
        {!user.loggedIn &&
          <LinkContainer to={'/login'}>
            <NavItem>
              <Glyphicon glyph='log-in' /> Login
                </NavItem>
          </LinkContainer>
        }
        {!user.loggedIn &&
          <LinkContainer to={'/register'}>
            <NavItem>
              <Glyphicon glyph='th-list' /> Register
              </NavItem>
          </LinkContainer>
        }
        {user.loggedIn &&
          <LinkContainer to={'/profile'}>
            <NavItem>
              <Glyphicon glyph='user' /> Profile
                </NavItem>
          </LinkContainer>
        }
        {user.loggedIn &&
          <LinkContainer to={'/logout'}>
            <NavItem>
              <Glyphicon glyph='log-out' /> Logout
                </NavItem>
          </LinkContainer>
        }
      </Nav>
    </Navbar.Collapse>
  </Navbar>
);

function mapStateToProps(state) {
  const { user } = state;
  return {
    user
  };
}

const connectedNavMenu = connect(mapStateToProps)(NavMenu);
export { connectedNavMenu as NavMenu }; 
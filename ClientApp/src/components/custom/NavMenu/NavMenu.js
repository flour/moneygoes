import React, { Component } from 'react';
import { connect } from 'react-redux'
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    const { user } = this.props;
    return (
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
            <LinkContainer to={'/counter'}>
              <NavItem>
                <Glyphicon glyph='education' /> Counter
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/fetchdata'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Fetch data
              </NavItem>
            </LinkContainer>
            {!user.loggedIn &&
              <LinkContainer to={'/login'}>
                <NavItem>
                  <Glyphicon glyph='th-list' /> Login
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
                  <Glyphicon glyph='th-list' /> Profile
                </NavItem>
              </LinkContainer>
            }
            {user.loggedIn &&
              <LinkContainer to={'/logout'}>
                <NavItem>
                  <Glyphicon glyph='th-list' /> Logout
                </NavItem>
              </LinkContainer>
            }
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}

function mapStateToProps(state) {
  const { user } = state;
  return {
    user
  };
}

const connectedNavMenu = connect(mapStateToProps)(NavMenu);
export { connectedNavMenu as NavMenu }; 
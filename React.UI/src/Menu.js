import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

export class Menu extends Component {

  render() {
    return (
      <Navbar collapseOnSelect>        
          <Navbar.Brand>
            <Link to={'/'}>Reservations</Link>
          </Navbar.Brand>
          <Navbar.Toggle />        
        <Navbar.Collapse>
          <Nav>                      
            <LinkContainer to={'/facilities'}>
              <NavItem>
                List Tennis Facilities
              </NavItem>
            </LinkContainer>
                </Nav>
                <Nav>
                    <LinkContainer to={'/test'}>
                        <NavItem>
                            Test Routing
                        </NavItem>
                    </LinkContainer>
                </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}

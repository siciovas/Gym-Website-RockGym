import React from "react";
import { NavDropdown, Button } from "react-bootstrap";
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

const NavigationBar = () => {
  return (
    <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
      <Container>
        <Navbar.Brand href="/">ROCKGYM</Navbar.Brand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="/grouptrainings">Grupinės treniruotės</Nav.Link>
            <Nav.Link href="/subscriptions">Abonementai</Nav.Link>
            
          </Nav>
          <Nav className="me-right">
            <Nav.Link href="/login">Prisijungti</Nav.Link>
            <Nav.Link href="/register">Registruotis</Nav.Link>
              
              <NavDropdown title={<i className="bi bi-file-earmark-person"></i>} id="basic-nav-dropdown" >
                <NavDropdown.Item href="/profile">Paskyra</NavDropdown.Item>
                <NavDropdown.Item href="#">Atsijungti</NavDropdown.Item>
              </NavDropdown>

          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};
export { NavigationBar };

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
            <Button variant="dark">
              <svg xmlns="http://www.w3.org/2000/svg" width="22" height="22" fill="white" className="bi bi-person" viewBox="0 0 16 16">
                <path d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6Zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0Zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4Zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10Z" />
              <NavDropdown title="" id="basic-nav-dropdown">
                <NavDropdown.Item href="/profile">Paskyra</NavDropdown.Item>
                <NavDropdown.Item href="#">Atsijungti</NavDropdown.Item>
              </NavDropdown>
              </svg>
            </Button>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};
export { NavigationBar };

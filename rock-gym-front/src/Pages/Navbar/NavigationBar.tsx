import React from "react";
import { NavDropdown } from "react-bootstrap";
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useNavigate } from 'react-router-dom';


const NavigationBar = () => {
  const navigate = useNavigate();
  const token = localStorage.getItem("accessToken");

  const Logout = (e: any): void => {
    e.preventDefault();
    localStorage.removeItem("accessToken");
    navigate("/");
  };

  return (
    <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
      <Container>
        <Navbar.Brand href="/">ROCKGYM</Navbar.Brand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          {!token ? (
            <>
          <Nav className="me-auto">
            <Nav.Link onClick={() => navigate("/login")}>Prisijungti</Nav.Link>
            <Nav.Link onClick={() => navigate("/register")}>Registruotis</Nav.Link>
          </Nav>
            </>
          ) : (
            <>
           <Nav className="me-auto">
            <Nav.Link onClick={() => navigate("/grouptrainings")}>Grupinės treniruotės</Nav.Link>
            <Nav.Link onClick={() => navigate("/subscriptions")}>Abonementai</Nav.Link>
          </Nav>
            <Nav className="me-right">              
              <NavDropdown title={<i className="bi bi-file-earmark-person"></i>} id="basic-nav-dropdown" >
                <NavDropdown.Item onClick={() => navigate("/profile")}>Paskyra</NavDropdown.Item>
                <NavDropdown.Item onClick={(e) => Logout(e)}>Atsijungti</NavDropdown.Item>
              </NavDropdown>
          </Nav>
          </>
          )}
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};
export { NavigationBar };

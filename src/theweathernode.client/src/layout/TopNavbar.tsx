import { Navbar, Nav, Container } from "react-bootstrap";
import { Link } from "react-router-dom";
import logo from "../assets/logo.png";

export default function TopNavbar() {
  return (
    <Navbar variant="dark" expand="lg">
      <Container fluid>
        <Navbar.Brand as={Link} to="/">
          <img src={logo} height="150" className="me-2" />
        </Navbar.Brand>
        <Nav className="ms-auto">
          <Nav.Link as={Link} to="/weather">
            Weather
          </Nav.Link>
        </Nav>
      </Container>
    </Navbar>
  );
}

import logo from './logo.svg';
import './App.css';

import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';

import { Navbar, Container, Nav } from 'react-bootstrap';

import { Products } from './Components/Products';
import { Inventory } from './Components/Inventory';

function App() {
  return (
    <Router>
      <Navbar bg="dark" variant="dark" expand="lg">
        <Container>
          <Nav>
            <Nav.Link as={Link} to="/Products">
              Products
            </Nav.Link>
            <Nav.Link as={Link} to="/Inventory">
              Inventory
            </Nav.Link>
          </Nav>
        </Container>
      </Navbar>

      <Routes>
        <Route path="/Products" element={<Products />}></Route>
        <Route path="/Inventory" element={<Inventory />}></Route>
      </Routes>
    </Router>
  );
}

export default App;

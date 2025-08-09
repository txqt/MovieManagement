import { Navbar, Nav, Container, Form, Button } from 'react-bootstrap'
import { Search, Film } from 'lucide-react'
import { Link, useNavigate } from 'react-router-dom'
import { useState } from 'react'

function Header() {
  const [searchTerm, setSearchTerm] = useState('')
  const navigate = useNavigate()

  const handleSearch = (e) => {
    e.preventDefault()
    if (searchTerm.trim()) {
      navigate(`/search?q=${encodeURIComponent(searchTerm)}`)
    }
  }

  return (
    <Navbar bg="dark" variant="dark" expand="lg" sticky="top">
      <Container>
        <Navbar.Brand as={Link} to="/">
          <Film className="me-2" />
          MovieHub
        </Navbar.Brand>
        
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link as={Link} to="/">Trang chủ</Nav.Link>
            <Nav.Link as={Link} to="/category/action">Hành động</Nav.Link>
            <Nav.Link as={Link} to="/category/comedy">Hài</Nav.Link>
            <Nav.Link as={Link} to="/category/horror">Kinh dị</Nav.Link>
          </Nav>
          
          <Form className="d-flex" onSubmit={handleSearch}>
            <Form.Control
              type="search"
              placeholder="Tìm phim..."
              className="me-2"
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
            />
            <Button variant="outline-light" type="submit">
              <Search size={18} />
            </Button>
          </Form>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  )
}

export default Header
import { Navbar, Nav, Container, Form, Button } from 'react-bootstrap'
import { Search, Film } from 'lucide-react'
import { Link, useNavigate } from 'react-router-dom'
import { useState, useContext } from 'react'
import { AuthContext } from '../context/AuthContext'
import { Trans } from 'react-i18next';

function Header() {
  const [searchTerm, setSearchTerm] = useState('')
  const navigate = useNavigate()
  const { auth, logout } = useContext(AuthContext)

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
            <Nav.Link as={Link} to="/"><Trans i18nKey={'title'} ns='home' /></Nav.Link>
            <Nav.Link as={Link} to="/category/action"><Trans i18nKey={'categories.action'} ns='header' /></Nav.Link>
            <Nav.Link as={Link} to="/category/comedy"><Trans i18nKey={'categories.comedy'} ns='header' /></Nav.Link>
            <Nav.Link as={Link} to="/category/horror"><Trans i18nKey={'categories.horror'} ns='header' /></Nav.Link>
          </Nav>

          <Form className="d-flex me-3" onSubmit={handleSearch}>
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

          {!auth ? (
            <div className="d-flex">
              <Button
                variant="outline-light"
                className="me-2"
                as={Link}
                to="/login"
              >
                Đăng nhập
              </Button>
              <Button
                variant="light"
                as={Link}
                to="/register"
              >
                Đăng ký
              </Button>
            </div>
          ) : (
            <Button
              variant="outline-light"
              onClick={logout}
            >
              Đăng xuất
            </Button>
          )}
        </Navbar.Collapse>
      </Container>
    </Navbar>
  )
}

export default Header
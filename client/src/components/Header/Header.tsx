
import chameleonIcon from '/chameleon.svg'
import searchIcon from '/search.svg'
import personIcon from '/person-circle.svg'
import './header.scss'
import '../../scss/_globals.scss'
import { Navbar, Container, Nav, Col, NavDropdown, Form, Button } from 'react-bootstrap'


const Header = () => {

  const handleFormSubmit = () => {
    console.log('do something when form is submitted from navbar on larger screen sizes')
  }
  
  return (
      <Container className='shadow' >
        <Navbar sticky='top' >
          <Container fluid>
            <Col>
              <Navbar.Brand href="/" className='d-flex align-items-center ms-auto'>
                <img
                  alt=""
                  src={chameleonIcon}
                  width="40"
                  height="40"
                  className="d-inline-block align-top me-3"
                />
                <span className='d-none d-md-inline-block text-primary font-weight-bolder mb-0 gradient-text fs-1 font-weight-bold'>Emerald Blog</span>
             </Navbar.Brand>
           </Col>
           <Col className='d-flex justify-content-end ms-auto'>
            <Form className="d-flex flex-row  " onSubmit={handleFormSubmit}>
              <Form.Control
                type="search"
                placeholder={"Search"}
                className="me-2 bg-white border border-secondary border-right-0"
                aria-label="Search"
              />
              <Button variant="none" type="submit">
                <img src={searchIcon} alt="search-icon" width='25' height='25'  />
              </Button>
            </Form>
            <Nav className="text-center d-flex flex-row align-items-center">
              <NavDropdown title={ <img src={personIcon} alt="person-icon" width='25' height='25'  />} id="nav-dropdown" align={"end"} className='custom-dropdown'>
                <NavDropdown.Item eventKey="4.1" className='text-primary'>USERNAME</NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item eventKey="4.2" className='text-secondary'>Create Post</NavDropdown.Item>
                <NavDropdown.Item eventKey="4.3" className='text-secondary'>Profile</NavDropdown.Item>
                <NavDropdown.Item eventKey="4.4" className='text-secondary'>Favorites</NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item eventKey="4.5">Log In/Out</NavDropdown.Item>
              </NavDropdown>
            </Nav>
          </Col>
        </Container>
      </Navbar>
     </Container>
  )
}

export default Header
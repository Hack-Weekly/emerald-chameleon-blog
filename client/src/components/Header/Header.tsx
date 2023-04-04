import React, { FormEvent } from 'react'
import chameleonIcon from '/chameleon.svg'
import searchIcon from '/search.svg'
import personIcon from '/person-circle.svg'
import './header.scss'
import '../../scss/_globals.scss'
import { Navbar, Container, Nav, Col, NavDropdown, Form, Button} from 'react-bootstrap'


const Header = () => {

  const handleMobileSearchClick = () => {
    console.log('do something when search icon is clicked in mobile view')
  }

  const handleFormSubmit = () => {
    console.log('do something when form is submitted from navbar on larger screen sizes')
  }
  
  return (
      <Container className='shadow' >
        <Navbar sticky='top' >
          <Container fluid>
              <Navbar.Brand href="/" className='d-flex align-items-end'>
                <img
                  alt=""
                  src={chameleonIcon}
                  width="40"
                  height="40"
                  className="d-inline-block align-top me-3"
                />
                <span className='d-none d-md-inline-block text-primary font-weight-bolder mb-0 gradient-text large-text font-weight-bold'>Emerald Blog</span>
              </Navbar.Brand>
      
            <Nav className="text-center ms-auto d-flex align-items-center">
              <Form className="d-none d-lg-flex" onSubmit={handleFormSubmit}>
                  <Form.Control
                    type="search"
                    placeholder="Search"
                    className="me-2 bg-white border border-secondary"
                    aria-label="Search"
                  />
                  <Button variant="none" type="submit">
                    <img src={searchIcon} alt="search-icon" width='25' height='25'  />
                  </Button>
              </Form>
                <Nav.Item className='mx-2 d-lg-none' onClick={handleMobileSearchClick}>
                  <img src={searchIcon} alt="search-icon" width='25' height='25'  />
                </Nav.Item>
                <Nav.Item className='ms-2 me-0'>
                  <img src={personIcon} alt="search-icon" width='25' height='25'  />
                </Nav.Item>
                
                <NavDropdown title='' id="nav-dropdown" align={"end"} className='custom-dropdown'>
                  <NavDropdown.Item eventKey="4.1" className='text-primary'>USERNAME</NavDropdown.Item>
                  <NavDropdown.Divider />
                  <NavDropdown.Item eventKey="4.2" className='text-secondary'>Create Post</NavDropdown.Item>
                  <NavDropdown.Item eventKey="4.3" className='text-secondary'>Profile</NavDropdown.Item>
                  <NavDropdown.Item eventKey="4.4" className='text-secondary'>Favorites</NavDropdown.Item>
                  <NavDropdown.Divider />
                  <NavDropdown.Item eventKey="4.5">Log In/Out</NavDropdown.Item>
                </NavDropdown>
              </Nav>
        </Container>
      </Navbar>
     </Container>
  )
}

export default Header
import React from 'react'
import chameleonIcon from '/chameleon.svg'
import searchIcon from '/search.svg'
import personIcon from '/person.svg'
import '../../scss/_globals.scss'
import { Navbar, Container, Nav, Col, Button } from 'react-bootstrap'


const Header = () => {
  return (
      <Container>
        <Navbar sticky='top' className=''>
          <Container>
            <Navbar.Brand href="#home">
              <img
                alt=""
                src={chameleonIcon}
                width="40"
                height="40"
                className="d-inline-block align-top"
              />
            </Navbar.Brand>
            <Col className='text-success'>
            Emerald Blog
            </Col>
            <Nav className="text-center ms-auto">
            <Button type="button" className="btn btn-outline-secondary btn-light me-3">Create Post</Button>
              <Nav.Link href="#">
              <img src={searchIcon} alt="search-icon" width='25' height='25'  />
              </Nav.Link>
              
              <Nav.Link href="#">
              <img src={personIcon} alt="person-icon" width='30' height='30' />
              </Nav.Link>
            </Nav>

        </Container>
      </Navbar>
     </Container>
  )
}

export default Header
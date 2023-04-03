import React from 'react'
import chameleonIcon from '/chameleon.svg'
import searchIcon from '/search.svg'
import personIcon from '/person.svg'
import styles from './Header.module.scss'
import {Container, Nav, Navbar } from 'react-bootstrap'

const Header = () => {
  return (
      <header className={styles.header}>
        <Navbar collapseOnSelect expand='lg' sticky='top'>
        <Container>
        <Navbar.Brand href="#home">
            <img
              alt=""
              src={chameleonIcon}
              width="40"
              height="40"
              className="d-inline-block align-top"
            />{' '}
            <span className={styles.brandText}>  Emerald Blog </span>
          </Navbar.Brand>
          
          <div className={styles.iconContainer}>
          <Nav.Link href='#' className={styles.createPostLink}>
              Create Post
            </Nav.Link>
            <img src={searchIcon} alt="search-icon" width='25' height='25' />
            <img src={personIcon} alt="person-icon" width='25' height='25' />
          </div>

        {/* <Navbar.Toggle aria-controls="responsive-navbar-nav" /> */}
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="text-center ms-auto">
              <Nav.Link href="#">Home</Nav.Link>
              <Nav.Link href="#">Create Post</Nav.Link>
              <Nav.Link href="#">Account</Nav.Link>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      </header>
  )
}

export default Header
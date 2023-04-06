import Logo from '/chameleon.svg'
import { Container, Form, Image, Navbar } from 'react-bootstrap'
import '../scss/_globals.scss'

export function Footer() {
    return (
        <Navbar style={{ height: "calc(100vh - 80px)"}}>
            <Container className='d-flex flex-column'>
                <Navbar.Brand>
                    <img 
                        src={Logo} 
                        width={'50px'} 
                        height={'50px'} 
                        className='align-center'
                    />
                </Navbar.Brand>
                <p className='text-center text-secondary text-opacity-50'>
                    &copy; Emerald Blog <br />
                    <span className='fst-italic'>2023</span>
                </p>
            </Container>
        </Navbar>
    )
}
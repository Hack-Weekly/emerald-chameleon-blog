'use client'
import {
   Login,
   SaveTokenToLocalStorage,
} from '../services/authentication/authentication.service'
import { useEffect, useState } from 'react'
import { LoginDTO, UserDTO } from '../services/authentication/types/authentication.type'
import useUser from '../hooks/useUser'
import { Form, Button, Container } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'

const LoginForm = () => {
  const [route, setRoute] = useState('')
    const [userDTO, setUserDTO] = useState<LoginDTO>({
       email: '',
       username: '',
       password: '',
    })

    const loggedInUser: UserDTO = useUser()

    const handleSubmit = async (e: any) => {
        const tokens = await Login(userDTO)
        SaveTokenToLocalStorage(tokens)
    }

    const handleChange = (e: any) => {
        setUserDTO({ ...userDTO, [e.target.name]: e.target.value })
    }

    useEffect(() => {
        if (loggedInUser && loggedInUser.username) {
            setRoute('/profile')
        }
    })

  return (
        <Form onSubmit={(e) => handleSubmit} className='border p-3 rounded-5'>
            <h1 className='text-center'>Login</h1>
            <Form.Group className='my-3'>
                <Form.Control
                    type="text"
                    name="username"
                    placeholder="Username"
                    required
                    onChange={(e) => handleChange(e)}
                />
            </Form.Group>
            <Form.Group className='my-3'>
                <Form.Control
                    type="email"
                    name="email"
                    placeholder="Email"
                    required
                    onChange={(e) => handleChange(e)}
                />
            </Form.Group>
            <Form.Group className='my-3'>
                <Form.Control
                    type="password"
                    name="password"
                    placeholder="Password"
                    required
                    onChange={(e) => handleChange(e)}
                />
            </Form.Group>
            <Container className='text-center'>
                <LinkContainer to="/register">
                    <a>create account</a>
                </LinkContainer>

                <Container fluid className='mt-3'>
                    <LinkContainer to="/">
                        <Button variant="outline-secondary" className='mx-2'>
                            Cancel
                        </Button>
                    </LinkContainer>

                    <LinkContainer to={route?? '/login'}>
                        <Button variant="primary" type="submit" className='mx-2'>
                            Login
                        </Button>
                    </LinkContainer>
                </Container>
            </Container>
        </Form>
  )
}

export default LoginForm

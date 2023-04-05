import {
  Register,
  SaveTokenToLocalStorage,
} from '../services/authentication/authentication.service'
import { useEffect, useState } from 'react'
import {
  RegisterDTO,
  UserDTO,
} from '../services/authentication/types/authentication.type'
import useUser from '../hooks/useUser'
import { Form, Button, Container } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'

const RegisterForm = () => {
  const [route, setRoute] = useState('')
  const [userDTO, setUserDTO] = useState<RegisterDTO>({
    name: '',
    email: '',
    username: '',
    password: '',
    mobile: '',
  })

  const handleSubmit = async (e: any) => {
    e.preventDefault()
    const tokens = await Register(userDTO)
    SaveTokenToLocalStorage(tokens)

    e.target.reset()
  }

  const handleChange = (e: any) => {
    setUserDTO({ ...userDTO, [e.target.name]: e.target.value })
  }

  const loggedInUser: UserDTO = useUser()

  useEffect(() => {
    if (loggedInUser && loggedInUser.username) {
      setRoute('/dashboard')
    }
  })

  return (
    <Form className='border p-3 rounded-5' onSubmit={(e) => handleSubmit(e)}>
        <h1 className='text-center'>Create an Account</h1>
        <Form.Group className='my-3'>
            <Form.Control
            type="text"
            name="username"
            placeholder="Username"
            onChange={(e) => handleChange(e)}
            />
        </Form.Group>
        <Form.Group className='my-3'>
            <Form.Control
            type="text"
            name="password"
            placeholder="Password"
            onChange={(e) => handleChange(e)}
            />
        </Form.Group>
        <Form.Group className='my-3'>
            <Form.Control
            type="text"
            name="email"
            placeholder="Email"
            onChange={(e) => handleChange(e)}
            />
        </Form.Group>
        <Form.Group className='my-3'>
            <Form.Control
            type="text"
            name="name"
            placeholder="Name"
            onChange={(e) => handleChange(e)}
            />
        </Form.Group>
        <Form.Group className='my-3'>
            <Form.Control
            type="text"
            name="mobile"
            placeholder="mobile"
            onChange={(e) => handleChange(e)}
            />
        </Form.Group>
        <Container className='text-center'>
            <LinkContainer to='/login'>
                <a>Login to existing account</a>
            </LinkContainer>

            <Container fluid className='mt-3'>
                    <LinkContainer to="/">
                        <Button variant="outline-secondary" className='mx-2'>
                            Cancel
                        </Button>
                    </LinkContainer>

                    <LinkContainer to={route?? '/register'}>
                        <Button variant="primary" type="submit" className='mx-2'>
                            Login
                        </Button>
                    </LinkContainer>
                </Container>
        </Container>
    </Form>
  )
}

export default RegisterForm

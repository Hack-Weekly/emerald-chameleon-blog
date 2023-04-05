import { useState } from 'react'
import { HttpTransportType, HubConnectionBuilder } from '@microsoft/signalr'
import { ReadTokensFromLocalStorage } from '../services/authentication/authentication.service'
import { Button, Container, Form } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'

type CreateChatValues = {
  title: string,
  body: string,
  tags: [],
  category: string,
}

export default function CreateNewChat() {
  const [route, setRoute] = useState('')
  const [formValues, setFormValues] = useState<CreateChatValues>({
    title: '',
    body: '',
    tags: [],
    category: '',
  })

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target
    setFormValues({
      ...formValues,
      [name]: value,
    })
  }

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
      e.preventDefault()

        try {
        const connection = new HubConnectionBuilder()
            .withUrl(process.env.NEXT_PUBLIC_API_URL, {
            skipNegotiation: true,
            transport: HttpTransportType.WebSockets,
            accessTokenFactory: () => {
                return ReadTokensFromLocalStorage().accessToken ?? ''
            }
            })
            .build() 

        await connection.start()
        connection.invoke('CreatePost', formValues.title, formValues.description)
        const connectionArr = Object.entries(connection)
        connection.invoke('GetActivePosts')
        connection.on('activePosts', (postsList) =>
            postsList.unshift(connectionArr)
        )
        if (connectionArr[16][1] === 'Connected') {
            setRoute('/dashboard')
        }
        } catch (error) {
        alert('Failed to create new post, please try again.')
        setRoute('/dashboard')
        console.log(error)
        }
    }

    return (
        <Container fluid>
        <Container fluid>
            <LinkContainer to="/dashboard">&#x25c4; Back</LinkContainer>
            <h2>New Chat</h2>
        </Container>
            <Form onSubmit={handleSubmit}>
                <Form.Group>
                    <Form.Label>Title</Form.Label>
                    <Form.Control 
                    id="title"
                    type="text"
                    name="title"
                    required
                    value={formValues.title}
                    onChange={handleInputChange}
                    />
                </Form.Group>

                <Form.Group>
                    <Form.Label>Body</Form.Label>
                    <Form.Control 
                    id="body"
                    type="text"
                    name="body"
                    required
                    value={formValues.body}
                    onChange={handleInputChange}
                    />
                </Form.Group>

                <Form.Group>
                    <Form.Label>Tags</Form.Label>
                    <Form.Control 
                    id="tags"
                    type="text"
                    name="tags"
                    value={formValues.tags}
                    onChange={handleInputChange}
                    />
                </Form.Group>

                <Form.Group>
                    <Form.Label>Category</Form.Label>
                    <Form.Control 
                    id="category"
                    type="text"
                    name="category"
                    value={formValues.category}
                    onChange={handleInputChange}
                    />
                </Form.Group>

                <Form.Group>
                    <Form.Label>Image</Form.Label>
                    <Form.Control 
                    id="uploadImage"
                    type="file"
                    name="image"
                    />
                </Form.Group>

                <Container>
                    <Button variant="primary" type="submit">Create Post</Button>
                    <Button variant="outline-secondary">Cancel</Button>
                </Container>
            </Form>
        </Container>
    )
}
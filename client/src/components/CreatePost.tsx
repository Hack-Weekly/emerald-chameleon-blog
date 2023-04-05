import { useState } from 'react'
import { HttpTransportType, HubConnectionBuilder } from '@microsoft/signalr'
import { ReadTokensFromLocalStorage } from '../services/authentication/authentication.service'
import { Button, Container, Form } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'

type CreateChatValues = {
  title: string,
  description: string,
}

export default function CreateNewChat() {
  const [route, setRoute] = useState('')
  const [formValues, setFormValues] = useState<CreateChatValues>({
    title: '',
    description: '',
  })

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { title, value } = e.target
    setFormValues({
      ...formValues,
      [title]: value,
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
                    <Form.Control 
                    id="name"
                    type="text"
                    name="title"
                    placeholder="Title"
                    required
                    value={formValues.title}
                    onChange={handleInputChange}
                    />
                </Form.Group>

                <Form.Group>
                    <Form.Control 
                    id="description"
                    type="text"
                    name="description"
                    placeholder="Description"
                    required
                    value={formValues.description}
                    onChange={handleInputChange}
                    />
                </Form.Group>

                <Container>
                    <Button type="submit">Create Post</Button>
                </Container>
            </Form>
        </Container>
    )
}
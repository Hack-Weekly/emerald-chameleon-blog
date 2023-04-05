import { useState } from 'react'
import { ReadTokensFromLocalStorage } from '../services/authentication/authentication.service'
import "../scss/styles.scss"
import { Button, Container, Form } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'

type CreateChatValues = {
  title: string,
  body: string,
  tags: [],
  category: string,
}

const CreatePost = () => {
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
            console.log("post request")
        } catch (error) {
        alert('Failed to create new post, please try again.')
        setRoute('/dashboard')
        console.log(error)
        }
    }

    return (
        <Form onSubmit={handleSubmit} className='border p-3 rounded-5'>
            <h2 className="text-center">New Chat</h2>
            <Form.Group className="my-3">
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

            <Form.Group className="my-3">
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

            <Form.Group className="my-3">
                <Form.Label>Tags</Form.Label>
                <Form.Control 
                id="tags"
                type="text"
                name="tags"
                value={formValues.tags}
                onChange={handleInputChange}
                />
            </Form.Group>

            <Form.Group className="my-3">
                <Form.Label>Category</Form.Label>
                <Form.Control 
                id="category"
                type="text"
                name="category"
                value={formValues.category}
                onChange={handleInputChange}
                />
            </Form.Group>

            <Form.Group className="my-3">
                <Form.Label>Image</Form.Label>
                <Form.Control 
                id="uploadImage"
                type="file"
                name="image"
                />
            </Form.Group>

            <Container className="my-3 text-center">
                <Button className="mx-2" variant="primary" type="submit">
                    Create Post
                </Button>

                <LinkContainer to="/dashboard">
                        <Button variant="outline-secondary" className='mx-2'>
                            Cancel
                        </Button>
                </LinkContainer>
            </Container>
        </Form>
    )
}

export default CreatePost
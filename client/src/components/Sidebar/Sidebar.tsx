import React from 'react'
import { Container, Row, Col, Image } from 'react-bootstrap'
import catImage from '/catTestImage.png'
import './sidebar.scss'

type Props = {}

const Sidebar = (props: Props) => {
  return (
    <Container style={{ width: '18rem' }} className='bg-light p-4 rounded'>
      <Row className='mb-4'>
        <Col><Image src={catImage} width='125' height='125' roundedCircle /></Col>
        <Col>Author Name</Col>
      </Row>
      <Row className='my-4 px-2'>
        Short paragraph or two about he author.
      </Row>
      <Row className='my-4'>
        <h4 className='text-secondary'>Other posts by Author:</h4>
        <span>post 1</span>
        <span>post 2</span>
        <span>post 3</span>
      </Row>
      <Row className='mt-4'>
        <h4 className='text-secondary'>Hot posts on Emerald Blog</h4>
        <span>post 1</span>
        <span>post 2</span>
        <span>post 3</span>
      </Row>
    </Container>
     
        
  )
}

export default Sidebar
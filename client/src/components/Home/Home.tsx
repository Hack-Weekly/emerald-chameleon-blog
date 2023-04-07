import React from 'react'
import Sidebar from '../Sidebar/Sidebar'
import CardGrid from '../CardGrid/CardGrid'
import './home.scss'
import { Container, Row, Col} from 'react-bootstrap'

type Props = {}

const Home = (props: Props) => {
  return (
   
      <Container fluid className="d-flex flex-column p-2 container-fluid">
          <Row className='w-100'>
            <h2>Filter Bar</h2>
          </Row>
          <Row>
            <Col lg={9} md={8}>
              <CardGrid />
            </Col>
            <Col lg={3} md={4}>
              <Sidebar />
            </Col>
          </Row>
        </Container>

        
  )
}

export default Home
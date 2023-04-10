import React from 'react'
import Sidebar from '../Sidebar/Sidebar'
import CardGrid from '../CardGrid/CardGrid'
import { Container, Row, Col} from 'react-bootstrap'
import FilterBar from '../FilterBar'

type Props = {}

const Home = (props: Props) => {
  return (
   
      <Container fluid className="d-flex flex-column p-3">
          <Row className='w-100'>
            <Col><FilterBar /></Col>
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
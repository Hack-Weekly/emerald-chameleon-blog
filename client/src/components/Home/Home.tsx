import React from 'react'
import Sidebar from '../Sidebar/Sidebar'
import CardGrid from '../CardGrid/CardGrid'
import './home.scss'
import { Container } from 'react-bootstrap'

type Props = {}

const Home = (props: Props) => {
  return (
        <main className="d-flex flex-column">
          <h1>Put Filter Bar Here</h1>
          <Container>
            <CardGrid />
            <Sidebar />
          </Container>
        </main>
  )
}

export default Home
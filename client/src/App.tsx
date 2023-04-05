import { useState } from 'react'
import './scss/styles.scss' 
import CardGrid from './components/CardGrid/CardGrid' 
import { Footer } from './components/Footer'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { Container } from 'react-bootstrap'
import LoginForm from './components/LoginForm'

function App() {
  return (
    <Container fluid>

      <Router>
        <h1>Header goes here</h1>
        
        <Routes>
          <Route path="/login" element={<LoginForm />} />
          {/* replace card grid with home page when we have it */}
          <Route path="/" element={<CardGrid />} />
        </Routes>

        <Footer />
      </Router>
    </Container>
  )
}

export default App

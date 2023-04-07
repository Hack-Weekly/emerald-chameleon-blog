import { useState } from 'react'
import './scss/styles.scss' 
import 'bootstrap/dist/css/bootstrap.min.css'
import { Footer } from './components/Footer'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { Container } from 'react-bootstrap'
import LoginForm from './components/LoginForm'
import Header from './components/Header/Header'
import Home from './components/Home/Home'


function App() {
  return (
    <Container fluid >
      <Router>
        <Header />
        <Routes>
          <Route path="/login" element={<LoginForm />} />
          <Route path="/" element={<Home />} />
        </Routes>
        <Footer />
      </Router>
    </Container>
  )
}

export default App






import { Footer } from './components/Footer'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { Container } from 'react-bootstrap'

function App() {
  return (
    <Container fluid>
      <Router>
        <h3>header goes here</h3>
        
        <Routes>
          
        </Routes>

        <Footer />
      </Router>
    </Container>
  )
}

export default App

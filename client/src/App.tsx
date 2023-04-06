
import { Footer } from './components/Footer'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { Container } from 'react-bootstrap'
import LoginForm from './components/LoginForm'
import Sidebar from './components/Sidebar/Sidebar'

function App() {
  return (
    <Container fluid style={{ backgroundColor: '#F2F2F2'}}>
      <Router>
        <h1>Header goes here</h1>
        <Sidebar />
        <Routes>
          <Route path="/login" element={<LoginForm />} />
        </Routes>

        <Footer />
      </Router>
    </Container>
  )
}

export default App

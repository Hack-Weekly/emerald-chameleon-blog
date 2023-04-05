import { useState } from 'react'
import './scss/styles.scss' 
import CardGrid from './components/CardGrid/CardGrid' 
import LoginForm from './components/LoginForm'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div className="container py-4 px-3 mx-auto" style={{ backgroundColor: '#f2f2f2'}}>
      <Router>
        <h1>Header goes here</h1>

        <Routes>
          <Route path="/login" element={<LoginForm />} />
          {/* replace card grid with home page when we have it */}
          <Route path="/" element={<CardGrid />} />
        </Routes>

      </Router>
    </div>
  )
}

export default App

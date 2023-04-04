import { useState } from 'react'
import LoginForm from './components/LoginForm'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div className="container py-4 px-3 mx-auto">
      <Router>
        <h1>Header goes here</h1>

        <Routes>
          <Route path="/login" element={<LoginForm />} />
        </Routes>

      </Router>
    </div>
  )
}

export default App

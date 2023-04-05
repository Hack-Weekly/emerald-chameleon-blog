import { useState } from 'react'
import LoginForm from './components/LoginForm'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'


import Header from './components/Header/Header'
import 'bootstrap/dist/css/bootstrap.min.css'


function App() {
  const [count, setCount] = useState(0)

  return (
    <div className="container py-4 px-3 mx-auto">
      <Router>
       <Header />

        <Routes>
          <Route path="/login" element={<LoginForm />} />
        </Routes>

      </Router>
    </div>
  )
}

export default App





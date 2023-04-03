import { useState } from 'react'
import Header from './components/Header/Header'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div className="container py-4 px-3 mx-auto">
      <Header />
      <h1>Emerald Chameleon Blog</h1>
      <button className="btn btn-primary">Click to create winning project</button>
    </div>
  )
}

export default App

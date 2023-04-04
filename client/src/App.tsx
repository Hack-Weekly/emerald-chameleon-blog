import { useState } from 'react'
import PostCard from './components/PostCard'
import CardGrid from './components/CardGrid'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div className="container py-4 px-3 mx-auto">
      <h1>Emerald Chameleon Blog</h1>
      <button className="btn btn-primary">Click to create winning project</button>
      {/* <PostCard /> */}
      <CardGrid /> 
    </div>
  )
}

export default App

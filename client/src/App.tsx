import { useState } from 'react'


import Header from './components/Header/Header'
import 'bootstrap/dist/css/bootstrap.min.css'


function App() {
  const [count, setCount] = useState(0)

  return (
    <div className="container py-4 px-3 mx-auto">
 
          <Header />

       
     
      
    </div>
  )
}

export default App





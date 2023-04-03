import React from 'react'
import chameleonIcon from './chameleon.svg'

const Header = () => {
  return (
   <header>
    <nav>
      <div className='bd-navbar-toggle'>
            <a className='navbar-brand' href="#">
                <img src={chameleonIcon} alt='logo' width='40' height='40' />
                Emerald Blog
            </a>
        </div> 
    </nav>
   </header>

      
  
  )
}

export default Header
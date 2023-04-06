import { useLocation } from 'react-router-dom'
import { useEffect, useState } from 'react'
import { Container } from 'react-bootstrap'
import SidebarAuthorSection from './SidebarAuthorSection'
import SidebarTagsSection from './SidebarTagsSection'
import SidebarHotPosts from './SidebarHotPosts'
import './sidebar.scss'

type Props = {}

const Sidebar = (props: Props) => {

  const [ isHomePage, setIsHomePage ] = useState(true)
    
    // Get pathname of current page and set state of isHomePage accordingly
    const location = useLocation();
    useEffect(() => {
      console.log(location.pathname);
      if (location.pathname === '/') {
        setIsHomePage(true)
      } else {
        setIsHomePage(false)
      }
    });


  return (
    <Container style={{ width: '15rem' }} className='bg-light p-4 rounded'>

      {/* if on home page, should show list of tags and hot posts */}
      {isHomePage && <SidebarTagsSection />}

      {/* if on single post page, shows Author information instead of tags */}
      {!isHomePage && <SidebarAuthorSection />}

      {/* show hot posts on both home page and single post page */}
      <SidebarHotPosts />

    </Container>
     
        
  )
}

export default Sidebar
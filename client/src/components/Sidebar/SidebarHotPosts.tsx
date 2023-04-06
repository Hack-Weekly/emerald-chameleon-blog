import { Row } from 'react-bootstrap'

type Props = {}

const SidebarHotPosts = (props: Props) => {
  return (
    <Row className='mt-4'>
        <h4 className='text-secondary fs-6'>Hot posts on Emerald Blog</h4>
        <span>post 1</span>
        <span>post 2</span>
        <span>post 3</span>
   </Row>
  )
}

export default SidebarHotPosts
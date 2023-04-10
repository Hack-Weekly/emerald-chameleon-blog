import './sidebar.scss'
import { Row, Image } from 'react-bootstrap'
import catImage from '/catTestImage.png'


type Props = {}

const SidebarAuthorSection = (props: Props) => {
  return (
    <>
      <Row className='mx-auto justify-center'>
        <Image src={catImage} width='125' roundedCircle className=''/>
        <h3 className='mt-3 text-center fs-5 text-primary'>Author Name</h3>
      </Row> 
      
      <Row className='my-4 px-2'>
        <p>{'Short paragraph or two about he author.'}</p>
      </Row>

      <Row className='my-4'>
        <h4 className='text-secondary fs-6'>Other posts by Author:</h4>
        <span>post 1</span>
        <span>post 2</span>
        <span>post 3</span>
      </Row>
    </>
  )
}

export default SidebarAuthorSection




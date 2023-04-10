import Card from 'react-bootstrap/Card';
import { Post } from './CardGrid';
import './cardGrid.scss'
import '../../scss/styles.scss'
import { LinkContainer } from 'react-router-bootstrap';
import { Link } from 'react-router-dom'

type PostCardProps = {
  post: Post;
  bgColor: string;
}

const PostCard= (props: PostCardProps) => {

  const cardBody = `${props.post.body.slice(0, 80)}...`
  const cardTitle =`${props.post.title.slice(0, 30)}`
 
  return (
    <Link to={`/BlogPost/${props.post.id}`} className='text-decoration-none'>
      <Card style={{ width: '15rem' }} className={`p-2 text-light h-100 w-100 mx-auto ${props.bgColor}`}>
        <Card.Img variant="top" src="/testImage1.png" width='120'/>
        <Card.Body>
          <Card.Title>{cardTitle}</Card.Title>
          <Card.Subtitle className='fs-6 my-2'>MM/DD/YYYY</Card.Subtitle>
          <Card.Text className='fw-normal' >
            {cardBody}
          </Card.Text>
        </Card.Body>
      </Card>
    </Link>
  ) 
}

export default PostCard
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
 
  return (
    <Link to={`/BlogPost/${props.post.id}`} className='text-decoration-none'>
      <Card style={{ width: '18rem' }} className={`p-2 text-light h-100 ${props.bgColor}`}>
        <Card.Img variant="top" src="/testImage1.png" />
        <Card.Body>
          <Card.Title>{props.post.title}</Card.Title>
          <Card.Subtitle>MM/DD/YYYY</Card.Subtitle>
          <Card.Text >
            {cardBody}
          </Card.Text>
        </Card.Body>
      </Card>
    </Link>
  ) 
}

export default PostCard
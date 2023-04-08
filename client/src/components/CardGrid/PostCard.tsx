import Card from 'react-bootstrap/Card'
import { Post } from './CardGrid'
import LikeButton from '../LikeBtn'
import './cardGrid.scss'
import '../../scss/styles.scss'
import { LinkContainer } from 'react-router-bootstrap'
import { Link } from 'react-router-dom'

type PostCardProps = {
  post: Post
  bgColor: string
}

const PostCard = (props: PostCardProps) => {
  const cardBody = `${props.post.body.slice(0, 80)}...`

  return (
    <Link to={`/BlogPost/${props.post.id}`} className='text-decoration-none'>

      <Card style={{ width: '18rem' }} className={`p-2 text-light h-100  mx-auto ${props.bgColor}`}>
        <Card.Img variant="top" src="/testImage1.png" />
        <Card.Body>
          <Card.Title>{props.post.title}</Card.Title>
          <Card.Subtitle className="fs-6 my-2">MM/DD/YYYY</Card.Subtitle>
          <Card.Text className="fw-normal">{cardBody}</Card.Text>
          <LikeButton />
        </Card.Body>
      </Card>
    </Link>
  )
}

export default PostCard

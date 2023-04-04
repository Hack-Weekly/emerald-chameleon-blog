import React from 'react'
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import { Post } from './CardGrid';

type PostCardProps = {
  post: Post;
}

const PostCard= (props: PostCardProps) => {
  return (
    <Card style={{ width: '18rem' }}>
    <Card.Img variant="top" src="/testImage1.png" />
    <Card.Body>
      <Card.Title>{props.post.title}</Card.Title>
      <Card.Text>
        {props.post.body}
      </Card.Text>
    </Card.Body>
  </Card>
  ) 
}

export default PostCard
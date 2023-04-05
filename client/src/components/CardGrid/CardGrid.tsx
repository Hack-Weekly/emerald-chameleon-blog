import React, { useEffect } from 'react'
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { LinkContainer } from 'react-router-bootstrap';
import { useState } from 'react'
import PostCard from './PostCard';

export type Post = {
    id: number;
    title: string;
    body: string;
  }

const CardGrid: React.FC = () => {

    const [ posts, setPosts ] = useState<Post[]>([])
    
    // background colors for cards
    const bgColors = ['black', 'grey', 'pink', 'green'];

    // change url once we have posts and can fetch them
    const url = 'https://jsonplaceholder.typicode.com/posts?_limit=10'

    useEffect(() => {
      fetch(url)
      .then(response => response.json())
      .then(data => setPosts(data))
      .catch(err => console.log(err))
    },[])
    
    return (
        <Row xs={1} md={2} lg={3} className="g-4">
          {posts.map((post, index) => (
            <Col key={post.id}>
              <PostCard post={post} bgColor={bgColors[index % bgColors.length]}/>
            </Col>
          ))}
        </Row>
      )
  }

export default CardGrid
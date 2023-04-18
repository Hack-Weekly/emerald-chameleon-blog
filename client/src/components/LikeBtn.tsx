import { useState } from 'react'
import ButtonGroup from 'react-bootstrap/ButtonGroup'
import ToggleButton from 'react-bootstrap/ToggleButton'

import { FaThumbsUp, FaThumbsDown } from 'react-icons/fa'

export default function LikeButton() {
  const [liked, setLiked] = useState(false)
  const [disliked, setDisliked] = useState(false)
  const [likes, setLikes] = useState(0)
  const [dislikes, setDislikes] = useState(0)

  const handleLike = () => {
    if (liked) {
      setLiked(false)
      setLikes(likes - 1)
    } else {
      setLiked(true)
      setLikes(likes + 1)
      if (disliked) {
        setDisliked(false)
        setDislikes(dislikes - 1)
      }
    }
  }

  const handleDislike = () => {
    if (disliked) {
      setDisliked(false)
      setDislikes(dislikes - 1)
    } else {
      setDisliked(true)
      setDislikes(dislikes + 1)
      if (liked) {
        setLiked(false)
        setLikes(likes - 1)
      }
    }
  }
  return (
    <>
      <ButtonGroup className="mb-2">
        <span>
          <ToggleButton
            id="toggle-likes"
            style={{
              backgroundColor: 'transparent',
              border: 'none',
              paddingRight: 1,
              position: 'relative',
              top: -6,
            }}
            type="checkbox"
            checked={liked}
            value="1"
            onChange={() => handleLike()}
          >
            <FaThumbsUp color="#b3ee74" />
          </ToggleButton>
          {likes}
        </span>
      </ButtonGroup>
      <ButtonGroup className="mb-2">
        <span>
          <ToggleButton
            id="toggle-dislikes"
            style={{
              backgroundColor: 'transparent',
              border: 'none',
              paddingRight: 1,
              position: 'relative',
              top: -1,
            }}
            type="checkbox"
            variant="secondary"
            checked={disliked}
            value="1"
            onChange={() => handleDislike()}
          >
            <FaThumbsDown color="#b3ee74" />
          </ToggleButton>
          {dislikes}
        </span>
      </ButtonGroup>
    </>
  )
}

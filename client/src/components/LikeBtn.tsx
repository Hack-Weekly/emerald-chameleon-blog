import { useState } from 'react'
import ButtonGroup from 'react-bootstrap/ButtonGroup'
import ToggleButton from 'react-bootstrap/ToggleButton'

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
        <ToggleButton
          id="toggle-likes"
          type="checkbox"
          variant="primary"
          checked={liked}
          value="1"
          onChange={() => handleLike()}
        >
          {likes}
        </ToggleButton>
      </ButtonGroup>
      <ButtonGroup className="mb-2">
        <ToggleButton
          id="toggle-dislikes"
          type="checkbox"
          variant="secondary"
          checked={disliked}
          value="1"
          onChange={() => handleDislike()}
        >
          {dislikes}
        </ToggleButton>
      </ButtonGroup>
    </>
  )
}

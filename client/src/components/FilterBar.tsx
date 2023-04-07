import React from 'react'

type Props = {}

const FilterBar = (props: Props) => {


    const handleClick = () => {
        // render cards in grid based on what button was clicked
    }

  return (
    <div className='mt-4 p-4 d-flex align-center'>
        <span className="fs-5 me-4">Filter by: </span>
        <button 
            type="button" 
            className="btn me-3 py-0 px-3 border-0 btn-secondary text-light rounded"
            onClick={handleClick}
        >Tags
        </button>
        <button 
            type="button" 
            className="btn me-3 py-0 px-3 border-0 btn-secondary text-light rounded"
            onClick={handleClick}
        >Author
        </button>
        <button 
            type="button" 
            className="btn me-3 py-0 px-3 border-0 btn-secondary text-light rounded"
            onClick={handleClick}
        >Date
        </button>
        
    </div>
    
  )
}

export default FilterBar
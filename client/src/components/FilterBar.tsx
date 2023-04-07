import React from 'react'

type Props = {}

const FilterBar = (props: Props) => {


    const handleClick = () => {
        // render cards in grid based on what button was clicked
    }

  return (
    <div className='mt-4 p-4'>
        <span className="fs-6 d-block mb-2">Filter by: </span>
        <button 
            type="button" 
            className="btn me-2 py-1 px-3 border-0 btn-secondary text-light rounded d-inline-block"
            onClick={handleClick}
        >Tags
        </button>
        <button 
            type="button" 
            className="btn me-2 py-1 px-3 border-0 btn-secondary text-light rounded d-inline-block"
            onClick={handleClick}
        >Author
        </button>
        <button 
            type="button" 
            className="btn me-2 py-1 px-3 border-0 btn-secondary text-light rounded d-inline-block"
            onClick={handleClick}
        >Date
        </button>
        
    </div>
    
  )
}

export default FilterBar
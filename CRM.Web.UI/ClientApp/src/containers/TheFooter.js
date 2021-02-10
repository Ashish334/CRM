import React from 'react'
import { CFooter } from '@coreui/react'

const TheFooter = () => {
  return (
    <CFooter fixed={false}>
      <div>
        
        <span className="ml-1">&copy; 2020 Bharuwa Solutions.</span>
      </div>
      <div className="mfs-auto">
        <span className="mr-1">Powered by</span>
        <a href="http://www.bharuwasolution.com/" target="_blank" rel="noopener noreferrer">Bharuwa Solutions Pvt. Ltd.</a>
      </div>
    </CFooter>
  )
}

export default React.memo(TheFooter)

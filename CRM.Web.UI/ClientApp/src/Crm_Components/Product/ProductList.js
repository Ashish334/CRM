import React, { useState, useEffect } from "react";
import { Link } from 'react-router-dom';
import CIcon from '@coreui/icons-react';
import view from '../../Images/Detailicon.png';
import edit from '../../Images/edit.png';
import {
  CCardHeader, CCard,
  CCardBody, CCol,
  CDataTable, CBadge,  CButton, CRow //CCollapse,
} from '@coreui/react';


const ProductList = () => {


  const fields = [
    { key: 'name', _style: { width: '20%' } },
    { key: 'price', _style: { width: '20%' } },
    { key: 'gst_%', _style: { width: '20%' } },
    { key: 'hsnCode', _style: { width: '20%' } },
    { key: 'status', _style: { width: '20%' } },
    { key: 'edit', _style: { width: '20%' } },
    { key: 'view', _style: { width: '20%' } },
    // {
    //   key: 'show_details',
    //   label: '',
    //   _style: { width: '1%' },
    //   sorter: false,
    //   filter: false
    // }
  ]
  const getBadge = (status) => {
    switch (status) {
      case '0': return 'success'
      case '1': return 'danger'
      default:
    }
  };

  //const [details, setDetails] = useState([])
  // const [items, setItems] = useState(usersData)

  // const toggleDetails = (index) => {
  //   const position = details.indexOf(index)
  //   let newDetails = details.slice()
  //   if (position !== -1) {
  //     newDetails.splice(position, 1)
  //   } else {
  //     newDetails = [...details, index]
  //   }
  //   setDetails(newDetails)
  // }
  const [data, setData] = useState([]);

  useEffect(() => {
    var bearer = 'Bearer ' + localStorage.getItem("token");
    fetch("http://localhost:65150/api/Product/getall",
      {
        method: "GET",
        headers: {
          'Authorization': bearer,
          'Accept': 'application/json',
          'Content-Type': 'application/json',
        },
      })

      .then(res => res.json())
      .then(
        (data) => { setData(data) },
        (error) => {console.log('error', error);}
    );
  }, [])

  //     deleteItem(id)
  // {
  //     fetch('http://localhost:52081/api/userdel/'+id)
  //     alert("User Delete Successfully");
  //     this.getData();

  // }

  return (
    <CRow>
      <CCol xs="12" sm="12">
        <CCard>
          <CCardHeader>
            Product Master
              <small> List</small>

            <Link to="/ProductCreation" className="float-right"><CIcon name="cil-user-follow" /></Link>

          </CCardHeader>
          <CCardBody>
            <CDataTable
              items={data}
              fields={fields}
              columnFilter
              tableFilter
              footer
              itemsPerPageSelect
              itemsPerPage={5}
              hover
              sorter
              pagination
              scopedSlots={{

                 'gst_%':(item)=>(<td>{item.gst}</td>),

                'status':
                  (item) => (
                    <td>
                      <CBadge color={getBadge(item.status)}>
                        {item.status === '0' ? "Active" : item.status === '1' ? "Inactive" :null}

                      </CBadge>
                    </td>

                  ),
                  
                  'edit': (item) => (
                    <td>
                      <Link to={`/ProductUpdate/${item.id}`} > <CButton
                              class="btn btn-outline-primary btn-sm">
                             <img src={edit} alt="view" height="25" width="20"/>
                          </CButton></Link>
                    </td>
                  ),
  
                  'view': (item) => (
                    <td>
                      <Link to={`/ProductDetails/${item.id}`} ><CButton className="ml-3"
                            class="btn btn-outline-warning btn-sm">
                            <img src={view} alt="view" height="25" width="20"/>
                          </CButton></Link>
                    </td>),

                // 'show_details':
                //   (item, index) => {
                //     return (
                //       <td className="py-2">
                //         <CButton
                //           color="primary"
                //           variant="outline"
                //           shape="square"
                //           size="sm"
                //           onClick={() => { toggleDetails(index) }}
                //         >
                //           {details.includes(index) ? 'Hide' : 'Show'}
                //         </CButton>
                //       </td>
                //     )
                //   },
                // 'details':
                //   (item, index) => {
                //     return (
                //       <CCollapse show={details.includes(index)}>
                //         <CCardBody>
                //           <h4>
                //             {item.username}
                //           </h4>
                //           <p className="text-muted">Product Action: </p>
                //           <Link to={`/ProductUpdate/${item.id}`} > <CButton
                //             variant="outline"
                //             shape="square"
                //             size="sm"
                //             color="warning">
                //             <p><CIcon name="cil-pencil" /><br />Edit</p>
                //           </CButton></Link>

                //           <Link to={`/ProductDetails/${item.id}`} ><CButton className="ml-3"
                //             variant="outline"
                //             shape="square"
                //             size="sm"
                //             color="success">
                //             <p><CIcon name="cil-chevron-right" /><br />View</p>
                //           </CButton></Link>
                //         </CCardBody>
                //       </CCollapse>
                //     )
                //   }
              }}
            />
          </CCardBody>
        </CCard>
      </CCol>
    </CRow>
  )

}

export default ProductList;
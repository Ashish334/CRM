import React, { useState, useEffect } from "react";
import { Link } from 'react-router-dom';
import CIcon from '@coreui/icons-react';
import view from '../../Images/Detailicon.png';
import edit from '../../Images/edit.png';
import {
    CCard,
    CCardBody,
    CCardHeader,
    CCol,CDataTable,
    CRow,CButton//,CCollapse,
    ,CBadge
} from '@coreui/react';


// GET request function to your  API

const CustomerVsProductList =()=> {

  var bearer = 'Bearer ' + localStorage.getItem("token");
    const fields = [
        { key: 'customerName', _style: { width: '20%' } },
        { key: 'productName', _style: { width: '20%' } },
        { key: 'price', _style: { width: '20%' } },
        { key: 'qty', _style: { width: '20%' } },
        { key: 'discountAmt', _style: { width: '20%' } },
        { key: 'netamt', _style: { width: '20%' } },
        { key: 'edit', _style: { width: '20%' } },
        { key: 'view', _style: { width: '20%' } },
        
      ]
     
      const [data, setData] = useState([]);
    
      useEffect(() => {
        var bearer = 'Bearer ' + localStorage.getItem("token");
        fetch("http://localhost:65150/api/customervsproduct/getall",
          {
            method: "GET",
            headers: {
              'Authorization': bearer,
              'Accept': 'application/json',
              'Content-Type': 'application/json',
            },
          })
    
          .then(res => res.json())
          .then(data => {setData(data)},
               (error) => {console.log('error', error)}
          );
          
      }, [])
     
      // Get customer Intrusted Product..........................................

const [instprod, setInstprod] = useState([]);
useEffect(() => {
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
            (data) => { setInstprod(data) 
               
           },
            (error) => { console.log('error', error); }
        );
}, []) // eslint-disable-line react-hooks/exhaustive-deps

      localStorage.setItem('Cust_Product', JSON.stringify(instprod));

     
      var Cust_Prod = JSON.parse(localStorage.getItem('Cust_Product'));
        return (
            <CRow>
              <CCol xs="12" sm="12">
                <CCard>
                  <CCardHeader>
                  Customer vs Product
                      <small> List</small>
        
                    <Link to="/customervsproduct" className="float-right"><CIcon name="cil-user-follow" /></Link>
        
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

                        'productName':
                          (item) => (
                            <td>
                              <CBadge>
                                {Cust_Prod.map((p)=>(p.id)===parseInt(item.productName) ? p.name :null)}
                               </CBadge>
                            </td>
        
                          ),
                      
                        'edit': (item) => (
                          <td>
                            <Link to={`/CustomerVsProductUpdate/${item.customerId}`} > <CButton
                                    class="btn btn-outline-primary btn-sm">
                                       <img src={edit} alt="view" height="25" width="20"/> 
                                   </CButton></Link>
                          </td>
                        ),
        
                        'view': (item) => (
                          <td>
                           <Link to={`/CustomerVsProductDetails/${item.customerId}`} ><CButton className="ml-3"
                                    class="btn btn-outline-warning btn-sm">
                                     <img src={view} alt="view" height="25" width="20"/> 
                                    </CButton></Link>
                          </td>),

                       
                      }}
                    />
                  </CCardBody>
                </CCard>
              </CCol>
            </CRow>
          )
    }


export default CustomerVsProductList;
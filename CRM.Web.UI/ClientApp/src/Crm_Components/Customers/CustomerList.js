import React, { useState, useEffect } from "react";
import { Link } from 'react-router-dom';
import CIcon from '@coreui/icons-react';
import view from '../../Images/Detailicon.png';
import edit from '../../Images/edit.png';
import {Custstatus} from '../../GlobalConfigFile';
import {
    CCard,
    CCardBody,
    CCardHeader,
    CCol,CDataTable,
    CRow,CButton//,CCollapse,
    ,CBadge
} from '@coreui/react';


// GET request function to your  API

const CustomerList =()=> {

  var bearer = 'Bearer ' + localStorage.getItem("token");
    const fields = [
        { key: 'name', _style: { width: '20%' } },
        { key: 'mobile', _style: { width: '20%' } },
        { key: 'interestedProduct', _style: { width: '20%' } },
        { key: 'domain', _style: { width: '20%' } },
        { key: 'shopName', _style: { width: '20%' } },
        { key: 'status', _style: { width: '20%' } },
        { key: 'edit', _style: { width: '20%' } },
        { key: 'view', _style: { width: '20%' } },
        
      ]
     
      const [data, setData] = useState([]);
    
      useEffect(() => {
        var bearer = 'Bearer ' + localStorage.getItem("token");
        fetch("http://localhost:65150/api/customer/getall",
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
      const getBadge = (status) => {
        switch (status) {
          
          case 1: return 'success'
          case 2: return 'primary'
          case 3: return 'warning'
          default: return 'primary'
        }
      }
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
                    Customer Master
                      <small> List</small>
        
                    <Link to="/CustomerCreation" className="float-right"><CIcon name="cil-user-follow" /></Link>
        
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

                        'interestedProduct':
                          (item) => (
                            <td>
                              <CBadge>
                                {Cust_Prod.map((p)=>(p.id)===(item.interestedProduct) ? p.name :null)}
                               </CBadge>
                            </td>
        
                          ),
                        'status':
                          (item) => (
                            <td>
                              <CBadge color={getBadge(item.status)}>
                                {Custstatus.map((s)=>(s.id)===(item.status) ? s.name :null)}
                               </CBadge>
                            </td>
        
                          ),
                        'edit': (item) => (
                          <td>
                            <Link to={`/CustomerUpdate/${item.id}`} > <CButton
                                    class="btn btn-outline-primary btn-sm">
                                       <img src={edit} alt="view" height="25" width="20"/> 
                                   </CButton></Link>
                          </td>
                        ),
        
                        'view': (item) => (
                          <td>
                           <Link to={`/CustomerDetails/${item.id}`} ><CButton className="ml-3"
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


export default CustomerList;
import React, { useState, useEffect } from "react";
import {

  CCard,
  CCardBody,

  CCardHeader,
  CCol,
  CRow
} from '@coreui/react'

const ProductDetails = (props) => {

  const [data, setData] = useState([]);

  useEffect(() => {
    var bearer = 'Bearer ' + localStorage.getItem("token");

    fetch("http://localhost:65150/api/ProductDetails/" + props.match.params.id,
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
  }, []) // eslint-disable-line react-hooks/exhaustive-deps

  return (
    <CRow>
      <CCol xs="12" sm="12">
        <CCard>
          <CCardHeader>
            Product Master
              <small> Details</small>
          </CCardHeader>
          <form >
            <CCardBody>
              <div class="row" >
                <div class="col">
                  <label>Product Id :   {data?.id}</label>
                </div>
              </div>
              <div class="row" >

                <div class="col">
                  <label>Product Name : {data?.name}</label>
                </div>

                <div class="col">
                  <label>Status :  {data?.status === '0' ? "Active" : data?.status === '1' ? "Inactive" : null} </label>
               
                </div>

              </div>



              <div class="row" >
              <div class="col">
                  <label>Price : {data?.price}</label>
                </div>
                <div class="col">
                  <label>GST% :   {data?.gst}</label>
                </div>
               

              </div>
              <div class="row" >


              </div>
              <div class="row" >
                <div class="col">
                  <label>HSNCODE : {data?.hsnCode}</label>
                </div>
             </div>

            </CCardBody>
          </form>
        </CCard>
      </CCol>
    </CRow>
  );
}



export default ProductDetails;

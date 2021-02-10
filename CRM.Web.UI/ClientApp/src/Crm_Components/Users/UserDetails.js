import React, { useState, useEffect } from "react";
import dateFormat from 'dateformat';
import {

  CCard,
  CCardBody,

  CCardHeader,
  CCol,
  CRow
} from '@coreui/react'

const UserDetails = (props) => {

  const [data, setData] = useState([]);

  useEffect(() => {
    var bearer = 'Bearer ' + localStorage.getItem("token");

    fetch("http://localhost:65150/api/users/" + props.match.params.id,
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
            User Master
              <small> Details</small>
          </CCardHeader>
          <form >
            <CCardBody>
              <div class="row" >
                <div class="col">
                  <label>User Id :   {data?.id}</label>
                </div>
              </div>
              <div class="row" >

                <div class="col">
                  <label>First Name : {data?.firstName}</label>
                </div>

                <div class="col">
                  <label>Last Name : {data?.lastName}</label>
                </div>

              </div>



              <div class="row" >
                <div class="col">
                  <label>Email-Id :   {data?.email}</label>
                </div>
                <div class="col">
                  <label>Role : {data?.role}</label>
                </div>

              </div>
              <div class="row" >


              </div>
              <div class="row" >
                <div class="col">
                  <label>Mobile Number : {data?.mobileNumber}</label>
                </div>

                <div class="col">
                  <label>Status :  {data?.status === 0 ? "Active" : data?.status === 1 ? "Inactive" : data?.status === 2 ? "Blocked" : null} </label>


                </div>

              </div>
              <div class="row" >
                <div class="col">
                <label>Created Date & Time :   {dateFormat(data?.createdDateTimeUtc)}</label>
                </div>

                <div class="col">
                <label>Updated Date & Time :    {dateFormat(data?.updatedDateTimeUtc)} </label>


                </div>

              </div>

            </CCardBody>
          </form>
        </CCard>
      </CCol>
    </CRow>
  );
}



export default UserDetails;

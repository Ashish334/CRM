import React, { useState,useEffect } from "react";
import { useHistory } from "react-router-dom";
import CIcon from '@coreui/icons-react';
//import { withRouter } from "react-router";
import {
    CButton,
    CCard,
    CCardBody,
    CCardFooter,
    CCardHeader,
    CCol,
    CRow
  } from '@coreui/react'


const UserCreation =()=> {

  
    var history = useHistory();
    var bearer = 'Bearer ' + localStorage.getItem("token");
   const handleSubmit = (e) => {
        e.preventDefault();
        const FirstName= e.target.fname.value;
        const LastName=e.target.lname.value;
        const EmailId = e.target.email.value;
        const Password = e.target.password.value;
        const Roles=e.target.Roles.value;
        const MobileNumber=e.target.mobile.value;
        const Status=e.target.status.value;
    
        var requestBody = JSON.stringify({
            'FirstName':FirstName,
            'LastName':LastName,
            'Email':EmailId,
            'Password':Password,
            'MobileNumber':MobileNumber,
            'Roles':[Roles],
            'Status':Status
        });

        var statusCode=0;
        fetch('http://localhost:65150/api/users/create', {
            method: 'POST',
            headers: 
            { 
                'Authorization': bearer,
                'Accept': 'application/json',
                'Content-Type': 'application/json', },
            body:requestBody
          })


          
          .then(response => {
            statusCode = response.status;
            return response})

        .then(
              (data) => {
                if(statusCode === 200){
                alert("User Created Successfully")
                console.log('Success', data);
               history.push('/userlist')
              }
              else{
                alert("You have wrong entered")
                
              }
              },
              (error) => {console.log('error', error);
               
              }
            );
    }
  // Get Role..........................................
      const [data, setData] = useState([]);
      useEffect(() => {
      fetch("http://localhost:65150/api/users/getrole",
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
              User Creation
              <small> Form</small>
            </CCardHeader>
            <form onSubmit={handleSubmit} >
            <CCardBody>
             
                    <div class="row mt-2" >
                        <div class="col">
                            <label>First Name<span>*</span></label>
                            <input type="text" required className="form-control" Name="fname" id="fname" />
                            
                        </div>
                        <div class="col">
                        <label>Last name</label>
                            <input type="text" class="form-control" Name="lname" id="lname"  />
                        </div>
                    </div>

                    <div class="row mt-2">

                        <div class="col">
                        <label>Email Id<span>*</span></label>
                            <input type="email" required className="form-control" Name="email" id="email" />
                        </div>
                        <div class="col">
                        <label>Password <span>*</span></label>
                            <input type="password" required  className="form-control" Name="password" id="password"/>
                        </div>
                    </div>
                    <div class="row mt-2">
                    <div class="col">
                        <label>Role<span>*</span></label>
                            <select class="form-control" required  id="Roles" name="Roles" >
                            <option >Please select</option>
                           {data.map(d=><option >
                             {d.name}</option>)}   
                            </select>
                        </div>
                        <div class="col">
                        <label>Mobile No.</label>
                            <input type="number" class="form-control" id="mobile" name="mobile"   />
                        </div>
                      
                    </div>
                    <div class="row mt-2">
                       
                        
                        <div class="col">
                        <label>Status<span>*</span></label>
                        <select class="form-control" required id="status" name="status">
                                <option >Please select</option>
                                <option value='0' >Active</option>
                                <option  value='1'>InActive</option>
                                <option  value='2'>Blocked</option>
                            
                                
                            </select>
                        </div>
                        <div class="col">
                        </div>
                    </div>
                   
                  
               

            </CCardBody>
            <CCardFooter>
              <CButton  type="submit" size="sm" color="primary"><CIcon name="cil-scrubber" /> Submit</CButton>
          
              <CButton className ="ml-3" type="reset" size="sm" color="danger"><CIcon name="cil-ban" /> Reset</CButton>
            </CCardFooter>
            </form>
          </CCard>
        </CCol>          
        </CRow>
        );
        }



export default UserCreation;

import React, { useState, useEffect } from "react";
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


const UserUpdate = (props) => {
    var history = useHistory();
    const handleSubmit = (e) => {
        e.preventDefault();
        const FirstName = e.target.fname.value;
        const LastName = e.target.lname.value;
        const EmailId = e.target.email.value;
        const Roles = e.target.Roles.value;
        const MobileNumber = e.target.mobile.value;
        const Status = e.target.status.value;

        var requestBody = JSON.stringify({
            'FirstName': FirstName,
            'LastName': LastName,
            'Email': EmailId,
            'MobileNumber': MobileNumber,
            'Roles': [Roles],
            'id': data.id,
            'Status': Status
        });

        var bearer = 'Bearer ' + localStorage.getItem("token");
        var statusCode = 0;
        fetch('http://localhost:65150/api/users/update', {
            method: 'POST',
            headers:
            {
                'Authorization': bearer,
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: requestBody
        })
            .then(response => {
                statusCode = response.status;
                return response
            })

            .then(
                (data) => {
                    if (statusCode === 200) {
                        alert("User Updated Successfully")
                        console.log('Success', data);
                        history.push('/userlist')
                    }
                    else {
                        alert("You have wrong entered")

                    }
                },
                (error) => {
                    console.log('error', error);

                }
            );
    }
    const [data, setData] = useState([]);
    var bearer = 'Bearer ' + localStorage.getItem("token");

    useEffect(() => {
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
                (error) => { console.log('error', error); }
            );
    }, []) // eslint-disable-line react-hooks/exhaustive-deps

    // Get Role..........................................
    const [role, setRole] = useState([]);
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
                (role) => { setRole(role) },
                (error) => { console.log('error', error); }
            );
    }, []) // eslint-disable-line react-hooks/exhaustive-deps
    return (


        <CRow>
            <CCol xs="12" sm="12">
                <CCard>
                    <CCardHeader>
                        User Updation
              <small> Form</small>
                    </CCardHeader>
                    <form onSubmit={handleSubmit} >
                        <CCardBody>

                            <div class="row mt-2" >
                                <div class="col">
                                    <label>First Name</label>
                                    <input type="text" className="form-control" defaultValue={data?.firstName} Name="fname" id="fname" />

                                </div>
                                <div class="col">
                                    <label>Last name</label>
                                    <input type="text" class="form-control" defaultValue={data?.lastName} Name="lname" id="lname" />
                                </div>
                            </div>

                            <div class="row mt-2">
                                <div class="col">
                                    <label>Role</label>
                                    <select class="form-control" id="Roles" name="Roles" value={data?.role}>
                                        <option >Please select</option>
                                        {role.map(d => <option >
                                            {d.name}</option>)}
                                    </select>
                                </div>
                                <div class="col">
                                    <label>Mobile No.</label>
                                    <input type="number" class="form-control" defaultValue={data?.mobileNumber} id="mobile" name="mobile" />
                                </div>

                            </div>
                            <div class="row mt-2">


                                <div class="col">
                                    <label>Status</label>
                                    <select class="form-control" value={data?.status} id="status" name="status">
                                        <option >Please select</option>
                                        <option value='0' >Active</option>
                                        <option value='1'>InActive</option>
                                        <option value='2'>Blocked</option>


                                    </select>
                                </div>


                                <div class="col">
                                    <label>Email Id</label>
                                    <input type="email" disabled className="form-control" defaultValue={data?.email} Name="email" id="email" />
                                </div>

                            </div>





                        </CCardBody>
                        <CCardFooter>
                            <CButton type="submit" size="sm" color="primary"><CIcon name="cil-scrubber" /> Update</CButton>

                            <CButton className="ml-3" type="reset" size="sm" color="danger"><CIcon name="cil-ban" /> Reset</CButton>
                        </CCardFooter>
                    </form>
                </CCard>
            </CCol>
        </CRow>
    );
}



export default UserUpdate;

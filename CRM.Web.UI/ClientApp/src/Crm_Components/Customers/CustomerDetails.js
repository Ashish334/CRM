import React, { useState, useEffect } from "react";
import {

    CCard,
    CCardBody,
    CCardHeader,
    CCol,
    CRow
} from '@coreui/react';
import {Custstatus,CustLeadType,Cust_BusinessType} from '../../GlobalConfigFile';

const CustomerDetails = (props) => {

    const [data, setData] = useState([]);

    useEffect(() => {
        var bearer = 'Bearer ' + localStorage.getItem("token");

        fetch("http://localhost:65150/api/customer/" + props.match.params.id,
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

    
    var Cust_Prod = JSON.parse(localStorage.getItem('Cust_Product'));

    return (


        <CRow>
            <CCol xs="12" sm="12">
                <CCard>
                    <CCardHeader>
                        Customer Details
          <small> Form</small>
                    </CCardHeader>
                    <form>
                        <CCardBody>

                            <div class="row" >
                                <div class="col">
                                    <label>Name:  {data?.name}</label>
                                </div>

                                <div class="col">
                                    <label>Domain: {data?.domain}</label>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Mobile Number: {data?.mobile}</label>

                                </div>
                                <div class="col">
                                    <label>Email Id: {data?.email}</label>
                                </div>
                            </div>

                            <div class="row" >
                                <div class="col">
                                    <label>Shop Name: {data?.shopName}</label>
                                </div>

                                <div class="col">
                                    <label>Address-1: {data?.address1}</label>

                                </div>
                            </div>

                            <div class="row" >
                                <div class="col">
                                    <label>Address-2: {data?.address2}</label>

                                </div>
                                <div class="col">
                                    <label>Address-3: {data?.address3}</label>

                                </div>
                            </div>

                            <div class="row">

                                <div class="col">
                                    <label>District: {data?.district}</label>

                                </div>
                                <div class="col">
                                    <label>City: {data?.city}</label>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>State: {data?.state}</label>

                                </div>
                                <div class="col">
                                    <label>Pin Code: {data?.pinCode}</label>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Status: {Custstatus.map((s)=>(s.id)===(data.status) ? s.name :null)}</label>
                                    
                                </div>
                                <div class="col">
                                    <label>Interested Product: {Cust_Prod.map((p)=>(p.id)===(data.interestedProduct) ? p.name :null)} </label>
                                   
                                </div>
                            </div>



                            <div class="row">
                                <div class="col">
                                    <label>Lead Type: {CustLeadType.map((l)=>(l.id)===(data.leadType) ? l.name :null)}</label>
                               </div>

                                <div class="col" id="refname">
                                    <label>Reference Name: {data?.referenceName}</label>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label>Business Type:  {Cust_BusinessType.map((b)=>(b.id)===(data.businessType) ? b.name :null)}</label>
                                   
                                </div>
                            </div>
                        </CCardBody>

                    </form>
                </CCard>
            </CCol>
        </CRow>
    );
}



export default CustomerDetails;

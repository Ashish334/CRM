import React, { useState, useEffect } from "react";
import {

    CCard,
    CCardBody,
    CCardHeader,
    CCol,
    CRow
} from '@coreui/react';


const CustomerVsProductDetails = (props) => {

    const [data, setData] = useState([]);

    useEffect(() => {
        var bearer = 'Bearer ' + localStorage.getItem("token");

        fetch("http://localhost:65150/api/customervsproduct/" + props.match.params.id,
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

                        <div class="row " >
                            <div class="col">

                            </div>
                            <div class="col">
                                <label>Customer Id:  {data.map((d, i) => i === 0 ? d.customerId : null)}</label>

                            </div>

                            <div class="col">
                                <label>Customer Name:  {data.map((d, i) => i === 0 ? d.customerName : null)}</label>
                            </div>
                            <div class="col">

                            </div>
                        </div>

                        {data.map(d => {
                            return <CCardBody>


                                <div class="row" >
                                    <div class="col-1">
                                        <label>S.No: {d.indexId}</label>

                                    </div>

                                    <div class="col">
                                        <label>Product Id: {d.id}</label>

                                    </div>

                                    <div class="col-4">
                                        <label>Product Name:{'  '}

                                            {Cust_Prod.map((p) => (p.id) === parseInt(d.productName) ? p.name : null)}

                                        </label>

                                    </div>
                                    <div class="col">
                                        <label>Price: {d.price}</label>
                                    </div>
                                    <div class="col">
                                        <label>Qty: {d.qty}</label>
                                    </div>
                                    <div class="col">
                                        <label>Disc %: {d.discountPer}</label>

                                    </div>

                                </div>

                                <div class="row" >
                                    <div class="col-1">
                                        <label></label>

                                    </div>



                                    <div class="col">
                                        <label>Disc Amt: {d.discountAmt}</label>

                                    </div>
                                    <div class="col">
                                        <label>GST%: {d.gstPer}</label>

                                    </div>

                                    <div class="col">
                                        <label>GST Amt: {d.gstAmt}</label>

                                    </div>
                                    <div class="col">
                                        <label>Net Amt: {d.netamt}</label>

                                    </div>
                                </div>


                            </CCardBody>

                        })}
                    </form>
                </CCard>
            </CCol>
        </CRow>
    );
}



export default CustomerVsProductDetails;

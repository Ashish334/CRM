import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import CIcon from '@coreui/icons-react';
import {Prd_gstper} from '../../GlobalConfigFile';
import {
    CButton,
    CCard,
    CCardBody,
    CCardFooter,
    CCardHeader,
    CCol,
    CRow
} from '@coreui/react'


const ProductUpdate = (props) => {
    var history = useHistory();
    const handleSubmit = (e) => {
        e.preventDefault();
        const id=props.match.params.id;
        const Name= e.target.name.value;
        const Status=e.target.status.value;
        const Price = e.target.price.value;
        const GST = e.target.gst.value;
        const HSNCODE=e.target.hsncode.value;

        var requestBody = JSON.stringify({
            'ID':id,
            'Name':Name,
            'Status':Status,
            'Price':parseInt(Price),
            'GST':GST,
            'HSNCODE':HSNCODE
        });

        var bearer = 'Bearer ' + localStorage.getItem("token");
        var statusCode = 0;
        fetch('http://localhost:65150/api/product/update', {
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
                        alert("Product Updated Successfully")
                        console.log('Success', data);
                        history.push('/productlist')
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
                (error) => { console.log('error', error); }
            );
    }, []) // eslint-disable-line react-hooks/exhaustive-deps

    
    return (


        <CRow>
            <CCol xs="12" sm="12">
                <CCard>
                    <CCardHeader>
                        Product Updation
              <small> Form</small>
                    </CCardHeader>
                    <form onSubmit={handleSubmit} >
                        <CCardBody>

                    
                            <div class="row mt-2" >
                        <div class="col">
                            <label>Product Name<span> </span></label>
                            <input type="text"  className="form-control" defaultValue={data?.name} Name="name" id="name" />
                            
                        </div>
                        <div class="col">
                        <label>Product Status</label>
                            <select class="form-control"  id="status" value={data?.status} name="status">
                                <option>Select...</option>
                                <option value='0'>Active</option>
                                <option value='1'>InActive</option>
                            </select>
                        </div>
                    </div>

                    <div class="row mt-2">

                        <div class="col">
                        <label>Price</label>
                            <input type="number"  className="form-control" defaultValue={data?.price} Name="price" id="price" />
                        </div>
                        <div class="col">
                        <label>GST%</label>
                           
                             <select class="form-control"  value={data?.gst} id="gst" name="gst">
                            <option >Please select</option>
                            {Prd_gstper.map(p=><option value={p.id}>{p.name}</option>)}
                            </select>
                        </div>
                    </div>
                    <div class="row mt-2">
                    <div class="col-6">
                        <label>HSNCODE</label>
                        <input type="text"   className="form-control" defaultValue={data?.hsnCode} Name="hsncode" id="hsncode"/>
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



export default ProductUpdate;

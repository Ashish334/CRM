import React from "react";
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


const ProductCreation =()=> {

  
    var history = useHistory();
    var bearer = 'Bearer ' + localStorage.getItem("token");
   const handleSubmit = (e) => {
        e.preventDefault();
        const Name= e.target.name.value;
        const Status=e.target.status.value;
        const Price = e.target.price.value;
        const GST = e.target.gst.value;
        const HSNCODE=e.target.hsncode.value;

         var requestBody = JSON.stringify({
            'Name':Name,
            'Status':Status,
            'Price':parseInt(Price),
            'GST':GST,
            'HSNCODE':HSNCODE
            
        });

        var statusCode=0;
        fetch('http://localhost:65150/api/product/create', {
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
                alert("Product Created Successfully")
                console.log('Success', data);
               history.push('/productlist')
              }
              else{
                alert("You have wrong entered")
                
              }
              },
              (error) => {console.log('error', error);
               
              }
            );
    }
   
        return (
            
         
         <CRow>
        <CCol xs="12" sm="12">
          <CCard>
            <CCardHeader>
              Product Creation
              <small> Form</small>
            </CCardHeader>
            <form onSubmit={handleSubmit} >
            <CCardBody>
             
                    <div class="row mt-2" >
                        <div class="col">
                            <label>Product Name<span> *</span></label>
                            <input type="text" required className="form-control" Name="name" id="name" />
                            
                        </div>
                        <div class="col">
                        <label>Product Status<span> *</span></label>
                            <select class="form-control" required id="status" name="status">
                                <option>Select...</option>
                                <option value='0'>Active</option>
                                <option value='1'>InActive</option>
                            </select>
                        </div>
                    </div>

                    <div class="row mt-2">

                        <div class="col">
                        <label>Price<span> *</span></label>
                            <input type="number" required className="form-control" Name="price" id="price" />
                        </div>
                        <div class="col">
                        <label>GST%<span> *</span></label>
                           
                            <select class="form-control" required id="gst" name="gst">
                            <option >Please select</option>
                            {Prd_gstper.map(p=><option value={p.id}>{p.name}</option>)}
                            </select>
                        </div>
                    </div>
                    <div class="row mt-2">
                    <div class="col-6">
                        <label>HSNCODE<span> *</span></label>
                        <input type="text" required  className="form-control" Name="hsncode" id="hsncode"/>
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



export default ProductCreation;

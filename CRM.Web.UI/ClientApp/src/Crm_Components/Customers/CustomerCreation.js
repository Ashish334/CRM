import React,{useState,useEffect} from "react";
import { useHistory } from "react-router-dom";
import CIcon from '@coreui/icons-react';
import { withRouter } from "react-router";
import {Custstatus,CustLeadType,Cust_BusinessType} from '../../GlobalConfigFile';
import {
    CButton,
    CCard,
    CCardBody,
    CCardFooter,
    CCardHeader,
    CCol,
    CRow
} from '@coreui/react'
//import { id } from "date-fns/locale";


const CustomerCreation = () => {

    var history = useHistory();
    var bearer = 'Bearer ' + localStorage.getItem("token");
    
    // insert customer data..........................................

    const handleSubmit = (e) => {
        e.preventDefault();
        const Name = e.target.cname.value;
        const Domain = e.target.domain.value;
        const Email = e.target.email.value;
        const ShopName = e.target.shopname.value;
        const Mobile = e.target.mobileno.value;
        const Address1 = e.target.address1.value;
        const Address2 = e.target.address2.value;
        const Address3 = e.target.address3.value;
        const District = e.target.district.value;
        const City = e.target.city.value;
        const State = e.target.state.value;
        const PinCode = e.target.pincode.value;
        const Status = parseInt(e.target.status.value);
        const InterestedProduct = parseInt(e.target.prointerested.value);
        const ReferenceName = e.target.refname.value;
        const LeadType = parseInt(e.target.leadtype.value);
        const BusinessType = parseInt(e.target.businesstype.value);

        var requestBody = JSON.stringify({
            'Name': Name,
            'Domain': Domain,
            'Email': Email,
            'ShopName': ShopName,
            'Mobile': Mobile,
            'Address1': Address1,
            'Address2': Address2,
            'Address3': Address3,
            'District': District,
            'City': City,
            'State': State,
            'PinCode': PinCode,
            'Status': Status,
            'InterestedProduct':InterestedProduct,
            'ReferenceName': ReferenceName,
            'LeadType': LeadType,
            'BusinessType': BusinessType
        });
        var statusCode = 0;
        fetch('http://localhost:65150/api/customer/create', {
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
                        alert("Customer Created Successfully")
                        console.log('Success', data);
                        history.push('/CustomerList')
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
            (instprod) => { setInstprod(instprod) 
               
           },
            (error) => { console.log('error', error); }
        );
}, []) // eslint-disable-line react-hooks/exhaustive-deps

localStorage.setItem('Cust_Product', JSON.stringify(instprod));


    const CheckLeadType = (e) => {
        console.log(e)
        if (e.target.value !== '1')
            document.getElementById('refname').style.display = 'none';
        else
            document.getElementById('refname').style.display = 'block';
    }


    var Cust_Product = JSON.parse(localStorage.getItem('Cust_Product'));
    
    return (

        <CRow>
            

            <CCol xs="12" sm="12">
                <CCard>
                    <CCardHeader>
                        Customer Creation
              <small> Form</small>
                    </CCardHeader>
                    <form onSubmit={handleSubmit} >
                        <CCardBody>

                            <div class="row mt-4" >
                                <div class="col">
                                    <label>Name</label>
                                    <input type="text" className="form-control" Name="cname" id="cname" />

                                </div>

                                <div class="col">
                                    <label>Domain</label>
                                    <input type="text" class="form-control" Name="domain" id="domain" />
                                </div>
                                 <div class="col">
                                    <label>Email Id</label>
                                    <input type="email" className="form-control" Name="email" id="email" />
                                </div>
                                <div class="col">
                                    <label>Shop Name</label>
                                    <input type="text" className="form-control" Name="shopname" id="shopname" />

                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col">
                                    <label>Mobile Number</label>
                                    <input type="number" className="form-control" Name="mobileno" id="mobileno" />
                                </div>


                                <div class="col">
                                    <label>Address-1</label>
                                    <input type="text" className="form-control" Name="address1" id="address1" />
                                </div>
                                <div class="col">
                                    <label>Address-2</label>
                                    <input type="text" className="form-control" Name="address2" id="address2" />
                                </div>
                                <div class="col">
                                    <label>Address-3</label>
                                    <input type="text" className="form-control" Name="address3" id="address3" />
                                </div>
                            </div>
                            <div class="row mt-4">

                                <div class="col">
                                    <label>District</label>
                                    <input type="text" className="form-control" Name="district" id="district" />
                                </div>
                                <div class="col">
                                    <label>City</label>
                                    <input type="text" className="form-control" Name="city" id="city" />
                                </div>
                                <div class="col">
                                    <label>State</label>
                                    <input type="text" className="form-control" Name="state" id="State" />
                                </div>
                                <div class="col">
                                    <label>Pin Code</label>
                                    <input type="text" className="form-control" Name="pincode" id="pincode" />
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col">
                                    <label>Status</label>
                                    
                                     <select class="form-control" id="status" name="status" >
                                        <option >Please select</option>
                                        {Custstatus.map(s=><option value={s.id}>{s.name}</option>)}
                                    </select>
                                </div>
                                <div class="col">
                                    <label>Interested Product</label>
                                    <select class="form-control" id="prointerested" name="prointerested" >
                                        <option >Please select</option>
                                         {Cust_Product.map(p=><option value={p.id}>{p.name}</option>)}

                                    </select>
                                </div>
                                <div class="col">
                                    <label>Lead Type</label>
                                    <select class="form-control" id="leadtype" name="leadtype" onChange={CheckLeadType}>
                                        <option >Please select</option>
                                        {CustLeadType.map(l=><option value={l.id}>{l.name}</option>)}
                                    </select>
                                </div>

                                <div class="col" id="refname">
                                    <label>Reference Name</label>
                                    <input type="text" className="form-control" Name="refname" id="refname" />
                                </div>

                                <div class="col">
                                    <label>Business Type</label>
                                    <select class="form-control" id="businesstype" name="businesstype">
                                        <option >Please select</option>
                                       {Cust_BusinessType.map(b=><option value={b.id}>{b.name}</option>)}
                                    </select>
                                </div>
                            </div>




                        </CCardBody>
                        <CCardFooter>
                            <CButton type="submit" size="sm" color="primary"><CIcon name="cil-scrubber" /> Submit</CButton>

                            <CButton className="ml-3" type="reset" size="sm" color="danger"><CIcon name="cil-ban" /> Reset</CButton>
                        </CCardFooter>
                        
                    </form>
                </CCard>
            </CCol>
        </CRow>
    );


}

export default withRouter(CustomerCreation);

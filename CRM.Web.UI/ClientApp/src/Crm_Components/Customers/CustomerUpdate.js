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
} from '@coreui/react';
import {Custstatus,CustLeadType,Cust_BusinessType} from '../../GlobalConfigFile';


const CustomerUpdate = (props) => {

    var history = useHistory();
    var bearer = 'Bearer ' + localStorage.getItem("token");


    const handleSubmit = (e) => {
        e.preventDefault();
        const Id=props.match.params.id;
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

            'Id':Id,
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
            'InterestedProduct': InterestedProduct,
            'ReferenceName': ReferenceName,
            'LeadType': LeadType,
            'BusinessType': BusinessType
        });
        var statusCode = 0;
        fetch("http://localhost:65150/api/customer/update", {
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
                        alert("Customer Updated Successfully")
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
    const CheckLeadType = (e) => {
        console.log(e)
        if (e.target.value !== '1')
            document.getElementById('refname').style.display = 'none';
        else
            document.getElementById('refname').style.display = 'block';
    }


    // Get customer Intrusted Product..........................................
    const [instprod, setInstprod] = useState([]);
    useEffect(() => {
        fetch("http://localhost:65150/api/Customer/IntrustedProduct",
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
                    (instprod) => { setInstprod(instprod) },
                    (error) => {console.log('error', error);}
                );
    }, []) // eslint-disable-line react-hooks/exhaustive-deps

    localStorage.setItem('Cust_Product', JSON.stringify(instprod));
    var Cust_Product = JSON.parse(localStorage.getItem('Cust_Product'));

    const [Udata, setUdata] = useState([]);

        useEffect(() => {
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
                (data) => { setUdata(data) 
                    document.getElementById("status").value=data.status;
                    document.getElementById("prointerested").value=data.interestedProduct;
                    document.getElementById("leadtype").value=data.leadType;
                    document.getElementById("businesstype").value=data.businessType;

                    if (data.leadtype !== '1')
                    document.getElementById('refname').style.display = 'none';
                else
                    document.getElementById('refname').style.display = 'block';
                },
                (error) => {console.log('error', error);}
            );
    }, []) // eslint-disable-line react-hooks/exhaustive-deps


    return (


        <CRow>
            <CCol xs="12" sm="12">
                <CCard>
                    <CCardHeader>
                        Customer Updation
          <small> Form</small>
                    </CCardHeader>
                    <form onSubmit={handleSubmit} >
                        <CCardBody>

                            <div class="row mt-4" >
                                <div class="col">
                                    <label>Name</label>
                                    <input type="text" className="form-control" defaultValue={Udata?.name} Name="cname" id="cname" />

                                </div>

                                <div class="col">
                                    <label>Domain</label>
                                    <input type="text" class="form-control" defaultValue={Udata?.domain} Name="domain" id="domain" />
                                </div>




                                <div class="col">
                                    <label>Email Id</label>
                                    <input type="email" className="form-control" defaultValue={Udata?.email} Name="email" id="email" />
                                </div>
                                <div class="col">
                                    <label>Shop Name</label>
                                    <input type="text" className="form-control" defaultValue={Udata?.shopName} Name="shopname" id="shopname" />

                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col">
                                    <label>Mobile Number</label>
                                    <input type="number" className="form-control" defaultValue={Udata?.mobile} Name="mobileno" id="mobileno" />
                                </div>


                                <div class="col">
                                    <label>Address-1</label>
                                    <input type="text" className="form-control" defaultValue={Udata?.address1} Name="address1" id="address1" />
                                </div>
                                <div class="col">
                                    <label>Address-2</label>
                                    <input type="text" className="form-control" defaultValue={Udata?.address2} Name="address2" id="address2" />
                                </div>
                                <div class="col">
                                    <label>Address-3</label>
                                    <input type="text" className="form-control" defaultValue={Udata?.address3} Name="address3" id="address3" />
                                </div>
                            </div>
                            <div class="row mt-4">

                                <div class="col">
                                    <label>District</label>
                                    <input type="text" className="form-control" defaultValue={Udata?.district} Name="district" id="district" />
                                </div>
                                <div class="col">
                                    <label>City</label>
                                    <input type="text" className="form-control" defaultValue={Udata?.city} Name="city" id="city" />
                                </div>
                                <div class="col">
                                    <label>State</label>
                                    <input type="text" className="form-control" defaultValue={Udata?.state} Name="state" id="State" />
                                </div>
                                <div class="col">
                                    <label>Pin Code</label>
                                    <input type="text" className="form-control" defaultValue={Udata?.pinCode}  Name="pincode" id="pincode" />
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
                                    <input type="text" className="form-control" defaultValue={Udata?.referenceName} Name="refname" id="refname" />
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
                            <CButton type="submit" size="sm" color="primary"><CIcon name="cil-scrubber" /> Update</CButton>

                            <CButton className="ml-3" type="reset" size="sm" color="danger"><CIcon name="cil-ban" /> Reset</CButton>
                        </CCardFooter>
                    </form>
                </CCard>
            </CCol>
        </CRow>
    );
}



export default CustomerUpdate;

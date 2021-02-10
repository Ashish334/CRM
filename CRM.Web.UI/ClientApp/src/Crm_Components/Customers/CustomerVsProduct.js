import React, { Fragment, useState, useEffect } from "react";
import CIcon from '@coreui/icons-react';
import { blockInvalidChar } from "../../GlobalConfigFile";
import { useHistory } from "react-router-dom";
import {
    CButton,
    CCard,
    CCardBody,
    CCardFooter,
    CCardHeader,
    CCol,
    CRow
} from '@coreui/react'


const CustomerVsProduct = () => {
    var history = useHistory();
    const [data, setData] = useState([]);
    var bearer = 'Bearer ' + localStorage.getItem("token");


    const initialState = [{
        /* etc */
    }];

    const datareset = [
        /* etc */
    ];

    const OnReset = (e) => {
        setUdata(datareset);
        setInputFields(initialState);

    }


    useEffect(() => {

        fetch("http://localhost:65150/api/customer/getall",
            {
                method: "GET",
                headers: {
                    'Authorization': bearer,
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
            })

            .then(res => res.json())
            .then(data => {
                setData(data);
            },
                (error) => { console.log('error', error) }
            );

    }, []) // eslint-disable-line react-hooks/exhaustive-deps

    const [Udata, setUdata] = useState([]);

    const selectcustomer = (e) => {

        fetch("http://localhost:65150/api/customer/" + e.target.value,
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
                (data) => {
                    setUdata(data);
                    // inputFields[0].productName = data.interestedProduct;
                    // document.getElementById("productName").value = data.interestedProduct;
                },
                (error) => { console.log('error', error); }
            );
    } // eslint-disable-line react-hooks/exhaustive-deps

    const [, setPdata] = useState([]);
    const ProductDetails = (i, e) => {
        fetch("http://localhost:65150/api/ProductDetails/" + parseInt(e.target.value),
            {
                method: "GET",
                headers: {
                    'Authorization': bearer,
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
            })

            .then(res => res.json())
            .then((data) => {
                setPdata(data);

                inputFields[i].price = data.price;

                inputFields[i].gstPer = data.gst;

                inputFields[i].gstAmt = (((data.price * 100) / (100 + data.gst)) / 100) * data.gst;

                inputFields[i].netamt = (data.price);

                setInputFields(inputFields);



            },
                (error) => { console.log('error', error); }
            );
    } // eslint-disable-line react-hooks/exhaustive-deps

    const [qty, setQty] = useState(0);
    const onchangeQty = (i, e) => {
        var b = (e.target.value);
        var qt = b === 0 ? 1 : b === '' ? 1 : b;
        var pr = inputFields[i].price;
        var gst = inputFields[i].gstPer;
        var gt = (((pr * 100) / (100 + gst)) / 100) * gst;
        var dp = inputFields[i].discountPer;
        var d = dp === 0 ? 0 : dp === '' ? 0 : dp;
        var t = ((pr * 100) / (100 + gst));
        var dscamnt = ((d / 100) * t) * qt;
        inputFields[i].discountAmt = dscamnt;
        var amountnet = (pr * qt) - dscamnt;
        inputFields[i].netamt = amountnet;
        var gstamnt = gt * qt;
        inputFields[i].gstAmt = gstamnt;
        setInputFields(inputFields);
        setQty(b);
    }

   

    const [, setdisc] = useState(0);
    const onchangedisc = (i, e) => {
        var a = e.target.value;
        var d = a === 0 ? 0 : a === '' ? 0 : a;
        var pr = inputFields[i].price;
        var gst = inputFields[i].gstPer;
        var gt = ((pr * 100) / (100 + gst));
        var qt = qty === 0 ? 1 : qty === '' ? 1 : qty;
        var dscamnt = ((d / 100) * gt) * qt;
        inputFields[i].discountAmt = dscamnt;
        var amtnet = (pr * qt) - dscamnt;
        inputFields[i].netamt = amtnet;
        setInputFields(inputFields);
        setdisc(d);

    }


    const TotalAmount = () => {

        var totalamount = 0;
        for (let index = 0; index < inputFields.length; index++) {
            totalamount = totalamount + inputFields[index].netamt;

        }
        return totalamount;
    }


    const [inputFields, setInputFields] = useState([
        { productName: '', price: '', qty: '', discountPer: '', discountAmt: '', gstPer: '', gstAmt: '', netamt: '' }
    ]);

    const handleSubmit = e => {
        e.preventDefault();
        
        var requestBody =[];
        for (var i = 0; i < inputFields.length; i++) 
        {
              var field = 
              {  
                  indexId : i + 1,
                  customerid : Udata.id,
                  customername : Udata.name,
                  productName : inputFields[i].productName,
                  price : inputFields[i].price,
                  qty : inputFields[i].qty,
                  discountPer : inputFields[i].discountPer,
                  discountAmt : inputFields[i].discountAmt,
                  gstPer : inputFields[i].gstPer,
                  gstAmt : inputFields[i].gstAmt,
                  netamt : inputFields[i].netamt
                  };
                  requestBody.push(field);		   
       
               }
        var statusCode = 0;
        fetch('http://localhost:65150/api/customervsproduct/create', {
            method: 'POST',
            headers:
            {
                'Authorization': bearer,
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body:JSON.stringify(requestBody)
        })
            .then(response => {
                statusCode = response.status;
                return response
            })
            .then(
                (data) => {
                    if (statusCode === 200) {
                        alert("Customer Vs Product Created Successfully")
                        console.log('Success', data);
                        history.push('/CustomerVsProductList')
                    }
                    else {
                        alert("You have wrong entered")

                    }
                },
                (error) => {
                    console.log('error', error);

                }
            );
    };


    // handle input change
    const handleInputChange = (index, event) => {

        const { name, value } = event.target;
        const list = [...inputFields];
        list[index][name] = value;
        setInputFields(list);
    };

    // handle click event of the Add button
    const handleAddFields = () => {
        const values = [...inputFields];
        values.push({ productName: '', price: '', qty: '', discountPer: '', discountAmt: '', gstPer: '', gstAmt: '', netamt: '' });
        setInputFields(values);
    };
    //  handle click event of the Remove button
    const handleRemoveFields = index => {


        const values = [...inputFields];
        values.splice(index, 1);
        setInputFields(values);

    };
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
                (instprod) => {
                    setInstprod(instprod)

                },
                (error) => { console.log('error', error); }
            );
    }, []) // eslint-disable-line react-hooks/exhaustive-deps

    localStorage.setItem('Cust_Product', JSON.stringify(instprod));

    var Cust_Prod = JSON.parse(localStorage.getItem('Cust_Product'));
    return (


        <CRow>
            <CCol xs="12" sm="12">
                <CCard>
                    <CCardHeader>
                        Product Manage
              <small> Form</small>
                    </CCardHeader>
                    <form onSubmit={handleSubmit} >
                        <CCardBody>
                            <div className="row">
                                <div class=" col-12 p-1 mt-3 bg-dark text-white text-center rounded">
                                    <h5>CUSTOMER DETAILS</h5>
                                </div>

                            </div>
                            <div class="row mt-4" >
                                <div class="col">
                                    <label>Customer Name</label>

                                    <select class="form-control"
                                        onChange={selectcustomer}
                                        id="cname"
                                        name="cname" >
                                        <option>Select...</option>
                                        {data.map(c => <option value={c.id}>{c.name}</option>)}
                                    </select>

                                </div>

                                <div class="col">
                                    <label>Customer Domain</label>
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
                            <div className="row">
                                <div class=" col-12 p-1 mt-3 bg-dark text-white text-center rounded">
                                    <h5>PRODUCT DETAILS</h5>
                                </div>

                            </div>
                            <div className="row mt-3">
                                <div class="col-3">
                                    <label>Product Name</label> </div>
                                <div class="col"><label>Price</label></div><div class="col"><label>Qty</label></div>
                                <div class="col"><label>Disc %</label></div><div class="col"><label>Disc Amt</label></div>
                                <div class="col"><label>GST%</label></div><div class="col"><label>GST Amt</label></div>
                                <div class="col"> <label>Net Amt</label></div>
                                <div class="col"><div className="text-white text-center rounded">
                                    <CButton color="primary" onClick={() => { handleAddFields() }}>+</CButton>
                                </div></div>
                            </div>


                            {inputFields.map((inputField, index) => (
                                <Fragment key={`${inputField}~${index}`}>
                                    <div className="row mt-2">
                                        <div class="col-3">

                                            <select class="form-control"
                                                id="productName"
                                                name="productName"
                                                value={inputField.productName}
                                                onChange={event => { handleInputChange(index, event); ProductDetails(index, event) }}>
                                                <option >Please select</option>
                                                {Cust_Prod.map(p => <option value={p.id}>{p.name}</option>)}

                                            </select>


                                        </div>
                                        <div class="col">

                                            <input type="number" className="form-control"
                                                disabled
                                                name="price"
                                                id="price"
                                                value={inputField.price}
                                                onChange={event => { handleInputChange(index, event); }}
                                            />
                                        </div>
                                        <div class="col">

                                            <input type="number"
                                                className="form-control"
                                                required
                                                name="qty"
                                                id="qty"
                                                min="0"
                                                onKeyDown={blockInvalidChar}
                                                value={inputField.qty}
                                                onChange={event => { handleInputChange(index, event); onchangeQty(index, event) }}
                                            />
                                        </div>

                                        <div class="col">

                                            <input type="number"
                                                className="form-control"
                                                name="discountPer"
                                                id="discountPer"
                                                min="0"
                                                onKeyDown={blockInvalidChar}
                                                value={inputField.discountPer}
                                                onChange={event => { handleInputChange(index, event); onchangedisc(index, event) }}
                                            />

                                        </div>
                                        <div class="col">

                                            <input type="number" className="form-control"
                                                disabled
                                                name="discountAmt"
                                                id="discountAmt"
                                                value={inputField.discountAmt}
                                                onChange={event => handleInputChange(index, event)}
                                            />

                                        </div>
                                        <div class="col">

                                            <input type="number" className="form-control"
                                                disabled
                                                name="gstPer"
                                                id="gstPer"
                                                value={inputField.gstPer}
                                                onChange={event => { handleInputChange(index, event); }}
                                            />
                                        </div>


                                        <div class="col">

                                            <input type="number" className="form-control"
                                                disabled
                                                name="gstAmt"
                                                id="gstAmt"
                                                value={inputField.gstAmt}
                                                onChange={event => handleInputChange(index, event)}
                                            />

                                        </div>
                                        <div class="col">

                                            <input type="number" className="form-control"
                                                disabled
                                                name="netamt"
                                                id="netamt"
                                                value={inputField.netamt}
                                                onChange={event => handleInputChange(index, event)}
                                            />
                                        </div>


                                        <div className="col text-white text-center rounded">

                                            <CButton color="danger" onClick={() => { handleRemoveFields(index) }}>-</CButton>
                                        </div>


                                    </div>
                                </Fragment>

                            ))}

                            <div className="row mt-3">
                                <div>
                                    <label>Total Amt</label>
                                    <input type="number" className="form-control"
                                        Name="totalamt"
                                        id="totalamt"
                                        value={TotalAmount()}
                                    />
                                </div>
                            </div>
                        </CCardBody>
                        <CCardFooter>
                            <CButton type="submit" size="sm" color="primary"><CIcon name="cil-scrubber" /> Submit</CButton>

                            <CButton className="ml-3" type="reset" size="sm" color="danger" onClick={OnReset}><CIcon name="cil-ban" /> Reset</CButton>
                        </CCardFooter>
                    </form>
                </CCard>
            </CCol>
        </CRow>
    );


}

export default CustomerVsProduct;

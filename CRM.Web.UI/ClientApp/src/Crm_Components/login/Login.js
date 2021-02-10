import React from 'react'
//import { Link } from 'react-router-dom'
import BgImage from '../../Images/BG_LOGIN1.jpg'
import { useHistory } from "react-router-dom";
import {
  CButton,
  CCard,
  CCardBody,
  CCardGroup,
  CCol,
  CContainer,
  CForm,
  CInput,
  CInputGroup,
  CInputGroupPrepend,
  CInputGroupText,
  CRow
} from '@coreui/react'
import CIcon from '@coreui/icons-react'

const Login = () => {
 
  const history = useHistory();
  const handleSubmit = (e) => {
    e.preventDefault();
    const EmailId = e.target.email.value;
    const Password = e.target.password.value;

    var requestBody = JSON.stringify({
      'Email':EmailId,
      'Password':Password
    });
    var statusCode = 0;
    fetch('http://localhost:65150/api/auth/login', {
              method: 'POST',
              headers: 
              { 
                  'Accept': 'application/json',
                  'Content-Type': 'application/json', },
              body:requestBody
            })
            .then(response => {
              console.log('Success', response)
              statusCode = response.status;
              return response.json()})
            
            .then(
              (data) => {
                if(statusCode === 200){
                alert("You have Loged in Successfully")
                console.log('Success', data);
                localStorage.setItem("token",data.token.access_token);
                localStorage.setItem("islogin",'1');
                history.push('/dashboard')
                window.location.reload();
              }
              else{
                alert("Invalid Email Or Password" )
                document.getElementsByName("password")[0].value='';
                
              }
              },
              (error) => {
                alert("You have wrong entered")
                console.log('error', error);
               
              }
            );
  }

  return (
    <div className="c-app c-default-layout flex-row align-items-center" style={{ backgroundImage: `url(${BgImage})`,backgroundSize: "100% 100%" }}>
      <CContainer>
        <CRow className="justify-content-center" >
          <CCol md="4">
            <CCardGroup>
              <CCard className="p-4">
                <CCardBody>
                  <CForm onSubmit={handleSubmit}>
                    <h1>Login</h1>
                    <p className="text-muted">Sign In to your account</p>
                    <CInputGroup className="mb-3">
                      <CInputGroupPrepend>
                        <CInputGroupText>
                          <CIcon name="cil-envelope-closed" />
                        </CInputGroupText>
                      </CInputGroupPrepend>
                      <CInput type="email" placeholder="Email" name="email" id="email" autoComplete="Email" />
                    </CInputGroup>
                    <CInputGroup className="mb-4">
                      <CInputGroupPrepend>
                        <CInputGroupText>
                          <CIcon name="cil-lock-locked" />
                        </CInputGroupText>
                      </CInputGroupPrepend>
                      <CInput type="password" placeholder="Password" name="password" id="password" autoComplete="current-password" />
                    </CInputGroup>
                    <CRow>
                      <CCol xs="6">
                        <CButton type="submit" color="primary" className="px-4">Login</CButton>
                      </CCol>
                     
                    </CRow>
                  </CForm>
                </CCardBody>
              </CCard>
             
            </CCardGroup>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default Login

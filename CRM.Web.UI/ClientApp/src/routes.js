import React from 'react';

 
  const Dashboard = React.lazy(() => import('./Dashboard/Dashboard'));
//-----------------------------CRM-----------------------------------//
const UserList = React.lazy(() => import('./Crm_Components/Users/UserList'));
const UserCreation = React.lazy(() => import('./Crm_Components/Users/UserCreation'));
const UserDetails = React.lazy(() => import('./Crm_Components/Users/UserDetails'));
const UserUpdate = React.lazy(() => import('./Crm_Components/Users/UserUpdate'));

const CustomerList = React.lazy(() => import('./Crm_Components/Customers/CustomerList'));
const CustomerCreation = React.lazy(() => import('./Crm_Components/Customers/CustomerCreation'));
const CustomerDetails = React.lazy(() => import('./Crm_Components/Customers/CustomerDetails'));
const CustomerUpdate = React.lazy(() => import('./Crm_Components/Customers/CustomerUpdate'));

const ProductList = React.lazy(() => import('./Crm_Components/Product/ProductList'));
const ProductCreation = React.lazy(() => import('./Crm_Components/Product/ProductCreation'));
const ProductDetails = React.lazy(() => import('./Crm_Components/Product/ProductDetails'));
const ProductUpdate = React.lazy(() => import('./Crm_Components/Product/ProductUpdate'));

const CustomerVsProduct = React.lazy(() => import('./Crm_Components/Customers/CustomerVsProduct'));
const CustomerVsProductList = React.lazy(() => import('./Crm_Components/Customers/CustomerVsProductList'));
const CustomerVsProductDetails = React.lazy(() => import('./Crm_Components/Customers/CustomerVsProductDetails'));
const CustomerVsProductUpdate = React.lazy(() => import('./Crm_Components/Customers/CustomerVsProductUpdate'));


const routes = [

  { path: '/dashboard', name: 'Dashboard', component: Dashboard },
  { path: '/', exact: true, name: 'Home' },
  //---------------------------CRM--------------------------------//
  {path:'/UserList', name: 'UserList', component: UserList},
  {path:'/UserCreation', name: 'UserCreation', component: UserCreation},
  {path:'/UserDetails/:id', name: 'UserDetails', component: UserDetails},
  {path:'/UserUpdate/:id', name: 'UserUpdate', component: UserUpdate},

  {path:'/CustomerList', name: 'CustomerList', component: CustomerList},
  {path:'/CustomerCreation', name: 'CustomerCreation', component: CustomerCreation},
  {path:'/CustomerDetails/:id', name: 'CustomerDetails', component: CustomerDetails},
  {path:'/CustomerUpdate/:id', name: 'CustomerUpdate', component: CustomerUpdate},

  {path:'/ProductList', name: 'ProductList', component: ProductList},
  {path:'/ProductCreation', name: 'ProductCreation', component: ProductCreation},
  {path:'/ProductDetails/:id', name: 'ProductDetails', component: ProductDetails},
  {path:'/ProductUpdate/:id', name: 'ProductUpdate', component: ProductUpdate},

  {path:'/CustomerVsProduct', name: 'CustomerVsProduct', component: CustomerVsProduct},
  {path:'/CustomerVsProductList', name: 'CustomerVsProductList', component: CustomerVsProductList},
  {path:'/CustomerVsProductDetails/:id', name: 'CustomerVsProductDetails', component: CustomerVsProductDetails},
  {path:'/CustomerVsProductUpdate/:id', name: 'CustomerVsProductUpdate', component: CustomerVsProductUpdate},

  //---------------------------CRM--------------------------------//
  
  ];

export default routes;

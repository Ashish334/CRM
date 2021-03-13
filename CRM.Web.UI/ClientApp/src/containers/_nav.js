export default [
  {
    _tag: 'CSidebarNavItem',
    name: 'Dashboard',
    to: '/dashboard',
    icon: 'cil-speedometer',
    badge: {
      color: 'info',
      text: 'NEW',
    }
  },
  
  {
    _tag: 'CSidebarNavTitle',
    _children: ['MASTERS']
  },
 
  {
    _tag: 'CSidebarNavDropdown',
    name: 'User Master',
    route: '/usermaster',
    icon: 'cil-user',
    _children: [
      {
        _tag: 'CSidebarNavItem',
        name: 'User Details',
        to: '/userlist',
      },
    ]
  },
  {
    _tag: 'CSidebarNavDropdown',
    name: 'Product Master',
    route: '',
    icon: 'cil-user',
    _children: [
      {
        _tag: 'CSidebarNavItem',
        name: 'Product Details',
        to: '/productlist',
      },
    ]
  },
  {
    _tag: 'CSidebarNavTitle',
    _children: ['CUSTOMERS']
  },
 
  {
    _tag: 'CSidebarNavDropdown',
    name: 'Customer Master',
    route: '/Customermaster',
    icon: 'cil-people',
    _children: [
      {
        _tag: 'CSidebarNavItem',
        name: 'Customer Details',
        to: '/CustomerList',
      },
      {
        _tag: 'CSidebarNavItem',
        name: 'Customer Vs Product',
        to: '/CustomerVsProductList',
      },
    ]
  },
  //----------------------------------------------------------//
  ]


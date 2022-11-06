import React, { Fragment } from 'react';
import { Route, Routes } from 'react-router-dom';
import Home from './pages/Home';
import Invoices from './pages/Invoices';
import Items from './pages/Items';
import Sidebar from './components/Sidebar';
import InvoiceDetails from './pages/InvoiceDetails';
import NewInvoice from './pages/NewInvoice';
import { AppBar, Toolbar, Typography }  from "@mui/material";

const sidebarWidth = 200;
const appbarHeight = 70;

const App = () => {
  return (
    <Fragment>
      <AppBar style={{width: `calc(100% - ${sidebarWidth}px)`, height: `${appbarHeight}px`}}>
        <Toolbar>
          <Typography variant="h6">
              Best tool for browsing invoices!
          </Typography>
        </Toolbar>
      </AppBar>
      <Sidebar width={sidebarWidth} height={appbarHeight} />
      <main style={{marginLeft: `${sidebarWidth}px`, marginTop: `${appbarHeight}px`}}>
      <Routes>
        <Route exact path='/' element={<Home />} />
        <Route path='/home' exact element={<Home />} />
        <Route path='/invoices/:invoiceId' element={<InvoiceDetails />} />
        <Route path='/invoices' exact element={<Invoices />} />
        <Route path='/items' exact element={<Items />} />
        <Route path='/new-invoice' element={<NewInvoice />} />
      </Routes>
      </main>
    </Fragment>
  )
}

export default App;

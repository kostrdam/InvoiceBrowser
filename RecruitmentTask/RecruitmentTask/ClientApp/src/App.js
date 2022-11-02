import React, { Fragment } from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';
import Home from './pages/Home';
import Invoices from './pages/Invoices';
import Items from './pages/Items';
import Sidebar from './components/Sidebar';
import InvoiceDetails from './pages/InvoiceDetails';
import ItemDetails from './pages/ItemDetails';
import NewInvoice from './pages/NewInvoice';
import { AppBar, Container, Toolbar, Typography }  from "@mui/material";

// import ./App.css';
// import styles from './custom.module.css'

const sidebarWidth = 200;

// const styles = theme => ({
//   root: {
//     display: "flex"
//   },
//   appBar: {
//     width: `calc(100% - ${sidebarWidth}px)`,
//     marginLeft: sidebarWidth
//   },
//   drawer: {
//     width: sidebarWidth,
//     flexShrink: 0
//   },
//   drawerPaper: {
//     width: sidebarWidth
//   },
//   // toolbar: theme.mixins.toolbar,
//   content: {
//     flexGrow: 1,
//     // backgroundColor: theme.palette.background.default,
//     // padding: theme.spacing.unit * 3
//   }
// });

const App = () => {

  return (
    <Fragment>
      <AppBar style={{width: `calc(100% - ${sidebarWidth}px)`}}>
        <Toolbar>
          <Typography variant="h4">
              Invoice Browser
          </Typography>
        </Toolbar>
      </AppBar>
      <Sidebar style={{width: sidebarWidth}}/>
      {/* <main> */}
      <Switch>
        <Route exact path='/'>
          <Redirect to='/home'/>
        </Route>
        <Route path='/home' exact component={Home} />
        <Route path='/invoices/:invoiceId' component={InvoiceDetails} />
        <Route path='/invoices' exact component={Invoices} />
        <Route path='/items/:itemId' component={ItemDetails} />
        <Route path='/items' exact component={Items} />
        <Route path='/new-invoice' component={NewInvoice} />
      </Switch>
      {/* </main> */}
    </Fragment>
  )
}

export default App;

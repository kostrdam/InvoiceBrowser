import React from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';
import Home from './pages/Home';
import Invoices from './pages/Invoices';
import Items from './pages/Items';
import Sidebar from './components/Sidebar';
import InvoiceDetails from './pages/InvoiceDetails';
import ItemDetails from './pages/ItemDetails';
import NewInvoice from './pages/NewInvoice';
import { AppBar, Container, Toolbar, Typography }  from "@mui/material";

import './custom.css'

const drawerWidth = 240;

const styles = theme => ({
  root: {
    display: "flex"
  },
  appBar: {
    width: `calc(100% - ${drawerWidth}px)`,
    marginLeft: drawerWidth
  },
  drawer: {
    width: drawerWidth,
    flexShrink: 0
  },
  drawerPaper: {
    width: drawerWidth
  },
  // toolbar: theme.mixins.toolbar,
  content: {
    flexGrow: 1,
    // backgroundColor: theme.palette.background.default,
    // padding: theme.spacing.unit * 3
  }
});

const App = () => {

  return (
    <div className="root">
      <AppBar className="appBar">asdasds
        {/* <Toolbar className="toolbar">
          <Typography variant="h4" className="title">Invoice Browser</Typography>
        </Toolbar> */}
      </AppBar>
      <Container>
      <Sidebar />
        <main>
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
        </main>
      </Container>
    </div>
  )
}

export default App;

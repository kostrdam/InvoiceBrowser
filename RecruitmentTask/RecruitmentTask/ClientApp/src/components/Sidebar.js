import { Drawer, Divider, Typography } from "@mui/material";
import NavItem from "./NavItem";

const Sidebar = () => {
    return (
        <Drawer anchor="left" variant='permanent'>
            <div>
                <Typography variant="h5">Invoice Browser</Typography>
            </div>
            <Divider />
            <NavItem to='/home' text='Home' />
            <NavItem to='/invoices' text='Invoices' />
            <NavItem to='/items/' text='Items' />
            <Divider />
            <NavItem to='/new-invoice' text='Create new invoice' />
        </Drawer>
    )
};

export default Sidebar;
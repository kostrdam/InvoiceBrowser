import { Drawer, Divider, Typography, Toolbar, useTheme } from "@mui/material";
import NavItem from "./NavItem";

const Sidebar = (props) => {
    const theme = useTheme();
    return (
        <Drawer anchor="left" variant='permanent'>
            <Toolbar style={{width: `${props.width}px`, height: `${props.height}px`, backgroundColor: theme.palette.primary.dark }}>
                <Typography variant="h6">
                    Invoice Browser
                </Typography>
            </Toolbar>
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
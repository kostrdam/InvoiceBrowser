import { NavLink } from "react-router-dom";
import { ListItem, ListItemButton, ListItemText } from "@mui/material";

import styles from './component-styles.module.css';

const NavItem = (props) => {
    return (
        <ListItem disablePadding >
            <NavLink to={props.to}>
                <ListItemButton className={styles.sidebarItem}>
                    <ListItemText>{props.text}</ListItemText>
                </ListItemButton>
            </NavLink>
        </ListItem>
    )
}

export default NavItem;
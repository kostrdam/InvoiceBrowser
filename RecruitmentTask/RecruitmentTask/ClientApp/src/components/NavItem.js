import { NavLink } from "react-router-dom";
import { ListItem, ListItemText } from "@mui/material";

const NavItem = (props) => {
    return (
        <ListItem>
            <NavLink to={props.to}>
                <ListItemText>{props.text}</ListItemText>
            </NavLink>
        </ListItem>
    )
}

export default NavItem;
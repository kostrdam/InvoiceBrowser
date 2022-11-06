import { List } from "@mui/material";
import ListItemRow from "./ItemListRow";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";

import { apiActions } from '../../store/index';

import { paths } from '../../constants';

const ItemList = (props) => {
    let itemsArray = [];
    const dispatch = useDispatch();
    const items = useSelector((state) => state.api.items);
    useEffect(() => fetchItemsHandler(), []);

    function fetchItemsHandler() {
        if (items.length < 1) {
            fetch(`${paths.API_URL}/${paths.ITEMS_URL}`).then(respone => {
                return respone.json();
            }).then(data => {
                dispatch(apiActions.getItems(data));
            });
        }
    }

    function countItemsHandler(itemQuantity) {
        let index = itemsArray.findIndex(item => item.id === itemQuantity.id);
        if (index > -1) {
            itemsArray[index].quantity = itemQuantity.quantity;
        }
        else {
            itemsArray.push(itemQuantity);
        }
        props.updateItems(itemsArray);
    }

    return (
        <List>
            {items.map((item) => (
                <ListItemRow key={item.id} data={item} updateQuantity={countItemsHandler}></ListItemRow>
            ))}
        </List>
    )
}

export default ItemList;
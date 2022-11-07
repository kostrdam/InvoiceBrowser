import { List } from "@mui/material";
import ListItemRow from "./ItemListRow";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";

import { apiActions } from '../../store/index';

import { paths } from '../../constants';

const ItemList = (props) => {
    const [itemsArray, setItemsArray] = useState([]);
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

    function countItemsHandler(addedItem) {
        let index = itemsArray.findIndex(item => item.id === addedItem.id);
        if (index > -1) {
            if (addedItem.quantity < 1) {
                itemsArray.splice(index, 1);
            }
            else {
                itemsArray[index].quantity = addedItem.quantity;
            }
            console.log(itemsArray);
        }
        else {
            itemsArray.push(addedItem);
            console.log(itemsArray);
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
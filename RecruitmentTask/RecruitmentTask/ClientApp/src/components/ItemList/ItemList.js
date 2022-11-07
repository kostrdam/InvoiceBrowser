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
        let newItemsArray = [...itemsArray];
        if (index > -1) {
            if (addedItem.quantity < 1) {
                newItemsArray.splice(index, 1);
                setItemsArray(newItemsArray);
            }
            else {
                newItemsArray[index].quantity = addedItem.quantity;
                setItemsArray(newItemsArray);
            }
        }
        else {
            setItemsArray([...itemsArray, {id: addedItem.id, quantity: addedItem.quantity}]);
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
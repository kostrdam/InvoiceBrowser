import { ListItem, ListItemText, Button } from '@mui/material';
import { Add, Remove } from '@mui/icons-material';
import { useState } from 'react';

const ItemListRow = (props) => {
    const [quantity, setQuantity] = useState(0);
    
    function addHandler() {
        setQuantity(quantity + 1);
        props.updateQuantity({id: props.data.id, quantity: quantity + 1});
    }

    function removeHandler() {
        setQuantity(quantity - 1);
        props.updateQuantity({id: props.data.id, quantity: quantity - 1});
    }

    return (
        <ListItem>
            <ListItemText>{props.data.name}</ListItemText>
            <ListItemText>{props.data.price}zł</ListItemText>
            <ListItemText>{quantity}</ListItemText>
            <Button onClick={addHandler} endIcon={<Add />}>ADD</Button>
            <Button onClick={removeHandler} endIcon={<Remove />}>REMOVE</Button>
        </ListItem>
    )
}

export default ItemListRow;
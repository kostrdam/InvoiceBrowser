import { Button, TextField, Typography } from "@mui/material";
import DatePicker from '../components/DatePicker';
import SendIcon from '@mui/icons-material/Send';
import { useRef, useState } from "react";
import styles from './pages-styles.module.css';
import ItemList from "../components/ItemList/ItemList";
import { paths } from '../constants';

const moment = require('moment');
const NewInvoice = () => {
    const nameInputRef = useRef();
    const numberInputRef = useRef();
    const accountInputRef = useRef();
    const dateInputRef = useRef();
    const [itemsArray, setItemsArray] = useState();

    function submitInvoiceHandler() {
        fetch(`${paths.API_URL}/${paths.INVOICES_URL}`, {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'POST',
            body: JSON.stringify({
                number: numberInputRef.current.value,
                name: nameInputRef.current.value,
                accountNumber: accountInputRef.current.value,
                paymentDate: dateInputRef.current.value,
                invoiceItems: itemsArray
            })
        }).then(response => {
            if (response.ok) {
                return response.json();
        }}).catch(error => {
            console.log("Error: " + error);
        });
    }
    
    function updateItemsHandler(itemsNewArray) {
        setItemsArray([...itemsNewArray]);
    }

    return (
        <section className={styles.newInvoiceSection}>
            <Typography variant="h3">Create new invoice</Typography>
            <form className={styles.newInvoiceBox}>
                <TextField inputRef={numberInputRef} className={styles.newInvoiceField} required label="Required" defaultValue="Invoice number" />
                <TextField inputRef={nameInputRef} className={styles.newInvoiceField} required label="Required" defaultValue="Invoice name" />
                <TextField inputRef={accountInputRef} className={styles.newInvoiceField} required label="Required" defaultValue="Account number" />
                <DatePicker inputRef={dateInputRef} label="Payment date" initialValue={moment().format("DD/MM/YYYY")}/>
                <ItemList updateItems={updateItemsHandler}></ItemList>
                <Button className={styles.newInvoiceButton} variant="contained" endIcon={<SendIcon />} onClick={submitInvoiceHandler}>Create Invoice</Button>
            </form>
        </section>
    )
}

export default NewInvoice;
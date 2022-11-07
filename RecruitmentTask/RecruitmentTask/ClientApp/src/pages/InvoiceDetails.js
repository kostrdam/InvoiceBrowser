import { useParams, useNavigate } from 'react-router-dom';
import { Button, TextField, Typography, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';
import { useSelector } from 'react-redux';

import styles from './pages-styles.module.css';

const moment = require('moment');
const InvoiceDetails = () => {
    const params = useParams();
    const navigate = useNavigate();
    const invoice = useSelector((state) => state.api.invoices.find(obj => obj.id == params.invoiceId));

    function onClickHandler() {
        navigate('/invoices');
    }

    return (
        <section className={styles.invoiceDetailsSection}>
            <Button className={styles.invoiceDetailsBackBtn} variant="contained" onClick={onClickHandler}>Back to list</Button>
            <Typography variant="h4">{}</Typography>
            <form className={styles.invoiceDetailsBox}>
                <TextField className={styles.invoiceDetailsField} variant="outlined" InputProps={{readOnly: true }} label="Invoice name" defaultValue={invoice.name} />
                <TextField className={styles.invoiceDetailsField} variant="outlined" InputProps={{readOnly: true }} label="Account number" defaultValue={invoice.accountNumber} />
                <TextField className={styles.invoiceDetailsField} variant="outlined" InputProps={{readOnly: true }} label="Invoice date" defaultValue={moment(invoice.invoiceDate).format("DD/MM/YYYY")} />
                <TextField className={styles.invoiceDetailsField} variant="outlined" InputProps={{readOnly: true }} label="Payment date" defaultValue={moment(invoice.paymentDate).format("DD/MM/YYYY")} />
            </form>
            <TableContainer>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Item name</TableCell>
                            <TableCell>Price per unit</TableCell>
                            <TableCell>Quantity</TableCell>
                            <TableCell>Total price</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {invoice.invoiceItems.map((item) => (
                            <TableRow key={item.id}>
                                <TableCell>{item.name}</TableCell>
                                <TableCell>{item.price}</TableCell>
                                <TableCell>{item.quantity}</TableCell>
                                <TableCell>{item.price * item.quantity}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </section>
    )
}

export default InvoiceDetails;
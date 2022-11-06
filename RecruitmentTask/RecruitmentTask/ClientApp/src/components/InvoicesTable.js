import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';
import { useNavigate } from "react-router-dom";

import styles from './component-styles.module.css';

const moment = require('moment');
const InvoicesTable = (props) => {
    const navigate = useNavigate();

    function handleRowClick(invoiceId) {
        navigate('/invoices/' + invoiceId);
    }

    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }}>
                <TableHead>
                        <TableRow>
                            <TableCell className={styles.tableHeader} align="right">Invoice Number</TableCell>
                            <TableCell className={styles.tableHeader} align="right">Invoice Name</TableCell>
                            <TableCell className={styles.tableHeader} align="right">Invoice Date</TableCell>
                            <TableCell className={styles.tableHeader} align="right">Total Amount</TableCell>
                        </TableRow>
                    </TableHead>
                <TableBody>
                {props.data.map((invoice) => (
                    <TableRow className={styles.invoicesTableRow} key={invoice.id} onClick={() => handleRowClick(invoice.id)}>
                        <TableCell align="right">{invoice.number}</TableCell>
                        <TableCell align="right">{invoice.name}</TableCell>
                        <TableCell align="right">{moment(invoice.invoiceDate).format("DD/MM/YYYY")}</TableCell>
                        <TableCell align="right">{invoice.totalAmount}</TableCell>
                    </TableRow>
                ))}
                </TableBody>
            </Table>
        </TableContainer>
    )
}

export default InvoicesTable;
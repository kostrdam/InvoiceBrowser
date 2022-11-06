import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';
import { useNavigate } from "react-router-dom";

import styles from './component-styles.module.css';

const ItemsTable = (props) => {
    const navigate = useNavigate();

    function handleRowClick(itemId) {
        navigate('/items/' + itemId);
    }

    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }}>
                <TableHead>
                    <TableRow>
                        <TableCell className={styles.tableHeader} align="right">Name</TableCell>
                        <TableCell className={styles.tableHeader} align="right">Price</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                {props.data.map((item) => (
                    <TableRow key={item.id}>
                        <TableCell align="right">{item.name}</TableCell>
                        <TableCell align="right">{item.price}</TableCell>
                    </TableRow>
                ))}
                </TableBody>
            </Table>
        </TableContainer>
    )
}

export default ItemsTable;
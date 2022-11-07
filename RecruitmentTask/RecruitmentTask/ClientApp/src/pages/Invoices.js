import { useDispatch, useSelector } from "react-redux";
import { Toolbar, Button } from "@mui/material";
import DatePicker from "../components/DatePicker";
import InvoicesTable from "../components/InvoicesTable";
import { apiActions } from '../store/index';

import { paths } from '../constants'

import styles from './pages-styles.module.css';

const moment = require('moment');
const Invoices = () => {
    let params = {
        from: moment(),
        to: moment().add(30, 'd')
    }

    const dispatch = useDispatch();
    const invoices = useSelector(state => state.api.invoices);

    function paramsHandler(newParams) {
        switch (newParams.type) {
            case "from":
                params.from = newParams.value;
            break;
            case "to":
                params.to = newParams.value;
            break;
            default:
        }
    }

    function fetchInvoicesHandler() {
        fetch(
            `${paths.API_URL}/${paths.INVOICES_URL}?startDate=${params.from.format("YYYY-MM-DD")}&endDate=${params.to.format("YYYY-MM-DD")}`, {
                headers: {
                    'Accept-Language': "pl-PL"
                }})
            .then(respone => {
                return respone.json();
            }).then(data => {
                dispatch(apiActions.getInvoices(data));
        });
    }

    return (
        <section className={styles.invoicesSection}>
            <h1>Invoices page</h1>
            <Toolbar className={styles.invoicesToolbar}>
                <div className={styles.invoicesDatePickerBox}>
                    <DatePicker label="Date From" type="from" onDateChange={paramsHandler} initialValue={params.from} />
                </div>
                <div className={styles.invoicesDatePickerBox}>
                    <DatePicker label="Date To" type="to" onDateChange={paramsHandler} initialValue={params.to}/>
                </div>
                <Button className={styles.invoicesSearchBtn} variant="contained" onClick={fetchInvoicesHandler}>Search</Button>
            </Toolbar>
            {invoices && <InvoicesTable data={invoices} />}
        </section>
    )
}

export default Invoices;
import { Link } from "react-router-dom";

const Invoices = () => {
    return (
        <section>
            <h1>Invoices page</h1>
            <ul>
                <li>
                    <Link to="/invoices/invoice1">Invoice 1</Link>
                </li>
                <li>
                    <Link to="/invoices/invoice2">Invoice 2</Link>
                </li>
                <li>
                    <Link to="/invoices/invoice3">Invoice 3</Link>
                </li>
            </ul>
        </section>
    )
}

export default Invoices;
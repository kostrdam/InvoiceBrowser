import { useParams } from 'react-router-dom';

const InvoiceDetails = () => {
    const params = useParams();

    return (
        <section>
            <h1>Invoice details</h1>
            <p>{params.invoiceId}</p>
        </section>
    )
}

export default InvoiceDetails;
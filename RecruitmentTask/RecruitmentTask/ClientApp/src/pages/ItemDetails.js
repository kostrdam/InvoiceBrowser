import { useParams } from 'react-router-dom';

const ItemDetails = () => {
    const params = useParams();

    return (
        <section>
            <h1>Item details</h1>
            <p>{params.itemId}</p>
        </section>
    )
}

export default ItemDetails;
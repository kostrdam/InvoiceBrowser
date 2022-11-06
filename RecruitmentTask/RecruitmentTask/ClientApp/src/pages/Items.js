import { useEffect } from "react";
import ItemsTable from "../components/ItemsTable";
import { useDispatch, useSelector } from "react-redux";

import { apiActions } from '../store/index';

import { paths } from '../constants';

const Items = () => {
    // const [items, setItems] = useState([]);
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

    return (
        <section>
            <h1>Items page</h1>
            <ItemsTable data={items} />
        </section>
    )
}

export default Items;
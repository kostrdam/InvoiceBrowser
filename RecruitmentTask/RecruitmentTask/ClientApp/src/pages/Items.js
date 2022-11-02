import { Link } from 'react-router-dom';

const Items = () => {
    return (
        <section>
            <h1>Items page</h1>
            <ul>
                <li>
                    <Link to='/items/item1'>Item1</Link>
                </li>
                <li>
                    <Link to='/items/item2'>Item2</Link>
                </li>
                <li>
                    <Link to='/items/item3'>Item3</Link>
                </li>
            </ul>
        </section>
    )
}

export default Items;
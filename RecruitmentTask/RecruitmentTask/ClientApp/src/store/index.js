import { configureStore } from '@reduxjs/toolkit';
import { createSlice } from '@reduxjs/toolkit';

const initialApiState = {
    invoices: [],
    items: []
}

//remarks: You can mutate state in Slice object. ReduxToolkit handles this!
const apiSlice = createSlice({
    name: 'api',
    initialState: initialApiState,
    reducers: {
        getInvoices(state, action) {
            console.log("STATE BEFORE", state.invoices);
            state.invoices = action.payload;
            console.log("STATE AFTER", state);
        },
        getItems(state, action) {
            state.items = action.payload;
        }
    }
});

export const apiActions = apiSlice.actions;

const store = configureStore({
    reducer: {
        api: apiSlice.reducer
    }
});

export default store;
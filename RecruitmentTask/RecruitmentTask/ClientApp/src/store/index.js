import { configureStore } from '@reduxjs/toolkit';
import { createSlice } from '@reduxjs/toolkit';

const initialState = { 
    invoices: [],
    items: [],
    itemList: []
}

//remarks: You can mutate state in Slice object. ReduxToolkit handles this!
const apiSlice = createSlice({
    name: 'api',
    initialState: initialState,
    reducers: {
        getInvoices(state, action) {
            state.invoices = action.payload
        },
        getItems(state, action) {
            state.items = action.payload
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
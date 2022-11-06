import { LocalizationProvider } from '@mui/x-date-pickers';
import { DesktopDatePicker } from '@mui/x-date-pickers/DesktopDatePicker';
import { AdapterMoment } from '@mui/x-date-pickers/AdapterMoment';
import { TextField } from '@mui/material';
import { useState } from 'react';

const DatePicker = (props) => {
    const [value, setValue] = useState(props.initialValue);

    function changeDateHandler(newValue) {
        setValue(newValue);
        if (props.hasOwnProperty('onDateChange')) {
            props.onDateChange({type: props.type, value: newValue});
        }
    }

    return (
        <LocalizationProvider dateAdapter={AdapterMoment}>
            <DesktopDatePicker
                label={props.label}
                format="DD/MM/YYYY"
                inputRef={props.inputRef}
                value={value}
                onChange={(newValue) => {changeDateHandler(newValue)}}
                renderInput={(params) => <TextField {...params} />}
            />
      </LocalizationProvider>
    )
}

export default DatePicker;
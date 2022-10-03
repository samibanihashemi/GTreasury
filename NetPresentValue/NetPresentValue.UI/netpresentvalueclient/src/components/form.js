import React, { useState } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import "../bootstrap/css/bootstrap.css";
import CalculationResult from './calculations';
import axios from "axios";

export default function DataEntryForm() {
    const [cashValues, setCashValues] = useState("");
    const [lowBoundDiscRate, setLowBoundDiscRate] = useState(1);
    const [upBoundDiscRate, setUpBoundDiscRate] = useState(20);
    const [discRateIncrement, setDiscRateIncrement] = useState(2);
    const [calculatedValues, setCalculatedValues] = useState([]);
    const [formErrors, setFormErrors] = useState({
        apiError: "",
        cashValuesError: "",
        lowBoundDiscRateError: "",
        upBoundDiscRateError: "",
        discRateIncrementError: ""
        });

    const callCalculate = () => {
        fetchPost();
    }

    const fetchPost = async () => {
        try {
            const apiParamsModel = JSON.stringify({
                cashValues: cashValues,
                lowBoundDiscRate: lowBoundDiscRate,
                upBoundDiscRate: upBoundDiscRate,
                discRateIncrement: discRateIncrement
            });
            let response = await axios.post('/api/calculate', apiParamsModel, {
                headers: { 'Content-Type': 'application/json' }
            })
            setCalculatedValues(response.data);
        } catch (error) {
            setFormErrors({
                ...formErrors, apiError: error.message
            });
        }
    };

    const validateCashValues = (value) => {
        const re = /^[0-9.,]*$/;
        if (re.test(value)) {
            setFormErrors({
                ...formErrors, cashValuesError: ""
            })
            return true;
        }
        else {
            setFormErrors({
                ...formErrors, cashValuesError: "Invalid cash values"
            })
            return false;
        }
    }

    const validateLowBoundDiscRate = (param) => {
        let value = Number(param)
        if (value <= 0 || value > upBoundDiscRate) {
            setFormErrors({
                ...formErrors, lowBoundDiscRateError: "Low bould values must be greater than 0 and less than the upper bound"
            })
            return false;
        }
        else {
            setFormErrors({
                ...formErrors, lowBoundDiscRateError: ""
            })
            return true;
        }
    }

    const validateUpBoundDiscRate = (param) => {
        let value = Number(param)
        if (value <= 0 || value < lowBoundDiscRate) {
            setFormErrors({
                ...formErrors, upBoundDiscRateError: "Upper bould values must be greater than 0 and greater than the lower bound"
            })
            return false;
        }
        else {
            setFormErrors({
                ...formErrors, upBoundDiscRateError: ""
            })
            return true;
        }
    }

    const validateDiscRateIncrement = (param) => {
        let value = Number(param)
        if (value <= 0) {
            setFormErrors({
                ...formErrors, discRateIncrementError: "Rate increment values must be greater than 0"
            })
            return false;
        }
        else {
            setFormErrors({
                ...formErrors, discRateIncrementError: ""
            })
            return true;
        }
    }

    const divStyle = {
        overflowX: 'scroll',
        border: '1px solid',
        width: '50%',
        hight: '100%',
        float: 'left',
        position: 'relative',
        padding: '50px'
    };

    return (
        <div style={divStyle}>
            <h4>Net Present Values</h4>
            {formErrors.apiError && (
                <p className="text-danger">{formErrors.apiError}</p>
            )}
            <Form>
                <Form.Group>
                    <Form.Label>Enter the cash flows separated by comma:</Form.Label>
                    <Form.Control
                        as="textarea" rows="3"
                        type="text"
                        placeholder="cash flows separated by comma"
                        onChange={e => validateCashValues(e.target.value) ? setCashValues(e.target.value) : null}
                        value={cashValues}
                    />
                    {formErrors.cashValuesError && (
                        <p className="text-danger">{formErrors.cashValuesError}</p>
                    )}
                </Form.Group>
                <Form.Group>
                    <Form.Label>Lower Bound Discount Rate:</Form.Label>
                    <Form.Control type="number"
                        placeholder="Lower Bound Discount Rate"
                        onChange={e => validateLowBoundDiscRate(e.target.value) ? setLowBoundDiscRate(Number(e.target.value)) : null}
                        value={lowBoundDiscRate}
                    />
                    {formErrors.lowBoundDiscRateError && (
                        <p className="text-danger">{formErrors.lowBoundDiscRateError}</p>
                    )}
                </Form.Group>
                <Form.Group>
                    <Form.Label>Upper Bound Discount Rate:</Form.Label>
                    <Form.Control type="number"
                        placeholder="Upper Bound Discount Rate"
                        onChange={e => validateUpBoundDiscRate(e.target.value) ? setUpBoundDiscRate(Number(e.target.value)) : null}
                        value={upBoundDiscRate}
                    />
                    {formErrors.upBoundDiscRateError && (
                        <p className="text-danger">{formErrors.upBoundDiscRateError}</p>
                    )}
                </Form.Group>
                <Form.Group>
                    <Form.Label>Discount Rate Increment:</Form.Label>
                    <Form.Control type="number"
                        placeholder="Discount Rate Increment"
                        onChange={e => validateDiscRateIncrement(e.target.value) ? setDiscRateIncrement(Number(e.target.value)) : null}
                        value={discRateIncrement}
                    />
                    {formErrors.discRateIncrementError && (
                        <p className="text-danger">{formErrors.discRateIncrementError}</p>
                    )}
                </Form.Group>
                <Button variant="primary" onClick={callCalculate}>
                    Click here to submit form
                </Button>
            </Form>
            <p>
                <h4>Calculted results</h4>
            </p>
            <div>
                {calculatedValues.length > 0 ?
                    <CalculationResult calculatedValues={calculatedValues} /> :
                    null}
            </div>
        </div>
    );
}
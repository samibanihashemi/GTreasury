import Table from 'react-bootstrap/Table';

function CalculationResult(props) {
    return (
        <div>
            <Table responsive="sm">
                <thead>
                        <tr key={0}>
                        {Object.keys(props.calculatedValues[0]).map((val) => (
                                <th>{val}</th>
                            ))}
                        </tr>
                </thead>
                <tbody>
                    {props.calculatedValues.map((item) => (
                        <tr key={item.id}>
                            {Object.values(item).map((val) => (
                                <td>{val}</td>
                            ))}
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>
    );
}

export default CalculationResult;
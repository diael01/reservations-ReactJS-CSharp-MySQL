import React, { Component } from 'react';
import axios from "axios";
import { Col, Table, Row } from 'react-bootstrap';

export class Facilities extends Component {   

    static renderFacilities(facilities) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Address</th>
                    </tr>
                </thead>
                <tbody>
                    {facilities.map(facilities =>
                        <tr key={facilities.name}>
                            <td>{facilities.address}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    constructor(props) {
        super(props);
        this.state = { facilities: [], loading: true };

        axios
            .get(`http://localhost:50325/api/facilities/GetFacilities`)
            .then(response => {
                this.setState({
                    facilities: response.data,
                    loading: false
                });
            });
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Facilities.renderFacilities(this.state.facilities);

        return (
            <div>
                <h1>Facilities</h1>
                <p>This component is fetching facilities from the server.</p>               
                    {contents}               
            </div>
        );
    }
}

 

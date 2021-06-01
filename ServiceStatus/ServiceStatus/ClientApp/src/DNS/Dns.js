import React, { Component } from 'react';
import { useHistory } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { store } from 'react-notifications-component';
import 'react-notifications-component/dist/theme.css';
import 'animate.css';


export class Dns extends Component {
    static displayName = Dns.name;


    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };

        fetch('Dns/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
        console.log(this.state.forecasts);
    }

    

    render() {

        //let contents = this.renderForecastsTable(this.state.forecasts);

        
        return (
            <div>
                <table className='table table-striped variant= "dark"' >
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.forecasts.map(forecast => {
                            console.log(forecast);
                            return <tr key={forecast.name}>
                                <td>{forecast.name}</td>
                                <td>{forecast.status}</td>
                                
                            </tr>
                        })}
                    </tbody>
                </table>
            </div>
        );
    }

}


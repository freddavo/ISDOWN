import React, { Component } from 'react';
import { useHistory } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';

export class Historic extends Component {
    static displayName = Historic.name;


    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true, nomeServico: props.location.props.state[0] };
        console.log("Nome Serviço - ", props.location.props.state);
        fetch('Historic/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false, nomeServico: props.location.props.state[0] });
            });

        /**fetch('Service/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });*/
        console.log(this.state.forecasts);
    }

    render() {
        //let contents = this.renderForecastsTable(this.state.forecasts);
     
        return (
            <div>
                <table className='table table-striped variant= "dark"' >
                    <thead>

                        <tr>
                            <th>Data</th>
                            <th>Serviço</th>
                            <th>Falha</th>      
                        </tr>
                    </thead>
                    <tbody>


                        {
                            
                            this.state.forecasts.map(forecast => {
                            console.log(forecast);
                            if (this.state.nomeServico == forecast.nomeServico) {
                                return <tr key={forecast.dataFalha, forecast.nomeServico}>

                                    <td>{forecast.dataFalha}</td>
                                    <td>{this.state.nomeServico}</td>
                                    <td>{forecast.falha}</td>
                                </tr>
                            }
                        })}
                    </tbody>
                </table>
            </div>
        );
    }

}


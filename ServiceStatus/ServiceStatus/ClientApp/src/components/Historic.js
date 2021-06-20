import React, { Component } from 'react';
import { useHistory } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import {
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper,
    Avatar,
    Grid,
    Typography,
    TablePagination,
    TableFooter
} from '@material-ui/core';

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
            <TableContainer component={Paper} 

                style={{
                    borderRadius: 15,
                    margin: '10px 10px',
                    maxWidth: 1425
                }}> 
                <Table 
                    aria-label="simple table"
                    style={{ minWidth: 650 }}>
                    <TableHead>
                        <TableRow>
                            <TableCell style={{
                                fontWeight: 'bold'
                            }} >Date</TableCell>
                            <TableCell  style={{
                                fontWeight: 'bold'
                            }}>Service</TableCell>
                           
                            <TableCell  style={{
                                fontWeight: 'bold'
                            }}></TableCell>

                        </TableRow>
                    </TableHead>
                    <TableBody>


                        {
                            
                            this.state.forecasts.map(forecast => {
                            console.log(forecast);
                            if (this.state.nomeServico == forecast.nomeServico) {
                                return <tr key={forecast.dataFalha, forecast.nomeServico}>

                                    <TableCell>
                                        <Typography>
                                            {forecast.dataFalha}
                                        </Typography>
                                    </TableCell>
                                    <TableCell>
                                        <Typography>
                                            {this.state.nomeServico}
                                        </Typography>
                                </TableCell>
                                    
                                </tr>
                            }
                        })}
                    </TableBody>
                </Table>
            </ TableContainer>
        );
    }

}


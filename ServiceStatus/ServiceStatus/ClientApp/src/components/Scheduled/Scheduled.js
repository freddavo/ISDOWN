import React, { Component } from 'react';
import { useHistory } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { store } from 'react-notifications-component';
import 'react-notifications-component/dist/theme.css';
import 'animate.css';
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



export class Scheduled extends Component {
    static displayName = Scheduled.name;


    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };

        fetch('Manutencao/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false, nomeServico: props.location.props.state[0]  });
            });
        console.log(this.state.forecasts);
    }



    render() {

        //let contents = this.renderForecastsTable(this.state.forecasts);

        const useStyles = makeStyles((theme) => ({
            table: {
                minWidth: 650,
            },
            tableContainer: {
                borderRadius: 15,
                margin: '10px 10px',
                maxWidth: 950
            },
            tableHeaderCell: {
                fontWeight: 'bold',
                backgroundColor: theme.palette.primary.dark,
                color: theme.palette.getContrastText(theme.palette.primary.dark)
            },
            avatar: {
                backgroundColor: theme.palette.primary.light,
                color: theme.palette.getContrastText(theme.palette.primary.light)
            },
            name: {
                fontWeight: 'bold',
                color: theme.palette.secondary.dark,
                padding: '10px 10px'
            },
            status: {
                fontWeight: 'bold',
                fontSize: '0.75rem',
                color: 'white',
                backgroundColor: 'grey',
                borderRadius: 8,
                padding: '3px 10px',
                display: 'inline-block'
            }
        }));

        return (

            <TableContainer component={Paper} className={useStyles.tableContainer}

                style={{
                    borderRadius: 15,
                    margin: '10px 10px',
                    maxWidth: 1400
                }}>
                <Table className={useStyles.table}
                    aria-label="simple table"
                    style={{ minWidth: 650 }}>
                    <TableHead>
                        <TableRow>
                            <TableCell className={useStyles.tableHeaderCell}
                                style={{
                                    fontWeight: 'bold'
                                }} >Service Name</TableCell>
                            <TableCell className={useStyles.tableHeaderCell}
                                style={{
                                    fontWeight: 'bold'
                                }}>Scheduled Maintenances </TableCell>

                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {this.state.forecasts.map(forecast => {
                            console.log(forecast);
                            if (this.state.nomeServico == forecast.serviceName) {
                                return <tr key={forecast.serviceName}>
                                    <TableCell>
                                        <Typography>
                                            {forecast.serviceName}
                                        </Typography>
                                    </TableCell>
                                    <TableCell>
                                        {forecast.dataManutencao}
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


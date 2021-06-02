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
                    maxWidth: 1425
                }}>
                <Table className={useStyles.table}
                    aria-label="simple table"
                    style={{ minWidth: 650 }}>
                    <TableHead>
                        <TableRow>
                            <TableCell className={useStyles.tableHeaderCell}
                                style={{
                                    fontWeight: 'bold'
                                }} >Name</TableCell>
                            <TableCell className={useStyles.tableHeaderCell}
                                style={{
                                    fontWeight: 'bold'
                                }}>Status</TableCell>

                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {this.state.forecasts.map(forecast => {
                            console.log(forecast);
                            return <tr key={forecast.name}>
                                <TableCell>
                                    <Typography>
                                        {forecast.name}
                                    </Typography>
                                </TableCell>
                                <TableCell> <Typography className={useStyles.status}
                                    style={{
                                        fontWeight: 'bold',
                                        fontSize: '0.75rem',
                                        color: 'white',
                                        backgroundColor: 'grey',
                                        borderRadius: 8,
                                        padding: '3px 10px',
                                        display: 'inline-block',
                                        backgroundColor:
                                            ((forecast.status === 'Success' && 'green') ||
                                                (forecast.status === 'Uninitialized' && 'red'))
                                    }}
                                >{forecast.status}</Typography>
                                </TableCell>
                            </tr>
                        })}
                    </TableBody>
                </Table>
            </ TableContainer>

        );
    }

}


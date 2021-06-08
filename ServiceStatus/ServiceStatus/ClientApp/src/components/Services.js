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



export class Services extends Component {
    static displayName = Services.name;
    
  
    constructor(props) {
        super(props);
        this.state = {
            forecasts: [],
            loading: true,
            value: "None"
        };
     

        fetch('Service/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
    }


    render() {

        //let contents = this.renderForecastsTable(this.state.forecasts);

        const handleOnClickDefault = () => {
            store.addNotification({
                title: "Subscrição",
                message: "Notificações ativadas com sucesso!",
                type: "success",
                container: "center",
                insert: "top"
            })
        }

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
                            <TableCell className={useStyles.tableHeaderCell} style={{
                                fontWeight: 'bold'}} >Services</TableCell>
                            <TableCell className={useStyles.tableHeaderCell} style={{
                                fontWeight: 'bold'
                            }}>Path</TableCell>
                            <TableCell className={useStyles.tableHeaderCell} style={{
                                fontWeight: 'bold'
                            }}>Status</TableCell>
                            <TableCell className={useStyles.tableHeaderCell} style={{
                                fontWeight: 'bold'
                            }}></TableCell>




                            <TableCell className={useStyles.tableHeaderCell} style={{
                                fontWeight: 'bold'
                            }}></TableCell>
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
                                
                                <TableCell> <Typography>{forecast.path}</Typography></TableCell>
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
                                            ((forecast.health_State === 'Success' && 'green') ||
                                                (forecast.health_State === 'Error' && 'red'))
                                    }}
                                >{forecast.health_State}</Typography>
                                </TableCell>
                                <TableCell> <Typography><NavLink exact activeClassName="active"
                                    to={{
                                        pathname: "/Historic",
                                        props: {
                                            state: [
                                                forecast.name]
                                        }
                                    }}> Historic </NavLink></Typography></TableCell>

                                <TableCell> <Typography><button onClick={handleOnClickDefault}>
                                    Subscribe </button> </Typography></TableCell>
                            </tr>
                        })}
                    </TableBody>
                </Table>
                    
            </ TableContainer>
        );
    }

}


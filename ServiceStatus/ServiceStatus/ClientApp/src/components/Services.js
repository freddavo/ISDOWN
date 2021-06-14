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
                            <TableCell  style={{
                                fontWeight: 'bold'}} >Services</TableCell>
                            <TableCell  style={{
                                fontWeight: 'bold'
                            }}>Path</TableCell>
                            <TableCell  style={{
                                fontWeight: 'bold'
                            }}>Status</TableCell>
                            <TableCell style={{
                                fontWeight: 'bold'
                            }}>Time</TableCell>
                            <TableCell style={{
                                fontWeight: 'bold'
                            }}>Maintenance</TableCell>
                            <TableCell style={{
                                fontWeight: 'bold'
                            }}></TableCell>




                            <TableCell style={{
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
                                <TableCell> <Typography 
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
                                <TableCell> <Typography>{forecast.time}</Typography></TableCell>
                                <TableCell> <Typography>{forecast.Maintenance}</Typography></TableCell>
                                <TableCell> <Typography ><NavLink exact activeClassName="active"
                                    to={{
                                        pathname: "/Historic",
                                        props: {
                                            state: [
                                                forecast.name]
                                        }
                                    }}
                                style={{
                                    fontWeight: 'bold',
                                    fontSize: '0.75rem',
                                    color: 'white',
                                    backgroundColor: 'grey',
                                    borderRadius: 8,
                                    padding: '3px 10px',
                                    display: 'inline-block',
                                    backgroundColor:'gray'
                                }}                                > History </NavLink></Typography></TableCell>

                                <TableCell> <Typography><button onClick={handleOnClickDefault} style={{
                                    fontWeight: 'bold',
                                    fontSize: '0.75rem',
                                    color: 'white',
                                    backgroundColor: 'grey',
                                    borderRadius: 8,
                                    padding: '3px 10px',
                                    display: 'inline-block',
                                    backgroundColor: 'black'
                                }}    >
                                    Subscribe </button> </Typography></TableCell>
                            </tr>
                        })}
                    </TableBody>
                </Table>
                    
            </ TableContainer>
        );
    }

}


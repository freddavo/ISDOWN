import React, { Component } from 'react';
import { useHistory } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { store } from 'react-notifications-component';
import 'react-notifications-component/dist/theme.css';
import 'animate.css';
import { makeStyles } from '@material-ui/core/styles';
import axios from 'axios';
import { Row } from 'reactstrap';
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
    TableFooter,
    FormControl,
    InputLabel
} from '@material-ui/core';

export class Maintenance extends Component {
    static displayName = Maintenance.name;
    
    searchArray = [];

    constructor(props) {
        super(props);
        this.state = {
            forecasts: [],
            loading: true,
            value: "None",
            name: '',
            maintenance: '',
            nameDelete: '',
            maintenanceDelete: '',
            delete: ''
        };
     

        fetch('Service/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
                this.searchArray = data;
            });
    }

    changeHandler = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    onChangeHandler(e) {
        let newArray = this.searchArray.filter((d) => {
            let searchValue = d.name.toLowerCase();
            return searchValue.indexOf(e.target.value) !== -1;
        });
        this.setState({ forecasts: newArray })
    }

    submitHandler = e => {
        e.preventDefault()
        this.setState({ delete : "" })
        console.log(this.state)
        axios.post('https://servicestatus-api.azurewebsites.net/api/service', this.state)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })
    }

    /*deleteHandler = e => {
        e.preventDefault()
        this.state.delete = "s"
        console.log(this.state)
        axios.post('https://servicestatus-api.azurewebsites.net/api/service', this.state)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })
    }*/

    deleteHandler = e => {
        e.preventDefault()
        this.setState({ delete: "" })
        console.log(this.state)
        axios.delete('https://servicestatus-api.azurewebsites.net/api/service/' + this.state.nameDelete.toLowerCase)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })
    }





    render() {

        //let contents = this.renderForecastsTable(this.state.forecasts);

        const { name, maintenance, nameDelete, maintenanceDelete } = this.state

        return (
            <>

                <div style={{ margin: 30 }}>
                    <label>
                        <input type="text" onChange={this.onChangeHandler.bind(this)} placeholder="Search for..." />
                    </label>
                </div>

             <TableContainer style={{
                    borderRadius: 15,
                    margin: '10px 10px',
                    maxWidth: 1300,
                    backgroundColor:'#EBECEC'
                }}>
                    <Table aria-label="simple table"
                        style={{ minWidth: 20 }}
                    >
                        <TableHead>
                           
                                <TableCell
                                      
                                >
                                <Typography style={{
                                    fontWeight: 'bold'
                                }}>
                                    Name      &nbsp;&nbsp; &nbsp;&nbsp;
                                    &nbsp;&nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    
                                    Maintenance                                           
                                </Typography>
                                </TableCell>
                                    <TableCell></TableCell>
                                   
                            
                           

                        </TableHead>

                            <TableBody>
                            <TableCell>
                                
                                    <form onSubmit={this.submitHandler}>
                                    
                                    <input type="text" name="name" value={name}
                                        onChange={this.changeHandler}
                                        style={{ minWidth: 400, borderRadius: 5 }} />
                                            
                                    <input type="text" name="maintenance" value={maintenance}
                                        onChange={this.changeHandler}
                                        style={{ minWidth: 400, borderRadius: 5, marginLeft: '5rem' }} />

                                    

                                            <button type="submit"
                                                style={{
                                                    fontWeight: 'bold',
                                                    fontSize: '0.75rem',
                                                    color: 'white',
                                                    backgroundColor: 'grey',
                                                    borderRadius: 8,
                                                    padding: '3px 10px',
                                                    display: 'inline-block',
                                                    backgroundColor: 'black',
                                                    marginLeft: '15rem'
                                                }}> Change
                                            </button>
                                    
                                    </form>


                               

                                
                                </TableCell>
                      
                            </TableBody>
                </Table>
                </TableContainer>


                 <TableContainer style={{
                    borderRadius: 15,
                    margin: '10px 10px',
                    maxWidth: 1300,
                    backgroundColor:'#EBECEC'
                }}>
                    <Table aria-label="simple table"
                        style={{ minWidth: 20 }}
                    >
                        <TableHead>
                           
                                <TableCell
                                      
                                >
                                <Typography style={{
                                    fontWeight: 'bold'
                                }}>
                                    Name      &nbsp;&nbsp; &nbsp;&nbsp;
                                    &nbsp;&nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    
                                    Maintenance                                           
                                </Typography>
                                </TableCell>
                                    <TableCell></TableCell>
                                  
                        </TableHead>

                            <TableBody>
                            <TableCell>
                                
                                <form onSubmit={this.deleteHandler}>

                                    <input type="text" name="nameDelete" value={nameDelete}
                                        onChange={this.changeHandler}
                                        style={{ minWidth: 400, borderRadius: 5 }} />

                                   


                                    <button type="submit"
                                        style={{
                                            fontWeight: 'bold',
                                            fontSize: '0.75rem',
                                            color: 'white',
                                            backgroundColor: 'grey',
                                            borderRadius: 8,
                                            padding: '3px 10px',
                                            display: 'inline-block',
                                            backgroundColor: 'black',
                                            marginLeft: '15rem'
                                        }}> Delete
                                            </button>

                                </form> 
                                </TableCell>
                      
                            </TableBody>
                </Table>
                </TableContainer>

              
               
            <TableContainer component={Paper} 
                style={{
                borderRadius: 15,
                    margin: '10px 10px',
                    maxWidth: 1385
                }}> 
                <Table 
                    aria-label="simple table"
                    style={{ minWidth: 650 }}>
                    <TableHead>
                        <TableRow>
                            <TableCell  style={{
                                fontWeight: 'bold'}} >Services</TableCell> 
                            

                            <TableCell style={{
                                fontWeight: 'bold'
                            }}>Status</TableCell>
                            
                        </TableRow>
                    </TableHead>                 
                                                                          
                    
                    <TableBody>
                        {this.state.forecasts.map(forecast => {
                           // console.log(forecast);
                            return <tr key={forecast.name}>
                                <TableCell>
                                    <Typography>
                                        {forecast.name}
                                    </Typography>
                                </TableCell>

                                
 
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
                                            ((forecast.healthState === 'Success' && 'green') ||
                                                (forecast.healthState === 'Error' && 'red'))
                                    }}
                                >{forecast.healthState}</Typography>
                                </TableCell>

                            </tr>
                        })}
                    </TableBody>
                </Table>
                    
                </ TableContainer>
            </>
        );
    }

}


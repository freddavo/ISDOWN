import React, { Component } from 'react';
import { useHistory } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { store } from 'react-notifications-component';
import 'react-notifications-component/dist/theme.css';
import 'animate.css';
import { makeStyles } from '@material-ui/core/styles';
import axios from 'axios';
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



export class Time extends Component {
    static displayName = Time.name;


    constructor(props) {
        super(props);
        this.state = {
            forecasts: [],
            loading: true,
            value: "None",
            name: '',
            tempo: '',
        };


        fetch('Admin/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
    }

    changeHandler = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    submitHandler = e => {
        e.preventDefault()
        console.log(this.state)
        axios.post('https://localhost:6001/api/person/v1', this.state)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })
    }

    element = (idName) => {
        console.log(idName);
        var idd = document.getElementById(idName);

        if (idd !== null) {
            var text = idd.value;
            console.log(text);
        }
    }

    render() {

        //let contents = this.renderForecastsTable(this.state.forecasts);

        const { name, tempo } = this.state

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

         
           <>
                <TableContainer style={{
                    borderRadius: 15,
                    margin: '10px 10px',
                    maxWidth: 1300,
                    backgroundColor: '#EBECEC'
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
                                    Name       &nbsp;&nbsp; &nbsp;&nbsp;
                                    &nbsp;&nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    Scheduled Time
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

                                    <input type="text" name="tempo" value={tempo}
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


            <TableContainer component={Paper}
                style={{
                    borderRadius: 15,
                    margin: '10px 10px',
                    maxWidth: 1385
                }}>
                <Table aria-label="simple table"
                    style={{ minWidth: 650 }}>
                    <TableHead>
                        <TableRow>
                            <TableCell style={{
                                fontWeight: 'bold'
                            }} >Services</TableCell>

                            <TableCell style={{
                                fontWeight: 'bold'
                            }}>Status</TableCell>

                        </TableRow>
                    </TableHead>
                    <form onSubmit={this.submitHandler}>
                        <input type="text" name="name" value={name} onChange={this.changeHandler} />
                        <input type="text" name="tempo" value={tempo} onChange={this.changeHandler} />
                        <button type="submit"> Change </button>
                    </form>
                    <TableBody>
                        {this.state.forecasts.map(forecast => {
                            console.log(forecast);
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


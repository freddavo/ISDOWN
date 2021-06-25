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

    searchArray = [];
  
    constructor(props) {
        super(props);
        this.state = {
            forecasts: [],
            loading: true,
            value: "None"
        };
    }

    componentDidMount() {
        
        fetch('Service/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
                this.searchArray = data;

                return (fetch('Manutencao/Index'));
            })
            .then(response => response.json())
            .then(data => {
                console.log(this.state.forecasts.length);
                console.log(this.state.forecasts[parseInt('0')]);
                for (var s in this.state.forecasts) {
                    var servico = this.state.forecasts[parseInt(s)];
                    for (var m in data) {
                        var manutencao = data[parseInt(m)];
                        if (servico.name == manutencao.serviceName) {
                            if (servico.hasOwnProperty("nextManutencao")) {
                                if (Date.parse(servico.nextManutencao) > Date.parse(manutencao.dataManutencao)) {
                                    this.state.forecasts[parseInt(s)]["nextManutencao"] = manutencao.dataManutencao;
                                }
                            }
                            else {
                                this.state.forecasts[parseInt(s)]["nextManutencao"] = manutencao.dataManutencao;
                            }
                            console.log(this.state.forecasts[parseInt(s)]);
                        }
                    }
                }

                this.setState({ forecasts: this.state.forecasts, loading: false });
                this.searchArray = this.state.forecasts;
            });
    }
    

    dateBiggerThan(date1, date2) {

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

    render() {

        //let contents = this.renderForecastsTable(this.state.forecasts);


        return (
            <div>
                <div style={{ margin: 30 }}>
                    <label>
                        <input type="text" onChange={this.onChangeHandler.bind(this)} placeholder="Search for..." />
                    </label>
                </div>


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
                            {this.state.forecasts.map((forecast, index)=> {
                                console.log(forecast);
                                return <tr key={forecast.name, index}>
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
                                                ((forecast.healthState === 'Success' && 'green') ||
                                                    (forecast.healthState === 'Error' && 'red'))
                                        }}
                                    >{forecast.healthState}</Typography>
                                    </TableCell>
                                    <TableCell> <Typography>{forecast.tempo}</Typography></TableCell>

                                    <TableCell>
                                        <Typography >
                                            {forecast.nextManutencao} 
                                            <NavLink exact activeClassName="active"
                                                to={{
                                                    pathname: "/Scheduled",
                                                    props: {
                                                        state: [
                                                            forecast.serviceName]
                                                    }
                                                }}
                                                style={{
                                                    fontWeight: 'bold',
                                                    fontSize: '0.75rem',
                                                    color: 'white',
                                                    backgroundColor: 'blue',
                                                    borderRadius: 8,
                                                    padding: '3px 10px',
                                                    display: 'inline-block',
                                                    marginLeft: 5,
                                                    textDecoration: 'none'

                                                }}                               >
                                        Schedule</NavLink>
                                    </Typography>
                                    </TableCell>
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
                                        textDecoration: 'none',
                                        borderRadius: 8,
                                        padding: '3px 10px',
                                        display: 'inline-block',
                                        backgroundColor:'gray'
                                        }}                                >
                                        History </NavLink></Typography></TableCell>

                                </tr>
                            })}
                        </TableBody>
                    </Table>
                    
                    </ TableContainer>
                </div>
        );
    }

}


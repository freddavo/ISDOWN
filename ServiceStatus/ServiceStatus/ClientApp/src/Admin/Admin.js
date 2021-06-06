import React, { Component } from 'react';
import { useHistory } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { store } from 'react-notifications-component';
import 'react-notifications-component/dist/theme.css';
import 'animate.css';
import { makeStyles } from '@material-ui/core/styles';
import ReactDOM from "react-dom";
import { useState } from 'react';

export class Admin extends Component {
    static displayName = Admin.name;


    constructor(props) {
        super(props);
        this.state = {
            forecasts: [],
            loading: true,
            value: "Time of resolution for all services is <number> minute(s)",
            isInEditMode: false,
            value1: "The \"service name\" has a scheduled Maintenance on <dd/mm/yyyy>",
            isInEditMode1: false,
        };

 


        fetch('Admin/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({
                    forecasts: data,
                    loading: false
                });
            });
    }

    changeEditMode = () => {
        this.setState({
            isInEditMode: !this.state.isInEditMode
        })
    }

    renderEditView = () => {
        return <div>
            <input
                type="text"
                defaultValue={this.state.value}
                ref="theTextInput"
            />
            <button onClick={this.updateComponentValue}> OK </button>
            <button onClick={this.changeEditMode}> X </button>
        </div>
    }

    renderDefaultView = () => {
        return <div onDoubleClick={this.changeEditMode}>
            {this.state.value}
        </div>
    }

    updateComponentValue = () => {
        this.setState({
            isInEditMode: false,
            value: this.refs.theTextInput.value
        })
    }


    //_________________________________________________________________________

    changeEditMode1 = () => {
        this.setState({
            isInEditMode1: !this.state.isInEditMode1
        })
    }

    renderEditView1 = () => {
        return <div>
            <input
                type="text"
                defaultValue={this.state.value1}
                ref="theTextInput1"
            />
            <button onClick={this.updateComponentValue1}> OK </button>
            <button onClick={this.changeEditMode1}> X </button>
        </div>
    }

    renderDefaultView1 = () => {
        return <div onDoubleClick={this.changeEditMode1}>
            {this.state.value1}
        </div>
    }

    updateComponentValue1 = () => {
        this.setState({
            isInEditMode1: false,
            value1: this.refs.theTextInput1.value
        })
    }


    renderTable() {
        return (
            <div>
                <table className='table table-striped variant= "dark"'>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Health State</th>

                        </tr>
                    </thead>
                    <tbody>
                        {this.state.forecasts.map(forecast => {
                            console.log(forecast);
                            return <tr key={forecast.name}>
                                <td>{forecast.name}</td>
                                <td>{forecast.health_State}</td>
                                
                            </tr>
                        })}
                    </tbody>
                </table>
            </div>
        )
    }

    render() {
        return (
            <div>
                {this.state.isInEditMode1 ? this.renderEditView1() : this.renderDefaultView1()}
                {this.state.isInEditMode ? this.renderEditView() : this.renderDefaultView()}
                {this.renderTable()}
            </div>


        )
    }

}
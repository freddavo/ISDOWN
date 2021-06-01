import React, { Component } from 'react';
import { useHistory } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { store } from 'react-notifications-component';
import 'react-notifications-component/dist/theme.css';
import 'animate.css';


export class Services extends Component {
    static displayName = Services.name;
    
  
    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };

        fetch('Service/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
    }

     onSubmit () {
       const history = useHistory();
       history.push('/Historic');
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
            <div>
                <table className= 'table table-striped variant= "dark"' >
                    <thead>
                        <tr> 
                            <th>Name</th>
                            <th>Health State</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.forecasts.map(forecast => {
                            console.log(forecast);
                            return <tr key={forecast.name}>
                                <td>{forecast.name}</td>
                                <td>{forecast.health_State}</td>
                                <td>{forecast.path}</td>
                                <td><NavLink exact activeClassName="active"
                                    to={{
                                        pathname: "/Historic",
                                        props: {
                                            state: [
                                            forecast.name]
                                        }
                                    }}> Historic </NavLink></td> 
                                <td><button onClick={handleOnClickDefault}>
                                    Subscribe </button> </td>
                            </tr>
                        })}
                    </tbody>
                </table>
            </div>  
        );
    }

}


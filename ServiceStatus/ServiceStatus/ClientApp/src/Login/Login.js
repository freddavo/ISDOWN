import React, { Component } from 'react';
import { useHistory } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { NavLink } from 'react-router-dom';
import { store } from 'react-notifications-component';
import 'react-notifications-component/dist/theme.css';
import 'animate.css';
import { makeStyles } from '@material-ui/core/styles';
import ReactDOM from "react-dom";
import { useState, useContext } from 'react';
import StoreContext from '../components/Store/Context';
import UIButton from '../UI/Button/Button';
import './Login.css'; 


function initialState() {
    return { user: '', password: '' };
}

function login({ user, password }) {
    if (user === 'admin' && password === 'admin') {
        return { token: '1234' };
    }
    return { error: 'Invalid user or password!' };
}

const UserLogin = () => {
    const [values, setValues] = useState(initialState);
    const [error, setError] = useState(null);
    const { setToken } = useContext(StoreContext);
    const history = useHistory();

    function onChange(event) {
        const { value, name } = event.target;

        setValues({
            ...values,
            [name]: value
        });
    }

    function onSubmit(event) {
        event.preventDefault();

        const { token, error } = login(values);

        if (token) {
            setToken(token);
            return history.push('/Admin');
        }

        setError(error);
        setValues(initialState);
    }

    return (
        <div className="user-login">
            <h1 className="user-login__title">Admin</h1>
            <form onSubmit={onSubmit}>
                <div className="user-login__form-control">
                    <label htmlFor="user">User</label>
                    <input
                        id="user"
                        type="text"
                        name="user"
                        onChange={onChange}
                        value={values.user}
                    />
                </div>
                <div className="user-login__form-control">
                    <label htmlFor="password">Password</label>
                    <input
                        id="password"
                        type="password"
                        name="password"
                        onChange={onChange}
                        value={values.password}
                    />
                </div>
                {error && (
                    <div className="user-login__error">{error}</div>
                )}
                <UIButton
                    type="submit"
                    theme="contained-green"
                    className="user-login__submit-button"
                    rounded
                >
                    Login
        </UIButton>
            </form>
        </div>
    );
};

export default UserLogin;
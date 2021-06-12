import React, { useState } from 'react';
import axios from 'axios';
import { Component } from 'react'

export class PostForm extends Component {

    constructor(props) {
        super(props);
        this.state = {
            name: '',
            maintenance: '',
        }
    }

    changeHandler = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    submitHandler = e => {
        e.preventDefault()
        console.log(this.state)
        axios.post('https://localhost:6001/api/time/v1', this.state)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })
    }

    render() {
        const { name, maintenance } = this.state
        return (

            <div>
                <form onSubmit={this.submitHandler }>
                    <input type="text" name="name" value={name} onChange={this.changeHandler} />
                    <input type="text" name="maintenance" value={maintenance} onChange={this.changeHandler} />
                    <button type="submit"> Submit </button>
                </form>
            </div>
        )
    } 
}
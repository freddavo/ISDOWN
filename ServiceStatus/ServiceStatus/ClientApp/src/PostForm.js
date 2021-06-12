import React, { useState } from 'react';
import axios from 'axios';

export class PostForm extends Component { 
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            maintenance: '',
            health: ''
        }
    }

    changeHandler = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    submitHandler = e => {
        e.preventDefault()
        console.log(this.state)
        axios.post('https://localhost:6001/api/service/v1', this.state)
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error)
            })
    }

    render() {
        const { name, maintenance, health } = this.state
        return (

            <div>
                <form onSubmit={this.submitHandler }>
                    <input type="text" value={name} onChange={this.changeHandler} />
                    <input type="text" value={maintenance} onChange={this.changeHandler} />
                    <input type="text" value={health} onChange={this.changeHandler} />
                    <button type="submit"> Submit </button>
                </form>
            </div>
        )
    } 
}

/*
 *
 *import React, { useState } from 'react';
import Axios from 'axios';

function PostForm() {
    const url = "https://localhost:6001/api/person/v1"
    const [data, setData] = useState({
        name: "",
        date: "",
        iduser: "",
    })

    function submit(e) {
        e.preventDefault();
        Axios.post(url, {
            name: data.name,
            date: data.date,
            iduser: parseInt(data.iduser)
        })
            .then(res => {
                console.log(res.data)
            })
    }

    function handle(e) {
        const newdata = { ...data }
        newdata[e.target.id] = e.target.value
        setData(newdata)
        console.log(newdata)
    }


    return (

        <div>
            <form onSubmit={(e) => submit(e)}>
                <input onChange={(e) => handle(e)} id="name" value={data.name} placeholder="name" type="text" />
                <input onChange={(e) => handle(e)} id="date" value={data.date} placeholder="date" type="date" />
                <input onChange={(e) => handle(e)} id="iduser" value={data.iduser} placeholder="iduser" type="number" />
                <button> Submit </button>
            </form>
        </div>
        )
}


export default PostForm;
 * 
 * /
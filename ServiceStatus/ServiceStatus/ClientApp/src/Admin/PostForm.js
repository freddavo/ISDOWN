import React, { useState } from 'react';
import Axios from 'axios';

function PostForm() {
    const url = ""
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
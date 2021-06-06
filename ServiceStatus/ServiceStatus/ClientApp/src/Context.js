
import React, { Component } from 'react';

const ProductContext = React.createContext();

class ProductProvider extends Component {

    constructor(props) {
        super(props);
        this.state = {
            forecasts: [],
            loading: true,
            updateEdit: []
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

    getRecord = (id) => {
        const service = this.state.forecasts.find(item => item.id === id);
        return service;
    }

    onEdit = (id) => {
        const temp = this.state.forecasts;
        const index = temp.indexOf(this.getRecord(id));
        const selectedRecord = temp[index];
        this.setState({
            id: selectedRecord['id'],
            name: selectedRecord['name'],
            health_state: selectedRecord['health_state'],
            resolved: selectedRecord['resolved'],
            time: selectedRecord['time']
        })
    }


    updateValue = (e, test) => {
        if (test === 'name') {
            this.state.name = e.target.value;
        }

        if (test === 'health_state') {
            this.state.health_state = e.target.value;
        }

        if (test === 'resolved') {
            this.state.resolved = e.target.value;
        }

        if (test === 'time') {
            this.state.time = e.target.value;
        }

        const tempArr = [this.state.id, this.state.name, this.state.health_state, this.state.resolved, this.state.time]
        this.setState({
            updateEdit: tempArr
        })
    }


    onSave = (id) => {
        if (id !== '') {
            const SavedRecord = this.state.forecasts;
            const index = SavedRecord.indexOf(this.getRecord(id));
            const Record = SavedRecord[index];
            Record['name'] = this.state.updateEdit[1];
            Record['health_state'] = this.state.valueupdateEdit[2];
            Record['resolved'] = this.state.updateEdit[3];
            Record['time'] = this.state.updateEdit[4];

            this.setState({
                forecasts: [...this.state.forecasts],
                name: "", health_state: "", resolved: "", time: ""
            })
        }
    }

    render() {
        return (
            <div>
                <ProductContext.Provider value={{
                    ...this.state,
                    onEdit: this.onEdit,
                    updateValue: this.updateValue,
                    onSave: this.onSave
                }}>
                    {this.props.children}

                </ProductContext.Provider>
            </div>
        )
    }

}

const ProductConsumer = ProductContext.Consumer;
export { ProductProvider, ProductConsumer }
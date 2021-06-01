import React from 'react';
import './Cards.css';
import CardItem from './CardItem';

function Cards() {
    return (
        <div className='cards'>
            <h1>Check if this Services are Working!</h1>
            <div className='cards__container'>
                <div className='cards__wrapper'>
                    <ul className='cards__items'>
                        <CardItem
                            src='images/Glua.png'
                            text='Check out if Glua is working.'
                            label='Glua'
                            path='/Services'
                        />
                        <CardItem
                            src='images/Glua.png'
                            text='Check out if Glua is working.'
                            label='Glua'
                            path='/Services'
                        />
                        <CardItem
                            src='images/PACO.png'
                            text='Check out if PACO is working.'
                            label='PACO'
                            path='/Services'
                        />
                    </ul>
                    <ul className='cards__items'>
                        <CardItem
                            src='images/Elearning.png'
                            text='Check out if Elearning is working.'
                            label='Elearning'
                            path='/Services'
                        />
                        <CardItem
                            src='images/Codeua.PNG'
                            text='Check out if CodeUA is working'
                            label='CodeUA'
                            path='/Services'
                        />
                    </ul>
                </div>
            </div>
        </div>
    );
}

export default Cards;
import React from 'react';
import CardItemAbout from './CardItemAbout';
import './Cards.css';
import '../../App.css';

export default function CardsLogin() {
    return (
        <div className='cards'>
            <h1 >Management Options</h1>
            <div className='cards__container'>
                <div className='cards__wrapper'>
                    <ul className='cards__items'>
                        
                        <CardItemAbout 
                            src='images/manu.webp'
                            text='Maintenance'
                            label='Options'
                            path='/Maintenance'
                        />
                        <CardItemAbout
                            src='images/maintime.png'
                            text='Scheduled Time'
                            label='Options'
                            path='/Time'
                        />

                    </ul>
                </div>
            </div>
        </div>
    );
}


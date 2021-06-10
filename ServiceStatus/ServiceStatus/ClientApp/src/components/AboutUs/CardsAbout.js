import React from 'react';
import CardItemAbout from './CardItemAbout';
import './Cards.css';
import '../../App.css';

export default function CardsAbout() {
    return (
        <div className='cards'>
            <h1 >Meet Our Team!</h1>
            <div className='cards__container'>
                <div className='cards__wrapper'>
                    <ul className='cards__items'>
                        
                        <CardItemAbout 
                            src='images/eleandrofoto2.jpg'
                            text='Team Manager'
                            label='Eleandro'
                            path='/'
                        />
                        <CardItemAbout
                            src='images/joselindao.jpg'
                            text='React Frontend Developer'
                            label='José Carlos'
                            path='/'
                         />
                        <CardItemAbout
                            src='images/fred.jpg'
                            text='Team Manager'
                            label='Fred Avó'
                            path='/'
                        />
                        <CardItemAbout
                            src='images/Gon.jpg'
                            text='Backend Developer'
                            label='Gonçalo'
                            path='/'
                         />
                    </ul>
                </div>
            </div>
        </div>
    );
}


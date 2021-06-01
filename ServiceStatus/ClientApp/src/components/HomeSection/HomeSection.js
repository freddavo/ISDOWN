import React from 'react';
import '../../App.css';
import { Button } from '../Button/Button';
import { ButtonAbout } from '../Button/ButtonAbout';
import './HomeSection.css';


function HomeSection() {
    return (
        <div className='home-container'>
            <video src="/videos/video-2.mp4" autoPlay loop muted />
            <h1>WANNA CHECK SOMETHING?</h1>
            <div className="home-btns">
                
                <ButtonAbout className='btns'
                buttonStyle='btn--outline'
                buttonSize='btn--large'
                
                >
                    KNOW ABOUT US <i className='fas fa-users' />
                </ButtonAbout>
                 <Button className='btns'
                buttonStyle='btn--primary'
                buttonSize='btn--large'
                >
                    GET STARTED 
                </Button>
            </div>
        </div>
        );
}

export default HomeSection;
import React from 'react';
import '../../App.css';
import CardsAbout from '../AboutUs/CardsAbout';
import Cards from '../Cards/Cards';
import Footer from '../Footer/Footer';
import HomeSection from '../HomeSection/HomeSection';
import { Services } from '../Services';


function Home() {
    return (
        <>
            <HomeSection />
            <Cards />
            <CardsAbout />
            <Footer/>
        </>
    );
}

export default Home;
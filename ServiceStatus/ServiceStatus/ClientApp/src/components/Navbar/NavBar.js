import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { Button } from '../Button/Button';
import './NavBar.css';

function Navbar() {
    const [click, setClick] = useState(false);
    const [button, setButton] = useState(true);

    const handleClick = () => setClick(!click);
    const closeMobileMenu = () => setClick(false);

    const showButton = () => {
        if (window.innerWidth <= 960) {
            setButton(false);

        } else {
            setButton(true);
        }

    };

    useEffect(() => {
        showButton();
    }, []);

    window.addEventListener('resize', showButton);

    return (
        <>
            <nav className="navbar">
                <div className="navbar-container">
                    <Link to="/" className="navbar-logo" onClick={closeMobileMenu}>
                        Service Status UA <i className='fab fa-typo3' />
                    </Link>
                    <div className='menu-icon' onClick={handleClick}>
                        <i className={click ? 'fas fa-times' : 'fas fa-bars'} />
                    </div>
                    <ul className={click ? 'nav-menu active' : 'nav-menu'}>
                        <li className='nav-item'>
                            <Link to='/'
                                className='nav-links'
                                onClick={closeMobileMenu}
                            >
                             Home
                            </Link>
                        </li>
                        <li className='nav-item'>
                            <Link to='/Login'
                                className='nav-links'
                                onClick={closeMobileMenu}
                            >
                                Login
                            </Link>
                        </li>
                        <li className='nav-item'>
                            <Link to='/Dns'
                                className='nav-links'
                                onClick={closeMobileMenu}
                            >
                              DNS
                            </Link>
                        </li>
                        <li className='nav-item'>
                            <Link to='/Services'
                                className='nav-links-mobile'
                                onClick={closeMobileMenu}
                            >
                             Services
                            </Link>
                        </li>
                    </ul>
                    {button && <Button buttonStyle='btn--outline'>Services</Button>}
                </div>
            </nav>
        </>
    );
}

export default Navbar;
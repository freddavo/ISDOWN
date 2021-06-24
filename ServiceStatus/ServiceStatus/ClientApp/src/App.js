import React from 'react';
import './App.css';
import { BrowserRouter as Router, Switch, Route} from
'react-router-dom';
import Navbar from './components/Navbar/NavBar';
import Home from './components/Home/Home';
import { Services } from './components/Services';
import CardsAbout from './components/AboutUs/CardsAbout';
import { Historic } from './components/Historic';
import { Dns } from './DNS/Dns';
import { Admin } from './Admin/Admin';
import Login from './Login/Login';
import StoreProvider from './components/Store/Provider';
import { ProductProvider } from './Context';
import CardsLogin from './components/Login_Options/CardsLogin';
import { Maintenance } from './Admin/Maintenance';
import { Time } from './Admin/Time';
import { PostForm } from './Admin/PostForm';
import { Scheduled } from './components/Scheduled/Scheduled';
//import RoutesPrivate from './components/Routes/Private';
 

function App() {
  return (
    
          <Router>
              <StoreProvider>
              <Navbar />
                        <Switch>
                          <Route path='/' exact component={Home} />
                          <Route path='/Services' component={Services} />
                          <Route path="/CardsAbout" component={CardsAbout}/>
                          <Route path="/Historic" component={Historic} />
                          <Route path="/Dns" component={Dns} />
                          <Route path="/Admin" component={Admin} />
                          <Route path="/Login" component={Login} />
                          <Route path="/CardsLogin" component={CardsLogin} />
                          <Route path="/Maintenance" component={Maintenance} />
                          <Route path="/Time" component={Time} />
                          <Route path="/Scheduled" component={Scheduled} />



                  </Switch>
              </StoreProvider>
        </Router>
     
   );

}

export default App;
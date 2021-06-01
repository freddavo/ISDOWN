import React from 'react';
import './App.css';
import { BrowserRouter as Router, Switch, Route} from
'react-router-dom';
import Navbar from './components/Navbar/NavBar';
import Home from './components/Home/Home';
import { Services } from './components/Services';
import CardsAbout from './components/AboutUs/CardsAbout';
import { Historic } from './components/Historic';




function App() {
  return (
     <>
        <Router>
        
         <Navbar/>
                <Switch>
                  <Route path='/' exact component={Home} />
                  <Route path='/Services' component={Services} />
                  <Route path="/CardsAbout" component={CardsAbout}/>
                  <Route path="/Historic" component={Historic}/>
              </Switch>
        </Router>
      </>
   );

}

export default App;


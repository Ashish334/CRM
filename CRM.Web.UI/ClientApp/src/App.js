import React, { Component} from 'react';
import { HashRouter, Route, Switch } from 'react-router-dom';
import './scss/style.scss';

const loading = (
  <div className="pt-3 text-center">
    <div className="sk-spinner sk-spinner-pulse"></div>
  </div>
)

// Containers
const TheLayout = React.lazy(() => import('./containers/TheLayout'));

// Pages
const Login = React.lazy(() => import('./Crm_Components/login/Login'));
class App extends Component {

  render() {
    var islogin = localStorage.getItem("islogin");
    return (
<HashRouter>
        <React.Suspense fallback={loading}>
          <Switch>
      {islogin !== '1' ? <React.Fragment>
           <Route exact path="/" name="Login" render={props => <Login {...props} />} />
            </React.Fragment>
             :
            <Route path="/" name="Home" render={props => <TheLayout {...props}/>} />}
          </Switch>
        </React.Suspense>
</HashRouter>
    );
  }
}

export default App;

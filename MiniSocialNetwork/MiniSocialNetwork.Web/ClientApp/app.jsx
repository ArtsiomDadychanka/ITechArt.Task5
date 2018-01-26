import React from 'react';
import { Route, Switch } from 'react-router-dom';
import Header from './components/header';
import Footer from './components/footer';
import SignIn from './containers/signInContainer';
import SignUp from './containers/signUpContainer';
import Profile from './components/profile';
import * as global from './constants/global';
import {
  HashRouter,
} from 'react-router-dom';

function renderLogin() {
  return (
    <HashRouter>
      <Switch>
        <Route exact path="/" component={SignIn} />
        <Route path="/SignUp" component={SignUp} />
      </Switch>
    </HashRouter>
  );
}
function renderProfile() {
  return (
    <Profile />
  );
}

function componentSubstitution() {
  const rootComponent = (
    <div> Something went wrong ... </div>
  );
  const url = window.location.href.replace(global.SERVER_ADDRESS, '');
  console.log(url);
  switch (url) {
    case global.PAGES_URL.LOGIN: {
      return renderLogin();
    }
    case global.PAGES_URL.USER_PROFILE: {
      return renderProfile();
    }
    default:
      return renderLogin();
  }
}

const App = () => {
  const rootComponent = componentSubstitution();

  return (
    <div className="app-container">
      <Header />
      {rootComponent}

      <Footer />
    </div>
  );
}

export default App;
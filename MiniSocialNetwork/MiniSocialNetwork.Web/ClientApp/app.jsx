import React from 'react';
import { Route, Switch } from 'react-router-dom';
import Header from './components/header';
import Footer from './components/footer';
import SignIn from './containers/signInContainer';
import SignUp from './containers/signUpContainer';
import Profile from './containers/profileContainer';
import MessagesPage from './containers/messagesPageContainer';
import ErrorPage from './components/errorPage';
import * as global from './constants/global';
import {
  HashRouter,
} from 'react-router-dom';

function isCurrentUser(id) {
  return sessionStorage.getItem(global.CURRENT_USER_ID) === id;
}
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
function renderProfile(userId) {
  if (isCurrentUser(userId)) {
    return (<Profile />);
  }
  return (<Profile userId={userId} />);
}
function renderError() {
  return (<ErrorPage />);
}
function renderMessages(userId) {
  return (<MessagesPage userId={userId} />);
}

function componentSubstitution() {
  const rootComponent = (
    <div> Something went wrong ... </div>
  );
  const url = window.location.href.replace(global.SERVER_ADDRESS, '');
  const location = window.location.href;
  const profileIdRegExp = /Profile\/Index\//gi;
  const messagesIdRegExp = /Messages\/Index\//gi;

  if (profileIdRegExp.exec(location) !== null) {
    return renderProfile(location.substring(profileIdRegExp.lastIndex));
  }
  if (messagesIdRegExp.exec(location) !== null) {
    return renderMessages(location.substring(messagesIdRegExp.lastIndex));
  }


  switch (url) {
    case global.PAGES_URL.LOGIN: {
      return renderLogin();
    }
    case global.PAGES_URL.USER_PROFILE: {
      const token = sessionStorage.getItem(global.TOKEN_KEY)
      if (token === null) {
        return renderError();
      }
      return renderProfile();
    }
    default:
      return renderLogin();
  }
}

const App = () => {
  const rootComponent = componentSubstitution();
  const onLogoffClick = () => {
    sessionStorage.clear();
    window.location.href = global.SERVER_ADDRESS;
  }

  return (
    <div className="app-container">
      <Header onLogoffClick={onLogoffClick} />
      {rootComponent}
      <Footer />
    </div>
  );
}

export default App;
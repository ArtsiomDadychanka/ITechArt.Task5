import React from 'react'
import { Route, Switch } from 'react-router-dom'
import Header from './components/header'
import Footer from './components/footer'
import Login from './components/login'
import SignUp from './components/signup'

const App = () => (
  <div>
    <Header />
    <Switch>
      <Route exact path="/" component={Login} />
      <Route path="/SignUp" component={SignUp} />
    </Switch>
    <Footer />
  </div>
)

export default App
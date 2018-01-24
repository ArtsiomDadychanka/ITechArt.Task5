import React from 'react'
import { Link } from 'react-router-dom'

const Login = () => {
  return (
    <div className="login">
      <div className="login__inner">
        <h3 className="login__app-name">Ramoo</h3>
        <hr className="login__separator" />
        <h5 className="login__title">Login</h5>
        <form className="login__form" action="">
          <div className="row">
            <div className="input-field col s12">
              <input
                placeholder="example@gmail.com"
                id="email"
                type="email"
                className="validate"
              />
            </div>
          </div>
          <div className="row">
            <div className="input-field col s12">
              <input
                id="password"
                type="password"
                className="validate"
              />
              <label htmlFor="password">Your password</label>
            </div>
          </div>
          <div className="login__signup-btn row">
            <button className="btn waves-effect waves-light col offset-s2 s8" type="submit" name="action">
              Sign in
            </button>
          </div>
          <div className="row">
            <div className="col offset-s2 s8">
              Don't have account?
              </div>
          </div>
          <div className="login__signin-btn row">
            <Link to="SignUp" className="btn waves-effect waves-light col offset-s2 s8">
              Sign up
            </Link>
          </div>
        </form>
      </div>
    </div>
  )
}

export default Login

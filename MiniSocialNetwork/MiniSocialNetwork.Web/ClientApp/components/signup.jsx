import React from 'react'
import { Link } from 'react-router-dom'

const SingUp = () => {
  return (
    <div className="sign-up">
      <div className="sign-up__inner">
        <h3 className="sign-up__app-name">Ramoo</h3>
        <hr className="sign-up__separator" />
        <h5 className="sign-up__title">Registration</h5>
        <form action="">
          <div className="row">
            <div className="input-field col s6">
              <input
                id="first_name"
                type="text"
                className="validate"
              />
              <label htmlFor="first_name">First Name</label>
            </div>
            <div className="input-field col s6">
              <input
                id="last_name"
                type="text"
                className="validate"
              />
              <label htmlFor="last_name">Last Name</label>
            </div>
          </div>
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
          <div className="row">
            <div className="input-field col s12">
              <input
                id="confirm_password"
                type="password"
                className="validate"
              />
              <label htmlFor="confirm_password">Confirm password</label>
            </div>
          </div>
          <div className="sign-up__signup-btn row">
            <button className="btn waves-effect waves-light col offset-s2 s8" type="submit" name="action">
              Sign up
            </button>
          </div>
          <div className="row">
            <p className="col offset-s5 s4">Have account?</p>
          </div>
          <div className="sign-up__signin-btn row ">
            <Link to="Login" className="btn waves-effect waves-light col offset-s2 s8">
              Log in
            </Link>
          </div>
        </form>
      </div>
    </div >
  )
}

export default SingUp

import React from 'react';
import { Link } from 'react-router-dom';

class SignIn extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      login: '',
      password: '',
      error: ''
    };
  }

  onLoginChange = (e) => {
    const login = e.target.value;
    if (login.trim().length > 0) {
      this.setState({
        login
      });
    }
  }

  onPasswordChange = (e) => {
    const password = e.target.value;
    if (password.trim().length > 0) {
      this.setState({
        password
      });
    }
  }

  handleSignInClick = () => {
    const { signIn } = this.props.authActions;
    const { login, password } = this.state;

    let userCredentials = {
      Email: login,
      Password: password
    };
    console.log('User cred');
    console.log(userCredentials);
    signIn(userCredentials);
  }

  render() {
    const { currentUser, isFetching, error, redirectUrl } = this.props;

    if (redirectUrl) {
      window.location.assign(redirectUrl);
    }

    return (
      <div className="login">
        <div className="login__inner">
          <h3 className="login__app-name">Ramoo</h3>
          <hr className="login__separator" />
          <h5 className="login__title">Login</h5>
          <form className="login__form">
            <div className="row">
              <div className="input-field col s12">
                <input
                  onChange={this.onLoginChange}
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
                  onChange={this.onPasswordChange}
                  id="password"
                  type="password"
                  className="validate"
                />
                <label htmlFor="password">Your password</label>
              </div>
            </div>
            <div className="login__signup-btn row">
              <button
                onClick={this.handleSignInClick}
                className="btn waves-effect waves-light col offset-s2 s8" type="submit"
              >
                Sign in
              </button>
            </div>
            <div className="row">
              <div className="col offset-s4 s8">
                Don't have account?
                </div>
            </div>
            <div className="login__signin-btn row">
              <Link to={{ hash: '#', pathname: '/SignUp' }} className="col offset-s5 s7">
                Sign up
              </Link>
            </div>
          </form>
        </div>
      </div>
    );
  }
}

export default SignIn;

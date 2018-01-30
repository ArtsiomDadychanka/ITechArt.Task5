import React from 'react';
import { Link } from 'react-router-dom';

class SignUp extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      firstname: '',
      lastname: '',
      email: '',
      password: '',
      repeatPassword: ''
    };
  }

  onFieldChange = (fieldName, e) => {
    if (e.target.value.trim().length > 0) {
      this.setState({
        ['' + fieldName]: e.target.value,
      })
    }
  }

  handleSignupClick = () => {
    const { signupActions } = this.props;
    const { signUp } = signupActions;
    const { firstname, lastname, email, password, repeatPassword } = this.state;

    let regData = {
      Firstname: firstname,
      Lastname: lastname,
      Email: email,
      Password: password,
      RepeatPassword: repeatPassword
    };
    console.log(regData);
    alert(regData);
    signUp(regData);
  };

  render() {
    const { redirectUrl } = this.props;

    if (redirectUrl) {
      alert('in redirect')
      alert(redirectUrl)
      window.location.assign(redirectUrl);
    }

    return (
      <div className="sign-up">
        <div className="sign-up__inner">
          <h3 className="sign-up__app-name">Ramoo</h3>
          <hr className="sign-up__separator" />
          <h5 className="sign-up__title">Registration</h5>
          <form>
            <div className="row">
              <div className="input-field col s6">
                <input
                  onChange={(e) => this.onFieldChange('firstname', e)}
                  id="firstname"
                  type="text"
                  className="validate"
                />
                <label htmlFor="first_name">First Name</label>
              </div>
              <div className="input-field col s6">
                <input
                  onChange={(e) => this.onFieldChange('lastname', e)}
                  id="lastname"
                  type="text"
                  className="validate"
                />
                <label htmlFor="last_name">Last Name</label>
              </div>
            </div>
            <div className="row">
              <div className="input-field col s12">
                <input
                  onChange={(e) => this.onFieldChange('email', e)}
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
                  onChange={(e) => this.onFieldChange('password', e)}
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
                  onChange={(e) => this.onFieldChange('repeatPassword', e)}
                  id="repeatPassword"
                  type="password"
                  className="validate"
                />
                <label htmlFor="confirm_password">Confirm password</label>
              </div>
            </div>
            <div className="sign-up__signup-btn row">
              <button
                onClick={this.handleSignupClick}
                className="btn waves-effect waves-light col offset-s2 s8"

              >
                Sign up
              </button>
            </div>
            <div className="row">
              <p className="col offset-s4 s5">Have account?</p>
            </div>
            <div className="sign-up__signin-btn row ">
              <Link to={{ pathname: '/' }} className="col offset-s5 s7">
                Log in
              </Link>
            </div>
          </form>
        </div>
      </div >
    );
  }
}

export default SignUp;

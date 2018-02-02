import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import Profile from '../components/profile';
import * as signupActions from '../actions/signupActions';

function mapStateToProps(state) {
  return {
    currentUser: state.sign.currentUser,
    isFetching: state.sign.isFetching,
    error: state.sign.error,
    redirectUrl: state.sign.redirectUrl
  };
}

function mapDispatchToProps(dispatch) {
  return {
    signupActions: bindActionCreators(signupActions, dispatch),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Profile);
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import Login from '../components/signin';
import * as authActions from '../actions/authActions';

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
    authActions: bindActionCreators(authActions, dispatch),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Login);
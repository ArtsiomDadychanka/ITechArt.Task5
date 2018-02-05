import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import Profile from '../components/profile';
import * as userActions from '../actions/userActions';

function mapStateToProps(state) {
  return {
    user: state.user.user,
    isFetching: state.user.isFetching,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    userActions: bindActionCreators(userActions, dispatch),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Profile);
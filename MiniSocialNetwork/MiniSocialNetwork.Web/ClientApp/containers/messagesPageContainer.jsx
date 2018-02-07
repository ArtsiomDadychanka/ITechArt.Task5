import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import MessagesPage from '../components/messagesPage';
import * as userActions from '../actions/userActions';

function mapStateToProps(state) {
  return {
    // currentUserId: state.user.user.id,
    user: state.user.user,
    isFetching: state.user.isFetching,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    userActions: bindActionCreators(userActions, dispatch),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(MessagesPage);
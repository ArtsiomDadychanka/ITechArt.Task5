import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import NewComment from '../components/newComment';
import * as commentsActions from '../actions/commentsActions';

function mapStateToProps(state) {
  return {
    currentUserId: state.user.user.id,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    commentsActions: bindActionCreators(commentsActions, dispatch),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(NewComment);
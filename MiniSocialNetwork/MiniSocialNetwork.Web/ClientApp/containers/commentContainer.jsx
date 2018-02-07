import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import Comment from '../components/comment';
import * as commentsActions from '../actions/commentsActions';

function mapStateToProps(state) {
  return {
  };
}

function mapDispatchToProps(dispatch) {
  return {
    commentsActions: bindActionCreators(commentsActions, dispatch),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Comment);
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import Comment from '../components/comment';
import * as commentsActions from '../actions/commentsActions';

const mapStateToProps = state => { };

function mapDispatchToProps(dispatch) {
  return {
    commentsActions: bindActionCreators(commentsActions, dispatch),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Comment);
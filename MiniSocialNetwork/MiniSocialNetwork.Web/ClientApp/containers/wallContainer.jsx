import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import Wall from '../components/wall';
import * as postsActions from '../actions/postsActions';

function mapStateToProps(state) {
  return {
    currentUserId: state.user.user.id,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    postsActions: bindActionCreators(postsActions, dispatch),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Wall);
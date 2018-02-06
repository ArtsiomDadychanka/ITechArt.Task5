import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import Profile from '../components/profile';
import * as userActions from '../actions/userActions';
import * as postsActions from '../actions/postsActions';

function mapStateToProps(state) {
  return {
    user: state.user.user,
    isFetching: state.user.isFetching,
    posts: state.posts.posts,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    userActions: bindActionCreators(userActions, dispatch),
    postsActions: bindActionCreators(postsActions, dispatch),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Profile);
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import Post from '../components/post';
import * as postsActions from '../actions/postsActions';

const mapStateToProps = state => { };

function mapDispatchToProps(dispatch) {
  return {
    postsActions: bindActionCreators(postsActions, dispatch),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Post);
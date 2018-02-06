import {
  combineReducers
} from 'redux';
import sign from './signReducer';
import user from './userReducer';
import posts from './postsReducer';
import comments from './commentsReducer';

export default combineReducers({
  sign,
  user,
  posts,
  // comments,
});
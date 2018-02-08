import {
  combineReducers
} from 'redux';
import sign from './signReducer';
import user from './userReducer';
import posts from './postsReducer';
import messages from './messagesReducer';

export default combineReducers({
  sign,
  user,
  posts,
  messages
});
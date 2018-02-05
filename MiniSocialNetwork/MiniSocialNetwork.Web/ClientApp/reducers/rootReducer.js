import {
  combineReducers
} from 'redux';
import sign from './signReducer';
import user from './userReducer';

export default combineReducers({
  sign,
  user,
});
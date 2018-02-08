import * as types from '../actions/actionTypes';

const initState = {
  isFetching: true,
  user: {
    username: ''
  }
};

export default function userReducer(state = initState, action) {
  switch (action.type) {
    case types.GET_USER_INFO_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
        }
        return newState;
      }
    case types.GET_USER_INFO_SUCCESS:
      {
        const newState = {
          ...state,
          isFetching: false,
          user: action.data
        };
        return newState;
      }
    case types.GET_USER_INFO_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
          error: action.error
        }
        return newState;
      }
    default:
      return state;
  }
}
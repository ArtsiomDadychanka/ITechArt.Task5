import * as types from '../actions/actionTypes';

const initState = {
  isFetching: true,
  user: null
};

export default function userReducer(state = initState, action) {
  switch (action.type) {
    case types.GET_USER_INFO_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
          user: null
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
          user: null,
          error: action.error
        }
        return newState;
      }
    default:
      return state;
  }
}
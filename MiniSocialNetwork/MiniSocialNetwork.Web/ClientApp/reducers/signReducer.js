import * as types from '../constants/actionTypes';

export default function signReducer(state = {}, action) {
  switch (action.type) {
    case types.SIGN_IN_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
          currentUser: action.data
        };
        return newState;
      }
    case types.SIGN_IN_SUCCESS:
      {
        const newState = {
          ...state,
          isFetching: false,
          currentUser: action.data,
          redirectUrl: action.redirectUrl
        };
        return newState;
      }
    case types.SIGN_IN_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
          currentUser: action.data,
          error: action.error
        };
        return newState;
      }
    case types.SIGN_UP_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
          currentUser: action.data
        };
        return newState;
      }
    case types.SIGN_UP_SUCCESS:
      {
        const newState = {
          ...state,
          isFetching: false,
          currentUser: action.data,
          redirectUrl: action.redirectUrl
        };
        return newState;
      }
    case types.SIGN_UP_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
          currentUser: action.data,
          error: action.error
        };
        return newState;
      }
    default:
      return state;
  }
}
import * as types from '../actions/actionTypes';

export default function postReducer(state = {}, action) {
  switch (action.type) {
    case types.GET_USER_POSTS_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
          posts: []
        }
        return newState;
      }
    case types.GET_USER_POSTS_SUCCESS:
      {
        const newState = {
          ...state,
          isFetching: false,
          posts: action.data
        }
        return newState;
      }
    case types.GET_USER_POSTS_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
          posts: [],
        }
        return newState;
      }
    case types.CREATE_POST_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
        }
        return newState;
      }
    case types.CREATE_POST_SUCCESS:
      {
        const newState = {
          ...state,
          isFetching: false,
          posts: [...state.posts, action.data]
        }
        return newState;
      }
    case types.CREATE_POST_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
          error: action.error,
        }
        return newState;
      }

    default:
      return state;
  }
}
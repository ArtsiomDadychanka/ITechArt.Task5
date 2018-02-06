import * as types from '../actions/actionTypes';

export default function commentsReducer(state = {
  comments: []
}, action) {
  switch (action.type) {
    case types.GET_COMMENTS_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
        }
        return newState;
      }
    case types.GET_COMMENTS_SUCCESS:
      {
        const newState = {
          ...state,
          isFetching: false,
          comments: state.comments.concat(action.data),
        }
        return newState;
      }
    case types.GET_COMMENTS_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
          error: action.error
        }
        return newState;
      }
    case types.CREATE_COMMENT_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
        }
        return newState;
      }
    case types.CREATE_COMMENT_SUCCESS:
      {
        const newState = {
          ...state,
          isFetching: false,
          comments: [...state.comments, action.data]
        }
        return newState;
      }
    case types.CREATE_COMMENT_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
          comments: [...state.comments],
          error: action.error,
        }
        return newState;
      }

    default:
      return state;
  }
}
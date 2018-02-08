import * as types from '../actions/actionTypes';

const initState = {
  messages: [],
  isFetching: true,
};

export default function messagesReducer(state = initState, action) {
  switch (action.type) {
    case types.GET_MESSAGES_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
          messages: [],
        }
        return newState;
      }
    case types.GET_MESSAGES_SUCCESS:
      {
        const newState = {
          ...state,
          isFetching: false,
          messages: action.data,
        }
        return newState;
      }
    case types.GET_MESSAGES_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
          error: action.error,
        }
      }
    case types.SEND_MESSAGE:
      {
        const newState = {
          ...state,
          messages: [...state.messages, action.data]
        }
        return newState;
      }
    default:
      return state;
  }
}
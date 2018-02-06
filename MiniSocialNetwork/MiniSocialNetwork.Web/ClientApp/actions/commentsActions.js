import * as types from './actionTypes';
import * as global from '../constants/global';

export function getComments(postId) {
  return (dispatch) => {
    dispatch({
      type: types.GET_COMMENTS_REQUEST,
      data: null
    });

    fetch(`${global.SERVER_API_ADDRESS}${global.SERVER_API_URI.COMMENTS}/${postId}`, {
        mode: 'cors',
        method: 'get',
        headers: global.authorizeHeaders,
      })
      .then(res => {
        if (res.status !== 200) {
          throw new Error(res.statusText);
        }
        return res.json();
      })
      .then(comments => {
        dispatch({
          type: types.GET_COMMENTS_SUCCESS,
          data: comments
        });
      })
      .catch(err => {
        dispatch({
          type: types.GET_COMMENTS_REJECT,
          data: null,
          error: err,
        });
        console.log(err);
      });
  };
}

export function createComment(comment) {
  return (dispatch) => {
    dispatch({
      type: types.CREATE_COMMENT_REQUEST,
      data: null,
    });

    fetch(`${global.SERVER_API_ADDRESS}${global.SERVER_API_URI.COMMENTS}`, {
        mode: 'cors',
        method: 'post',
        headers: global.authorizeHeaders,
        body: JSON.stringify(comment) // TODO: convert to right format
      })
      .then(res => {
        if (res.status !== 201) {
          throw new Error(res.statusText);
        }
        return res.json();
      })
      .then(createdComment => {
        dispatch({
          type: types.CREATE_COMMENT_SUCCESS,
          data: createdComment
        });
      })
      .catch(err => {
        dispatch({
          type: types.CREATE_COMMENT_REJECT,
          data: null,
          error: err,
        });
        console.log(err);
      });
  };
}

export function removeComment(commentId) {
  return (dispatch) => {
    dispatch({
      type: types.DELETE_COMMENT_REQUEST,
      data: null,
    });

    fetch(`${global.SERVER_API_ADDRESS}${global.SERVER_API_URI.COMMENTS}`, {
        mode: 'cors',
        method: 'delete',
        headers: global.authorizeHeaders
      })
      .then(res => {
        if (res.status !== 200) {
          throw new Error(res.statusText);
        }
        dispatch({
          type: types.DELETE_COMMENT_SUCCESS,
          data: null
        });
      })
      .catch(err => {
        dispatch({
          type: types.DELETE_COMMENT_REJECT,
          data: null,
          error: err,
        });
        console.log(err);
      });
  };
}
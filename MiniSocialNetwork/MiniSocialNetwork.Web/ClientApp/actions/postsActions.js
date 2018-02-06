import * as types from './actionTypes';
import * as global from '../constants/global';

export function getPosts(userId) {
  return (dispatch) => {
    dispatch({
      type: types.GET_USER_POSTS_REQUEST,
      data: null
    });

    fetch(`${global.SERVER_API_ADDRESS}${global.SERVER_API_URI.POSTS}/${userId}`, {
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
      .then(posts => {
        dispatch({
          type: types.GET_USER_POSTS_SUCCESS,
          data: posts
        });
      })
      .catch(err => {
        dispatch({
          type: types.GET_USER_POSTS_REJECT,
          data: null,
          error: err,
        });
        console.log(err);
      });
  };
}

export function createPost(post) {
  return (dispatch) => {
    dispatch({
      type: types.CREATE_POST_REQUEST,
      data: null,
    });

    fetch(`${global.SERVER_API_ADDRESS}${global.SERVER_API_URI.POSTS}`, {
        mode: 'cors',
        method: 'post',
        headers: global.authorizeHeaders,
        body: JSON.stringify(post) // TODO: convert to right format
      })
      .then(res => {
        if (res.status !== 201) {
          throw new Error(res.statusText);
        }
        return res.json();
      })
      .then(createdPost => {
        dispatch({
          type: types.CREATE_POST_SUCCESS,
          data: createdPost
        });
      })
      .catch(err => {
        dispatch({
          type: types.CREATE_POST_REJECT,
          data: null,
          error: err,
        });
        console.log(err);
      });
  };
}

export function removePost(postId) {
  return (dispatch) => {
    dispatch({
      type: types.DELETE_POSTS_REQUEST,
      data: null,
    });

    fetch(`${global.SERVER_API_ADDRESS}${global.SERVER_API_URI.POSTS}`, {
        mode: 'cors',
        method: 'delete',
        headers: global.authorizeHeaders
      })
      .then(res => {
        if (res.status !== 200) {
          throw new Error(res.statusText);
        }
        dispatch({
          type: types.DELETE_POSTS_SUCCESS,
          data: null
        });
      })
      .catch(err => {
        dispatch({
          type: types.DELETE_POSTS_REJECT,
          data: null,
          error: err,
        });
      });
  };
}

export function likePost(postId) {
  return (dispatch) => {
    dispatch({
      type: types.LIKE_POSTS_REQUEST,
      data: null,
    });

    const likeUri =
      global.SERVER_API_URI.POSTS_LIKE.replace(
        global.URI_REGEXP_PATTERN,
        postId
      );

    fetch(`${global.SERVER_API_ADDRESS}${likeUri}`, {
        mode: 'cors',
        method: 'put',
        headers: global.authorizeHeaders
      })
      .then(res => {
        if (res.status !== 200) {
          throw new Error(res.statusText);
        }
        if (res.status === 200) {
          dispatch({
            type: types.LIKE_POSTS_SUCCESS,
            data: null
          });
        }
      })
      .catch(err => {
        dispatch({
          type: types.LIKE_POSTS_REJECT,
          data: null,
          error: err,
        });
        console.log(err);
      });
  };
}

export function unlikePost(postId) {
  return (dispatch) => {
    dispatch({
      type: types.UNLIKE_POSTS_REQUEST,
      data: null,
    });

    const unlikeUri =
      global.SERVER_API_URI.POSTS_UNLIKE.replace(
        global.URI_REGEXP_PATTERN,
        postId
      );

    fetch(`${global.SERVER_API_ADDRESS}${unlikeUri}`, {
        mode: 'cors',
        method: 'put',
        headers: global.authorizeHeaders
      })
      .then(res => {
        if (res.status !== 200) {
          throw new Error(res.statusText);
        }
        if (res.status === 200) {
          dispatch({
            type: types.UNLIKE_POSTS_SUCCESS,
            data: null
          });
        }
      })
      .catch(err => {
        dispatch({
          type: types.UNLIKE_POSTS_REJECT,
          data: null,
          error: err,
        });
      });
  };
}
import * as types from './actionTypes';
import * as global from '../constants/global';

export function getPosts(userId) {
  return (dispatch) => {
    dispatch({
      type: types.GET_USER_POSTS_REQUEST,
      data: null
    });

    fetch(`${global.SERVER_API_URI}${global.SERVER_API_URI.POSTS}`, {
        mode: 'cors',
        method: 'post',
        headers: global.authorizeHeaders,
        body: JSON.stringify(userId)
      })
      .then(res => {
        if (res.status !== 200) {
          dispatch({
            type: types.GET_USER_POSTS_REJECT,
            data: null,
            error: res.statusText,
          });
        }
        return res.json();
      })
      .then(posts => {
        dispatch({
          type: types.GET_USER_POSTS_SUCCESS,
          data: posts
        });
      })
      .catch(err => console.log(err));
  };
}
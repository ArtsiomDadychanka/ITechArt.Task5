import * as types from '../constants/actionTypes';
import * as global from '../constants/global';

export function signUp(userCredentials) {
  return (dispath) => {
    dispath({
      type: types.SIGN_UP_REQUEST,
      data: null
    });
    console.log(`${global.SERVER_API_ADDRESS}${global.SERVER_API_URI.SIGNUP}`);
    fetch(`${global.SERVER_API_ADDRESS}${global.SERVER_API_URI.SIGNUP}`, {
        mode: 'cors',
        method: 'post',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(userCredentials)
      })
      .then(res => {
        alert(res)
        if (res.status === 200) {
          dispath({
            type: types.SIGN_UP_SUCCESS,
            data: userCredentials,
            redirectUrl: `${global.SERVER_ADDRESS}${global.PAGES_URL.USER_PROFILE}`
          });
        } else {
          dispath({
            type: types.SIGN_UP_REJECT,
            data: null,
            error: res.statusText,
          });
        }
      })
      .catch(err => console.log(err));
    alert('end of action');
  };
}
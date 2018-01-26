import * as types from '../constants/actionTypes';
import * as global from '../constants/global';

export function signIn(userCredentials) {
  return (dispath) => {
    dispath({
      type: types.SIGN_IN_REQUEST,
      data: null
    });

    fetch(`${global.SERVER_API_ADDRESS}/auth`, {
        mode: 'cors',
        method: 'post',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(userCredentials)
      })
      .then(res => {
        if (res.status === 200) {
          dispath({
            type: types.SIGN_IN_SUCCESS,
            data: userCredentials,
            redirectUrl: `${global.SERVER_ADDRESS}${global.PAGES_URL.USER_PROFILE}`
          });
        } else {
          dispath({
            type: types.SIGN_IN_REJECT,
            data: null,
            error: res.statusText,
          });
        }
      })
      .catch(err => console.log(err));
  };
}
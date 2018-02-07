import React from 'react';

const NewMessage = () => {
  return (
    <div className="new-message row">
      <div className="new-message__text col s8 row">
        <div className="input-field col s12">
          <textarea
            placeholder="input your message"
            className="materialize-textarea"
          >
          </textarea>
        </div>
      </div>
      <a className="new-message__send-btn col offset-s1 s1">
        <i className="material-icons">send</i>
      </a>
    </div >
  );
}

export default NewMessage;

import React from 'react';
import * as global from '../../constants/global';

const ChatButton = ({ userId }) => {
  let linkToChat = '';
  if (userId) {
    linkToChat = `${global.SERVER_ADDRESS}${global.PAGES_URL.MESSAGES}/${userId}`
  }
  return (
    <a
      href={linkToChat}
      className="col offset-s1 s4 chat-button waves-effect waves-light btn"
    >
      <i className="tiny material-icons left">chat_bubble</i>
      Chat
    </a>
  );
}

export default ChatButton;

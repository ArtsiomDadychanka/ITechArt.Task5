import React, { Component } from 'react';
import NewMessage from '../components/newMessage';
import Chat from '../components/chat';
import ChatHeader from '../components/chatHeader';

class Messages extends Component {
  static get defaultProps() {
    return {
      user: {},
      messages: []
    };
  }

  constructor(props) {
    super(props);


  }

  sendMessageHandler = (message) => {

  }


  render() {
    const { user, messages } = this.props;

    return (
      <div className="messages">
        <ChatHeader
          username={user.username}
        />
        <Chat messages={messages} />
        <NewMessage />
      </div>
    );
  }
}

export default Messages;
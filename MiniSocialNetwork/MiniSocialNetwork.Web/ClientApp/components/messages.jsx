import React, { Component } from 'react';
import NewMessage from '../components/newMessage';
import Chat from '../components/chat';
import ChatHeader from '../components/chatHeader';

class Messages extends Component {
  static get defaultProps() {
    return {
      user: {}
    }
  }

  constructor(props) {
    super(props);

  }


  render() {
    const { user } = this.props;

    return (
      <div className="messages">
        <ChatHeader
        // username={user.username} 
        />
        <Chat />
        <NewMessage />
      </div>
    );
  }
}

export default Messages;
import React, { Component } from 'react';
import Message from './message';

class Chat extends Component {
  static get defaultProps() {
    return {

    }
  }

  constructor(props) {
    super(props);

  }


  render() {
    return (
      <div className="chat">
        <Message />
        <Message />
        <Message />
        <Message />
        <Message />
        <Message />
      </div>
    );
  }
}

export default Chat;

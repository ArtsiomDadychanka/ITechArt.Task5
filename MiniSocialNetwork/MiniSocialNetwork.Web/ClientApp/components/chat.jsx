import React, { Component } from 'react';
import Message from './message';

class Chat extends Component {
  static get defaultProps() {
    return {
      messages: []
    }
  }

  constructor(props) {
    super(props);

  }


  render() {
    const { messages } = this.props;
    const messagesComponens = messages.map((m) => {
      return (<Message />);
    });

    return (
      <div className="chat">
        {/* {messagesComponens} */}
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

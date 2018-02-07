import React, { Component } from 'react';

class ChatHeader extends Component {
  static get defaultProps() {
    return {
      username: 'username'
    }
  }

  constructor(props) {
    super(props);

  }

  render() {
    const { username } = this.props;

    return (
      <div className="chat-header">
        {username}
      </div>
    );
  }
}

export default ChatHeader;

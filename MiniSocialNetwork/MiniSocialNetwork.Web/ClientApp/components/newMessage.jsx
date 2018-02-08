import React, { Component } from 'react';

class NewMessage extends Component {
  static get defaultProps() {
    return {

    };
  }

  constructor(props) {
    super(props);

    this.state = {
      messageText: '',
    };
  }

  onMessageTextChange = (e) => {
    if (e.target.value.trim().length > 0) {
      this.setState({
        messageText: e.target.value,
      });
    }
  }

  render() {
    return (
      <div className="new-message row">
        <div className="new-message__text col s8 row">
          <div className="input-field col s12">
            <textarea
              onChange={this.onMessageTextChange}
              placeholder="input your message"
              className="materialize-textarea"
            >
            </textarea>
          </div>
        </div>
        <a

          className="new-message__send-btn col offset-s1 s1"
        >
          <i className="material-icons">send</i>
        </a>
      </div >
    );
  }
}

export default NewMessage;

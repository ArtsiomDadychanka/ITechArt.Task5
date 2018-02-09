import React from 'react';
import ProfileSidebar from './panels/profileSidebar';
import Messages from '../components/messages';
import * as global from '../constants/global';

class MessagesPage extends React.Component {
  static get defaultProps() {
    return {
      userId: '',
      user: {
        username: 'user name'
      },
      messages: {
        messages: []
      }
    };
  }

  constructor(props) {
    super(props);
  }



  componentDidMount() {
    const { loadUserInfo } = this.props.userActions;
    const { userId } = this.props;
    loadUserInfo(userId);

    //TODO: load messages

    // открываем соединение с сервером
    let currentUserId = sessionStorage.getItem(global.TOKEN_KEY);

    $.connection.hub.start()
      .done(() => { console.log('Now connected, ID=' + $.connection.hub.id); })
      .fail(function () { console.log('Could not Connect!'); });
  }

  render() {
    const { user, messages } = this.props;
    const { username } = user;
    const userMessages = messages.messages;

    return (
      <div className="messages-page row">
        <ProfileSidebar
          username={username}
          isSelf={false}
        />
        <Messages messages={userMessages} user={user} />
      </div>
    );
  }
}

export default MessagesPage;

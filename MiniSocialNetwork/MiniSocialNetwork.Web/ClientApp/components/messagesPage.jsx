import React from 'react';
import ProfileSidebar from './panels/profileSidebar';
import Messages from '../components/messages';

class MessagesPage extends React.Component {
  static get defaultProps() {
    return {
      userId: '',
      user: {}
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
  }

  render() {
    const { user } = this.props;
    // const { username } = user;

    return (
      <div className="messages-page row">
        <ProfileSidebar
          // username={username}
          isSelf={false}
        />
        <Messages user={user} />
      </div>
    );
  }
}

export default MessagesPage;

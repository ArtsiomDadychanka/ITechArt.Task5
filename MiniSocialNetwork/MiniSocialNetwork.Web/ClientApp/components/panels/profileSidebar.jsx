import React from 'react';
import ProfileMainInfo from '../profileMainInfo';
import ActivityBar from './activityBar';

class ProfileSidebar extends React.Component {
  static get defaultProps() {
    return {
      username: 'username',
      isSelf: true,
    };
  }

  constructor(props) {
    super(props);

  }


  render() {
    const { username, isSelf, userId } = this.props;

    return (
      <div className="profile-sidebar col s2 blue-grey darken-2">
        <ProfileMainInfo userId={userId} isSelf={isSelf} username={username} />
        <ActivityBar />
      </div>
    );
  }
}

export default ProfileSidebar;

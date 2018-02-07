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
    const { username } = this.props;
    const { isSelf } = this.props;

    return (
      <div className="profile-sidebar col s2 blue-grey darken-2">
        <ProfileMainInfo isSelf={isSelf} username={username} />
        <ActivityBar />
      </div>
    );
  }
}

export default ProfileSidebar;

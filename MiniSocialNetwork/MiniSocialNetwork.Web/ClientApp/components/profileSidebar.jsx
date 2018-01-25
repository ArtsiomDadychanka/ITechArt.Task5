import React from 'react';
import ProfileMainInfo from './profileMainInfo';
import ActivityBar from './activityBar';

class ProfileSidebar extends React.Component {

  render() {
    return (
      <div className="profile-sidebar col s2">
        <ProfileMainInfo />
        <ActivityBar />
      </div>
    );
  }
}

export default ProfileSidebar;

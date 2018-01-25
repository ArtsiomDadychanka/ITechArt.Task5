import React from 'react';
import ProfileSidebar from './profileSidebar';

class Profile extends React.Component {

  render() {
    return (
      <div className="profile row">
        <ProfileSidebar />
      </div>
    );
  }
}

export default Profile;

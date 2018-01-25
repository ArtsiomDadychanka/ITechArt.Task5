import React from 'react';
import ProfilePhoto from './profilePhoto';
import ProfileActions from './profileActions';

const ProfileMainInfo = () => {
  return (
    <div className="profile-main-info">
      <ProfilePhoto />
      <ProfileActions />
    </div>
  );
}

export default ProfileMainInfo;

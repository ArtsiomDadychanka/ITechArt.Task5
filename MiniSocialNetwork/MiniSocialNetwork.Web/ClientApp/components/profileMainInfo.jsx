import React from 'react';
import ProfilePhoto from './profilePhoto';
import ProfileActions from './profileActions';
import ProfileMyActions from './profileMyActions';

const ProfileMainInfo = () => {
  return (
    <div className="profile-main-info">
      <ProfilePhoto />
      <ProfileActions />
      {/* <ProfileMyActions /> */}
    </div>
  );
}

export default ProfileMainInfo;

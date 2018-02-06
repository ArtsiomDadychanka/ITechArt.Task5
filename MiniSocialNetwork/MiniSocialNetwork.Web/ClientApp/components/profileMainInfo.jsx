import React from 'react';
import ProfilePhoto from './profilePhoto';
import ProfileActions from './profileActions';
import ProfileMyActions from './profileMyActions';

const ProfileMainInfo = ({ username, isSelf }) => {
  const actions = isSelf ?
    (<ProfileMyActions username={username} />) :
    (<ProfileActions username={username} />);

  return (
    <div className="profile-main-info">
      <ProfilePhoto />
      {actions}
    </div>
  );
}

export default ProfileMainInfo;

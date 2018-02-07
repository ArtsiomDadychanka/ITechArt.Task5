import React from 'react';
import ChatButton from './buttons/chatButton';
import FollowingButton from './buttons/followingButton';

const ProfileActions = ({ username = 'User name', userId }) => {
  return (
    <div className="profile-actions blue-grey darken-4">
      <div className="row">
        <h5 className="col offset-s1 profile-actions__username">{username}</h5>
      </div>
      <div className="row">
        <FollowingButton />
        <ChatButton userId={userId} />
      </div>
    </div>
  );
}

export default ProfileActions;

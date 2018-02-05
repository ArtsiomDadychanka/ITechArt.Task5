import React from 'react';
import EditButton from './buttons/editButton';

const ProfileMyActions = ({ username = 'User name' }) => {
  return (
    <div className="profile-actions blue-grey darken-4">
      <div className="row">
        <h5 className="col offset-s1 profile-actions__username">
          {username}
        </h5>
      </div>
      <div className="row">
        <EditButton />
      </div>
    </div>
  );
}

export default ProfileMyActions;

import React from 'react';

const FollowingButton = ({ isFollowing = false }) => {
  const btnText = isFollowing ? 'Following' : 'Follow';
  return (
    <button
      className={`${isFollowing ? 'teal lighten-1' : 'blue-grey lighten-3'} following-button col offset-s1 s4 profile-actions__following-button waves-effect waves-light btn `}
    >
      {isFollowing &&
        <i className="tiny material-icons left">check</i>
      }
      {btnText}
    </button>
  );
}

export default FollowingButton;

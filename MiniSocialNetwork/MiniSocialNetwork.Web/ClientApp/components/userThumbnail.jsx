import React from 'react';

const UserThumbnail = ({ username = "username", col = "s2" }) => {
  return (
    <a href="#" className={`user-thumbnail col ${col}`}>
      <img
        className="user-thumbnail__img"
        src="../../content/images/noavatar.jpg"
        alt={username}
      />
    </a>
  );
}

export default UserThumbnail;

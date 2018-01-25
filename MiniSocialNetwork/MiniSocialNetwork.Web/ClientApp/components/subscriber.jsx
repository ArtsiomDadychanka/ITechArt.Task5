import React from 'react';
import UserThumbnail from './userThumbnail';

const Subscriber = ({ username = 'Username' }) => {
  return (
    <div className="subscriber row">
      <UserThumbnail col={"s3"} />
      <div className="valign-wrapper">
        <a href="#" className="subscriber__username col s8">
          {username}
        </a>
      </div>
    </div>
  );
}

export default Subscriber;

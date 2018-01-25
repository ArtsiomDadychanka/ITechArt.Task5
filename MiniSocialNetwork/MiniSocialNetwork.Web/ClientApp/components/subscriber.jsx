import React from 'react';

const Subscriber = ({ username = 'Username' }) => {
  return (
    <div className="subscriber row">
      <a href="#" className="subscriber__thumbnail col s3" >
        <img
          className="subscriber__thumbnail-img"
          src="../../content/images/fake-profile.jpg"
          alt={username}
        />
      </a>
      <div className="valign-wrapper">
        <a href="#" className="subscriber__username col s8">
          {username}
        </a>
      </div>
    </div>
  );
}

export default Subscriber;

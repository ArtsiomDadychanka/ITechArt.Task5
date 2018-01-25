import React from 'react';
import Subscriber from '../subscriber';

const SubscribersSidebar = () => {
  return (
    <div className="subscribers-sidebar col s2 grey lighten-2">
      <h5>Subscribers: </h5>
      <div className="subscribers-sidebar__subscribers">
        <Subscriber />
        <Subscriber />
        <Subscriber />
        <Subscriber />
        <Subscriber />
        <Subscriber />
      </div>
    </div>
  );
}

export default SubscribersSidebar;

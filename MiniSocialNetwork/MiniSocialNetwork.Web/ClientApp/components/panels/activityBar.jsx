import React from 'react';

const ActivityBar = () => {
  return (
    <div className="activity-bar blue-grey darken-2">
      <h4 className="activity-bar__title">Activity</h4>
      <ul className="activity-bar__activities">
        <li className="activity-bar__activity">
          <a className="activity-bar__activity-link" href="#">About me</a>
        </li>
        <li className="activity-bar__activity">
          <a className="activity-bar__activity-link" href="#">Subscribers</a>
        </li>
      </ul>
    </div>
  );
}

export default ActivityBar;

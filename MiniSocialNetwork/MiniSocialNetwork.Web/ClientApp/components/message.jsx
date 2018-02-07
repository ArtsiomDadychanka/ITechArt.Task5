import React from 'react';

const Message = ({ isOwn = false }) => {
  const whose = isOwn ?
    'message_own' :
    'message_else';

  return (
    <div className={`message ${whose}`}>
      <div className="message__text">
        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eius obcaecati ullam quam tempora, dolorum esse repellat ex, in inventore provident mollitia saepe vitae, alias et natus id itaque! Harum, impedit!
      </div>
    </div>
  );
}

export default Message;

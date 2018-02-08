import React from 'react';

const Message = ({ isOwn = false, text = 'some text', time = '' }) => {
  const whose = isOwn ?
    'message_own' :
    'message_else';

  return (
    <div className={`message ${whose}`}>
      <div className="message__text">
        {text}
        <br />
        {time}
      </div>
    </div>
  );
}

export default Message;

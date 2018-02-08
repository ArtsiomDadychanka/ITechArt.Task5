using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Web.Models;

namespace MiniSocialNetwork.Web.Hubs
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        #region---Data Members---
        static List<UserDetails> ConnectedUsers = new List<UserDetails>(); // redundant
        static List<MessageDetails> CurrentMessage = new List<MessageDetails>();
        #endregion

        

        public void Connect(string username, string userId)
        {
            var id = Context.ConnectionId;

            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new UserDetails { ConnectionId = id, UserName = username + "-" + userId, UserId = userId });
            }
            UserDetails CurrentUser = ConnectedUsers.Where(u => u.ConnectionId == id).FirstOrDefault();
            // send to caller           
            Clients.Caller.onConnected(CurrentUser.UserId, CurrentUser.UserName, ConnectedUsers, CurrentMessage, CurrentUser.UserId);
            // send to all except caller client           
            Clients.AllExcept(CurrentUser.ConnectionId).onNewUserConnected(CurrentUser.UserId, CurrentUser.UserName, CurrentUser.UserId);
        }

        //public void SendPrivateMessage(string toUserId, string message)
        //{
        //    try
        //    {
        //        string fromconnectionid = Context.ConnectionId;
        //        string strfromUserId = (ConnectedUsers.Where(u => u.ConnectionId == Context.ConnectionId).Select(u => u.UserID).FirstOrDefault()).ToString();
        //        int _fromUserId = 0;
        //        int.TryParse(strfromUserId, out _fromUserId);
        //        int _toUserId = 0;
        //        int.TryParse(toUserId, out _toUserId);
        //        List<UserDetails> FromUsers = ConnectedUsers.Where(u => u.UserID == _fromUserId).ToList();
        //        List<UserDetails> ToUsers = ConnectedUsers.Where(x => x.UserID == _toUserId).ToList();

        //        if (FromUsers.Count != 0 && ToUsers.Count() != 0)
        //        {
        //            foreach (var ToUser in ToUsers)
        //            {
        //                // send to                                                                                            //Chat Title
        //                Clients.Client(ToUser.ConnectionId).sendPrivateMessage(_fromUserId.ToString(), FromUsers[0].UserName, FromUsers[0].UserName, message);
        //            }


        //            foreach (var FromUser in FromUsers)
        //            {
        //                // send to caller user                                                                                //Chat Title
        //                Clients.Client(FromUser.ConnectionId).sendPrivateMessage(_toUserId.ToString(), FromUsers[0].UserName, ToUsers[0].UserName, message);
        //            }
        //            // send to caller user
        //            //Clients.Caller.sendPrivateMessage(_toUserId.ToString(), FromUsers[0].UserName, message);
        //            //ChatDB.Instance.SaveChatHistory(_fromUserId, _toUserId, message);
        //            MessageDetails _MessageDeail = new MessageDetails { FromUserId = _fromUserId, FromUserName = FromUsers[0].UserName, ToUserId = _toUserId, ToUserName = ToUsers[0].UserName, Message = message };
        //        }
        //    }
        //    catch { }
        //}

        //public void RequestLastMessage(int FromUserID, int ToUserID)
        //{
        //    List<MessageDetails> CurrentChatMessages = (from u in CurrentMessage where ((u.FromUserId == FromUserID && u.ToUserId == ToUserID) || (u.FromUserID == ToUserID && u.ToUserID == FromUserID)) select u).ToList();
        //    //send to caller user
        //    Clients.Caller.GetLastMessages(ToUserID, CurrentChatMessages);
        //}

        //public void SendUserTypingRequest(string toUserId)
        //{
        //    string strfromUserId = (ConnectedUsers.Where(u => u.ConnectionId == Context.ConnectionId).Select(u => u.UserId).FirstOrDefault()).ToString();

        //    int _toUserId = 0;
        //    int.TryParse(toUserId, out _toUserId);
        //    List<UserDetails> ToUsers = ConnectedUsers.Where(x => x.UserId == _toUserId).ToList();

        //    foreach (var ToUser in ToUsers)
        //    {
        //        // send to                                                                                            
        //        Clients.Client(ToUser.ConnectionId).ReceiveTypingRequest(strfromUserId);
        //    }
        //}

        public override Task OnConnected()
        {
            var s = Context.ConnectionId;
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            //var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            //if (item != null)
            //{
            //    ConnectedUsers.Remove(item);
            //    if (ConnectedUsers.Where(u => u.UserID == item.UserID).Count() == 0)
            //    {
            //        var id = item.UserID.ToString();
            //        Clients.All.onUserDisconnected(id, item.UserName);
            //    }
            //}
            return base.OnDisconnected(stopCalled);
        }
    }
}

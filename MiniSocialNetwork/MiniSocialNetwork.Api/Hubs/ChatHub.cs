using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Interfaces;

namespace MiniSocialNetwork.Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IUserService userService;
        private readonly IDialogService dialogService;
        private readonly IMessageService messageService;

        private static readonly List<DialogDTO> Dialogs = new List<DialogDTO>();

        public ChatHub(IUserService userService, IDialogService dialogService, IMessageService messageService)
        {
            this.userService = userService;
            this.dialogService = dialogService;
            this.messageService = messageService;
        }

        public async void Register(string currentUserId, string chatedUserId)
        {
            var id = Context.ConnectionId;
            var usersDialogs = await dialogService.GetUserDialogsAsync(currentUserId);
            // TODO: FIX
            // Wrong func
            var dialog = usersDialogs.FirstOrDefault(d => (d.OneUserId == currentUserId) || (d.OtherUserId == chatedUserId));
            // FIX
            if (dialog == null)
            {
                dialog = (await dialogService.CreateDialogAsync(new DialogDTO()
                {
                    OneUserId = currentUserId,
                    OtherUserId = chatedUserId
                })).Data;
            }

            await Groups.Add(id, dialog.Id);
        }

        public void Send(string currentUserId, string message)
        {
            var userDialog = Dialogs.FirstOrDefault(d => d.OtherUserId == currentUserId ||
                                                         d.OneUserId == currentUserId);
            if (userDialog != null)
            {
                Clients.OthersInGroup(userDialog.Id);
                messageService.CreateMessage(new MessageDTO()
                {
                    DialogId = userDialog.Id,
                    Text = message
                });
            }
        }
    }
}
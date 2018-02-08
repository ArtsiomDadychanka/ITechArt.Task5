using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Bll.Infrastructure;
using MiniSocialNetwork.Bll.Interfaces;
using MiniSocialNetwork.Dal.Entities;
using MiniSocialNetwork.Dal.Interfaces;

namespace MiniSocialNetwork.Bll.Services
{
    public class MessageService : Service, IMessageService
    {
        public MessageService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<OperationDetails<MessageDTO>> CreateMessage(MessageDTO messageDto)
        {
            Message messageToCreate = Mapper.Map<MessageDTO, Message>(messageDto);

            Message createdMessage = Uow.MessagesRepository.CreateMessage(messageToCreate);

            if (createdMessage == null)
            {
                return new OperationDetails<MessageDTO>(false, "Message was not created", "", null);
            }

            await Uow.SaveAsync();
            return new OperationDetails<MessageDTO>(
                succedeed: true,
                message: "Message created successfully.",
                prop: "",
                data: Mapper.Map<Message, MessageDTO>(createdMessage));
        }

        public async Task<IEnumerable<MessageDTO>> GetMessagesByDialogId(string dialogId)
        {
            var messages = await Uow.MessagesRepository.GetMessagesByDialogId(dialogId).ToListAsync();
            IEnumerable<MessageDTO> messageDtos = Mapper.Map<IEnumerable<Message>, IEnumerable<MessageDTO>>(messages);

            return messageDtos;
        }
    }
}

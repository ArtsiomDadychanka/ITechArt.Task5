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
    public class DialogService : Service, IDialogService
    {
        public DialogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<OperationDetails<DialogDTO>> CreateDialogAsync(DialogDTO dialog)
        {
            Dialog createdDialog = Uow.DialogRepository.CreateDialog(Mapper.Map<DialogDTO, Dialog>(dialog));

            if (createdDialog == null)
            {
                return new OperationDetails<DialogDTO>(false, "Dialog was not created.", "", null);
            }

            await Uow.SaveAsync();

            return new OperationDetails<DialogDTO>(
                succedeed: true,
                message: "Dialog created successfully.",
                prop: "",
                data: Mapper.Map<Dialog, DialogDTO>(createdDialog));
        }

        public async Task<OperationDetails<DialogDTO>> GetDialogByIdAsync(string id)
        {
            Dialog dialog = await Uow.DialogRepository.GetDialogByIdAsync(id);

            if (dialog == null)
            {
                return new OperationDetails<DialogDTO>(false, "Dialog not found.", "", null);
            }

            return new OperationDetails<DialogDTO>(
                succedeed: true,
                message: "Dialog found successfully.",
                prop: "",
                data: Mapper.Map<Dialog, DialogDTO>(dialog));
        }

        public async Task<IEnumerable<DialogDTO>> GetUserDialogsAsync(string userId)
        {
            var userDialogs = await Uow.DialogRepository.GetUserDialogs(userId).ToListAsync();

            return Mapper.Map<IEnumerable<Dialog>, IEnumerable<DialogDTO>>(userDialogs);
        }
    }
}

using EnterpriseClientService.Application.Commands;
using EnterpriseClientService.Application.Dtos;
using EnterpriseClientService.Application.Extensions;
using EnterpriseClientService.Application.Notifications;
using EnterpriseClientService.Domain.Entities;
using EnterpriseClientService.Domain.Enumerables;
using EnterpriseClientService.Domain.Interfaces.Models;
using EnterpriseClientService.Domain.Interfaces.Repositories;
using EnterpriseClientService.Domain.Interfaces.UnityOfWork;
using EnterpriseClientService.Domain.Models;
using MediatR;

namespace EnterpriseClientService.Application.Handlers.Commands
{
    public class EnterpriseClienteCommandHandler : IRequestHandler<CreateEnterpriseClientCommand, IResult<EnterpriseClientDto>>,
                                                    IRequestHandler<UpdateEnterpriseClientCommand, IResult<EnterpriseClientDto>>,
                                                    IRequestHandler<DeleteEnterpriseClientCommand, IResult<EnterpriseClientDto>>
    {
        private readonly IRepository<EnterpriseClient> _repository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMediator _mediator;
        public EnterpriseClienteCommandHandler(IRepository<EnterpriseClient> repository, IUnityOfWork unityOfWork, IMediator mediator)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
            _mediator = mediator;
        }

        public async Task<IResult<EnterpriseClientDto>> Handle(CreateEnterpriseClientCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(command.EnterpriseClientName))
                return await Result<EnterpriseClientDto>.FailAsync(nameof(command.EnterpriseClientName), "Property cannot be empty.");

            if (command.EnterpriseClientName.Length > 150)
                return await Result<EnterpriseClientDto>.FailAsync(nameof(command.EnterpriseClientName), "Property cannot be longer than 150 characters.");

            var entity = new EnterpriseClient
            {
                EnterpriseClientName = command.EnterpriseClientName,
                EnterpriseScale = command.EnterpriseClientScale
            };

            await _repository.InsertAsync(entity, cancellationToken);

            await _unityOfWork.CommitAsync(cancellationToken);

            await _mediator.Publish(new EnterpriseClientActionNotification(entity, EnumActionNotification.Created), cancellationToken);

            return await Result<EnterpriseClientDto>.SuccessAsync(entity.MapToDto());
        }

        public async Task<IResult<EnterpriseClientDto>> Handle(UpdateEnterpriseClientCommand command, CancellationToken cancellationToken)
        {
            if (command.EnterpriseClientId == Guid.Empty)
                return await Result<EnterpriseClientDto>.FailAsync(nameof(command.EnterpriseClientId), "Property cannot be empty.");

            if (string.IsNullOrWhiteSpace(command.EnterpriseClientName))
                return await Result<EnterpriseClientDto>.FailAsync(nameof(command.EnterpriseClientName), "Property cannot be empty.");

            if (command.EnterpriseClientName.Length > 150)
                return await Result<EnterpriseClientDto>.FailAsync(nameof(command.EnterpriseClientName), "Property cannot be longer than 150 characters.");

            var entity = await _repository.GetAsync(command.EnterpriseClientId, cancellationToken);

            if (entity is null)
                return await Result<EnterpriseClientDto>.FailAsync("Data not found.");

            entity.EnterpriseClientName = command.EnterpriseClientName;
            entity.EnterpriseScale = command.EnterpriseScale;

            _repository.Update(entity);

            await _unityOfWork.CommitAsync(cancellationToken);

            await _mediator.Publish(new EnterpriseClientActionNotification(entity, EnumActionNotification.Updated), cancellationToken);

            return await Result<EnterpriseClientDto>.SuccessAsync(entity.MapToDto());
        }

        public async Task<IResult<EnterpriseClientDto>> Handle(DeleteEnterpriseClientCommand command, CancellationToken cancellationToken)
        {
            if (command.EnterpriseClientId == Guid.Empty)
                return await Result<EnterpriseClientDto>.FailAsync(nameof(command.EnterpriseClientId), "Property cannot be empty.");

            var entity = await _repository.GetAsync(command.EnterpriseClientId, cancellationToken);

            if (entity is null)
                return await Result<EnterpriseClientDto>.FailAsync("Data not found.");

            _repository.Delete(entity);

            await _unityOfWork.CommitAsync(cancellationToken);

            await _mediator.Publish(new EnterpriseClientActionNotification(entity, EnumActionNotification.Deleted), cancellationToken);

            return await Result<EnterpriseClientDto>.SuccessAsync("Data deleted successfull");

        }
    }
}

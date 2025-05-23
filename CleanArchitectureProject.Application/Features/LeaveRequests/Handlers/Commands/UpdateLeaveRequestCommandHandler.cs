using AutoMapper;
using CleanArchitectureProject.Application.DTOs.LeaveRequest.Validators;
using CleanArchitectureProject.Application.DTOs.LeaveType.Validators;
using CleanArchitectureProject.Application.Exceptions;
using CleanArchitectureProject.Application.Features.LeaveRequests.Requests.Commands;
using CleanArchitectureProject.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureProject.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.LeaveRequestDto !=  null)
            {
                _mapper.Map(request.LeaveRequestDto, leaveRequest);

                await _leaveRequestRepository.Update(leaveRequest);

            } else if(request.ChangeLeaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
            }

            return Unit.Value;
        }
    }
}

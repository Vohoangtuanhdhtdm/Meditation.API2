using AutoMapper;
using CleanArchitectureProject.Application.DTOs.LeaveAllocation.Validators;
using CleanArchitectureProject.Application.DTOs.LeaveRequest.Validators;
using CleanArchitectureProject.Application.Exceptions;
using CleanArchitectureProject.Application.Features.LeaveAllocations.Requests.Commands;
using CleanArchitectureProject.Application.Persistence.Contracts;
using CleanArchitectureProject.Application.Responses;
using CleanArchitectureProject.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureProject.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Allocations Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);

            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveAllocation.Id;

            return response;
        }
    }
}

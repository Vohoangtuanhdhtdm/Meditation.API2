using AutoMapper;
using CleanArchitectureProject.Application.DTOs.LeaveRequest.Validators;
using CleanArchitectureProject.Application.Exceptions;
using CleanArchitectureProject.Application.Features.LeaveRequests.Requests.Commands;
using CleanArchitectureProject.Application.Models;
using CleanArchitectureProject.Application.Persistence.Contracts;
using CleanArchitectureProject.Application.Persistence.Infrastructure;
using CleanArchitectureProject.Application.Responses;
using CleanArchitectureProject.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureProject.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository, 
            IMapper mapper, 
            ILeaveTypeRepository leaveTypeRepository,
            IEmailSender emailSender
        )
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
               

            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);

            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveRequest.Id;
            var email = new Email
            {
                To = "employee@org.com",
                Body = $"Your leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D} " +
                   $"has been submitted successfully.",
                Subject = "Leave Request Submitted"
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                //// Log or handle error, but don't throw...
            }

            return response;
        }
    }
}

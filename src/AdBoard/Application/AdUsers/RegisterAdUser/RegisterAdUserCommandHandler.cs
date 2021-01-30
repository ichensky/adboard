using Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AdUsers.RegisterAdUser
{
    //public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, UserDto>
    //{
    //    private readonly ICustomerRepository _customerRepository;
    //    private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
    //    private readonly IUnitOfWork _unitOfWork;

    //    public RegisterCustomerCommandHandler(
    //        ICustomerRepository customerRepository,
    //        ICustomerUniquenessChecker customerUniquenessChecker,
    //        IUnitOfWork unitOfWork)
    //    {
    //        this._customerRepository = customerRepository;
    //        _customerUniquenessChecker = customerUniquenessChecker;
    //        _unitOfWork = unitOfWork;
    //    }

    //    public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    //    {
    //        var customer = User.CreateRegistered(request.Email, request.Name, this._customerUniquenessChecker);

    //        await this._customerRepository.AddAsync(customer);

    //        await this._unitOfWork.CommitAsync(cancellationToken);

    //        return new CustomerDto { Id = customer.Id.Value };
    //    }
    //}
}

using AutoMapper;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class CustomerService : BaseService<Customer, CustomerRequestModel, CustomerResponseModel>, ICustomerService
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository, 
        IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public override async Task<CustomerResponseModel> Create(CustomerRequestModel entity,
        CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(entity);
        await _customerRepository.AddAsync(customer, cancellationToken);
        var response = await _customerRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerResponseModel>(customer);
    }

    public override async Task<CustomerResponseModel> GetById(ulong id, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.FindAsync(id, cancellationToken);

        return _mapper.Map<CustomerResponseModel>(customer);
    }
}
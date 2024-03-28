using AutoMapper;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository,
        IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerResponseModel> Create(CustomerRequestModel entity,
        CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(entity);
        await _customerRepository.AddAsync(customer, cancellationToken);
        await _customerRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerResponseModel>(customer);
    }

    public async Task<CustomerResponseModel> GetById(long id, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.FindAsync(id, cancellationToken);

        return _mapper.Map<CustomerResponseModel>(customer);
    }

    public async Task<CustomerResponseModel> Update(long id, CustomerRequestModel entity,
        CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.FindAsync(id, cancellationToken);

        var result = _mapper.Map(entity, customer);
        await _customerRepository.AddAsync(result, cancellationToken);
        await _customerRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerResponseModel>(result);
    }

    public async Task<List<CustomerResponseModel>> Get(int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var result = await _customerRepository.GetAllAsync(pageSize, pageNumber, cancellationToken);
        var customers = _mapper.Map<List<CustomerResponseModel>>(result);
        return customers;
    }

    public async Task<CustomerResponseModel> Delete(long id, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.FindAsync(id, cancellationToken);
        _customerRepository.Delete(customer);
        await _customerRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CustomerResponseModel>(customer);
    }
}
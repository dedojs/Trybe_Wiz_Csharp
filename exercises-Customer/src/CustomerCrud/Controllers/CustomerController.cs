using Microsoft.AspNetCore.Mvc;
using CustomerCrud.Core;
using CustomerCrud.Requests;
using CustomerCrud.Repositories;
using JsonFlatFileDataStore;

namespace CustomerCrud.Controllers;

[ApiController]
[Route("/customers")]
public class CustomerController : ControllerBase
{
	private readonly ICustomerRepository _db;

	public CustomerController(ICustomerRepository db)
	{
		_db = db;
	}

	[HttpGet]
	public ActionResult GetAll()
	{
		var customers = _db.GetAll();
		return Ok(customers);
	}

	[HttpGet("{id}", Name = "GetById")]
	public ActionResult GetById(int id)
	{
		var customer = _db.GetById(id);

		if (customer == null)
		{
			return NotFound("Customer not found");
		}

		return Ok(customer);
	}

	[HttpPost]
	public ActionResult Create(CustomerRequest customer)
	{
		var newCostumer = new Customer(_db.GetNextIdValue(), customer);
		_db.Create(newCostumer);
		
		return CreatedAtAction("GetById", new { id = newCostumer.Id }, newCostumer);
	}

    [HttpPut("{id}")]
    public ActionResult Update(int id, CustomerRequest updateCustomer)
    {
		var result = _db.Update(id, updateCustomer);

        if (!result)
		{
			return NotFound("Customer not found");
		}

        return Ok($"Customer {id} updated");
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = _db.Delete(id);

        if (!result)
        {
            return NotFound("Customer not found");
        }

        return NoContent();
    }



}

using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Services.Contracts;
using WebApi.Clients.ParkingService;
using System.Net.Http;

namespace WebApi.Controllers;

[ApiController]
[Route("api/Parking")]
public class ParkingController:ControllerBase
{
    private readonly IParkingService _service;
    private readonly IMapper _mapper;
    private readonly ParkingServiceClient _client;

    public ParkingController(IParkingService service, IMapper mapper, ParkingServiceClient client)
    {
        _service = service;
        _mapper = mapper;
        _client = client;
    }
   
    [HttpGet("list/{page}/{itemPerPage}")]
    public async Task<IActionResult> GetPage([FromRoute]int page, [FromRoute]int itemPerPage, CancellationToken token)
    {
        var result = await _client.GetPage(page, itemPerPage, token);
        if (result == null)
            return NotFound();

        return Ok(result);
        //var parkingDtos = await _service.GetPaged(page, itemPerPage, token);
        //var result = _mapper.Map<List<ParkingResultModel>>(parkingDtos);
        //return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute]int id)
    {
        var result = await _client.GetAsync(id);
        if (result == null)
            return NotFound();
        
        return Ok(result);
        //return Ok(_mapper.Map<ParkingResultModel>(await _service.GetByID(id)));
    }

    [HttpPost]
    public async Task<int> AddAsync([FromBody]ParkingModel model, CancellationToken token)
    {
        return await _client.AddAsync(model, token);
        //var dto = _mapper.Map<ParkingModel, ParkingDTO>(model);
        //return await _service.Create(dto, token);
    }

    [HttpPut("{id}")]
    public async Task<int> EditAsync([FromRoute]int id, [FromBody]ParkingModel model, CancellationToken token)
    {
        return await _client.EditAsync(id, model, token);
        //var dto = _mapper.Map<ParkingModel, ParkingDTO>(model); 
        //await _service.Update(id, dto, token);
        //return Ok();
    }

    [HttpDelete]
    public async Task Delete(int id, CancellationToken token)
    {
        await _client.Delete(id, token);
    }
    
}
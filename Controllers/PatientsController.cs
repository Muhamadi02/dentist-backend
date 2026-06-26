using dentist.api.Application.Interfaces;
using dentist.api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace dentist.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetAll()
    {
        return Ok(await _patientService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetById(int id)
    {
        var patient = await _patientService.GetByIdAsync(id);

        if (patient == null)
        {
            return NotFound();
        }
        return Ok(patient);
    }

    [HttpPost]
    public async Task<ActionResult<Patient>> Create(Patient patient)
    {
        var createdPatient = await _patientService.CreateAsync(patient);
        
        return CreatedAtAction(nameof(GetById), new { id = createdPatient.Id }, createdPatient);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Patient>> Update(int id, Patient patient)
    {
        if (id != patient.Id)
        {
            return BadRequest();
        }

        var updatedPatient = await _patientService.UpdateAsync(id, patient);
        if (updatedPatient == null)
        {
            return NotFound();
        }

        return Ok(updatedPatient);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _patientService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
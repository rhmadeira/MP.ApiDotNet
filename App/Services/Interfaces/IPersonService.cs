﻿using App.DTOS;

namespace App.Services.Interfaces;

public interface IPersonService
{

    Task<ResultService<PersonDTO>> CreateAsync(PersonDTO person);
    Task<ResultService<ICollection<PersonDTO>>> GetAsync();
    Task<ResultService<PersonDTO>> GetByIdAsync(int id);
    Task<ResultService<PersonDTO>> UpdetateAsync(PersonDTO person);
    Task<ResultService> DeleteAsync(int id);

}

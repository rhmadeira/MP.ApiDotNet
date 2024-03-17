

namespace App.DTOs;

public class PagedBaseResponseDTO<T>
{
    public PagedBaseResponseDTO(int totalPageRegisters, List<T> data)
    {
        TotalPageRegisters = totalPageRegisters;
        Data = data;
    }

    public int TotalPages { get; set; }
    public int TotalPageRegisters { get; private set; }
    public List<T> Data { get; private set; }
}

using MsaterResumeIR.Domain.Entities;

namespace MsaterResumeIR.Domain.Interface;
public interface ICategoryRepository
{
    void Add(Category Category);
    void Update(Category Category);
    void Delete(Category Category);
}

using Ass_6.Models;

namespace Ass_6.Services;

public interface IPersonService{
    List<Person> GetAll();
    Person GetOne(int index);
    void Create(Person person);
    void Update(int index , Person person);
    void Delete(int index);

    
}
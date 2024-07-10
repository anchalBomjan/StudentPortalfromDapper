using StudentPortalfromDapper.Models;

namespace StudentPortalfromDapper.Repositories
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(StudentModel student);
        Task<IEnumerable<StudentModel>> GetStudentsAsync();
        Task<StudentModel> GetStudentByIdAsync(Guid id);
        Task UpdateStudentAsync(StudentModel student);
        Task DeleteStudentAsync(Guid id);

    }
}

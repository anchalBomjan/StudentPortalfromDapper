using Dapper;
using StudentPortalfromDapper.Data;
using StudentPortalfromDapper.Models;

namespace StudentPortalfromDapper.Repositories
{
    public class StudentRepository:IStudentRepository
    {

        private readonly DapperDbContext _dbContext;
        public StudentRepository(DapperDbContext dapperDbContext )
        {
             _dbContext = dapperDbContext;
        }

        public async Task AddStudentAsync(StudentModel student)
        {
            var sql = "INSERT INTO Students (ID, Name, Email, Phone, Subscribed) VALUES (@ID, @Name, @Email, @Phone, @Subscribed)";
            student.ID = Guid.NewGuid();
            await _dbContext.CreateConnection().ExecuteAsync(sql, student);
        }

        public async Task<IEnumerable<StudentModel>> GetStudentsAsync()
        {
            var sql = "SELECT * FROM Students";

            using var connection = _dbContext.CreateConnection();
            return await connection.QueryAsync<StudentModel>(sql);
           
        }

        public async Task<StudentModel> GetStudentByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM Students WHERE ID = @ID";
            return await _dbContext.CreateConnection().QueryFirstOrDefaultAsync<StudentModel>(sql, new { ID = id });
        }

        public async Task UpdateStudentAsync(StudentModel student)
        {
            var sql = "UPDATE Students SET Name = @Name, Email = @Email, Phone = @Phone, Subscribed = @Subscribed WHERE ID = @ID";
           
            
            await _dbContext.CreateConnection().ExecuteAsync(sql, student);
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            var sql = "DELETE FROM Students WHERE ID = @ID";
            await _dbContext.CreateConnection().ExecuteAsync(sql, new { ID = id });
        }
    }
}

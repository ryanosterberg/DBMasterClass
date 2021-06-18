using CodeTheWay.Web.Ui.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private AppDbContext AppDbContext;

        public StudentsRepository(AppDbContext dbContext)
        {
            AppDbContext = dbContext;
        }

        public async Task<Student> Create(Student student)
        {
            var result = await this.AppDbContext.AddAsync(student);
            await AppDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await AppDbContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudent(Guid id)
        {
            return await AppDbContext.Students.FirstOrDefaultAsync(i => i.Id == id);
            //return await AppDbContext.Students.FindAsync(id);
        }

        public async Task<Student> Delete(Student model)
        {
            AppDbContext.Students.Remove(model);
            await AppDbContext.SaveChangesAsync();

            return model;
        }

        public async Task<Student> Update(Student model)
        {
            var result = AppDbContext.Students.Update(model);
            await AppDbContext.SaveChangesAsync();
            return result.Entity;
            
        }
    }
}


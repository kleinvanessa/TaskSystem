using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public UserRepository(TaskSystemDBContext context) 
        {
            _dbContext = context;       
        }

        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _dbContext.Users.ToListAsync();

        }

        public async Task<UserModel> SearchByUserId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await SearchByUserId(id);

            if (userById == null)
            {
                throw new Exception($"ERRO: Usuario para o Id:{id} nao foi encontrado!");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;

        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await SearchByUserId(id);

            if (userById == null)
            {
                throw new Exception($"ERRO: Usuario para o Id:{id} nao foi encontrado!");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            
            return true;
        }
    }
}

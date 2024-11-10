using commerce.DTOs;
using commerce.Interfaces;
using commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace commerce.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly CommerceDbContext _context;
        public UserRepo(CommerceDbContext context)
        {
            _context = context;
        }
        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _context.Users.Include(u => u.Products).FirstOrDefaultAsync(u => id == u.Id);

            if (user != null)
            {
                UserDTO udto = new UserDTO
                {
                    Name = user.Name,
                    Email = user.Email,
                    ProductName = user.Products.Select(x => x.Name).ToList(),
                };
                return udto;

            }


            return null;
        }

        public async Task<UserDTO> GetUserByName(string name)
        {
            var user = await _context.Users.Include(u => u.Products).FirstOrDefaultAsync(u => name == u.Name);

            if (user != null)
            {
                UserDTO udto = new UserDTO
                {
                    Name = user.Name,
                    Email = user.Email,
                    ProductName = user.Products.Select(x => x.Name).ToList(),
                };
                return udto;

            }


            return null;
        }
        public async Task<List<UserDTO>> GetUsers()
        {
            var alluser = await _context.Users
                .Include(u => u.Products)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    ProductName = u.Products.Select(u => u.Name).ToList(),
                }).ToListAsync();

            return alluser;
        }

        public async Task<UserDTO> AddUser(UserDTO userDTO)
        {
            var products = await _context.Products.Where(p => userDTO.ProductId.Contains(p.ProductId)).ToListAsync();
            

            var user = new User
            {

                Email = userDTO.Email,
                Name = userDTO.Name,
                Password = "123",
                
                Products = products,

            };

            if (user != null)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            return userDTO;
        }


        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            var products = await _context.Products.Where(p => userDTO.ProductId.Contains(p.ProductId)).ToListAsync();
            var user = await _context.Users.Include(u => u.Products).FirstOrDefaultAsync(user => user.Id == userDTO.Id);
           

            if (user != null)
            {
                user.Email = userDTO.Email;
                user.Name = userDTO.Name;
                user.Products = products;
                await _context.SaveChangesAsync();
                return userDTO;
            }

            return null;
        }
    }

}


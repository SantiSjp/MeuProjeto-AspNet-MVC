using MeuProjeto.Data;
using MeuProjeto.Models;
using MeuProjeto.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MeuProjeto.Services
{
    public class SellerService
    {
        private readonly MeuProjetoContext _context;

        public SellerService(MeuProjetoContext context)
        {
            _context = context;
        }


        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            // obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            // Eager Loading - Join na tabela Departments com Include
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(Seller obj)
        {

            // Verefica se existe um vendedor com o ID enviado
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("ID not Found");
            }

            // Interceptar Exceção de acesso a dados e relançar em nivel de serviço
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}

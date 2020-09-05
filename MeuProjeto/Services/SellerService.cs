﻿using MeuProjeto.Data;
using MeuProjeto.Models;
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

    }
}
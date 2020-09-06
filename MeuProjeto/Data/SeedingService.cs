using MeuProjeto.Models;
using MeuProjeto.Models.Enums;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjeto.Data
{
    public class SeedingService
    {

        private MeuProjetoContext _context;
        public SeedingService(MeuProjetoContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; //DB ja foi populado
            }


            Department D1 = new Department(1, "Computers");
            Department D2 = new Department(2, "Electronics");
            Department D3 = new Department(3, "Books");
            Department D4 = new Department(4, "Fashion");

            Seller S1 = new Seller(1, "Joao", "joao@gmail.com", new DateTime(1998, 04, 04), 1200.00, D1);
            Seller S2 = new Seller(2, "Santi", "Santi@gmail.com", new DateTime(1995, 06, 23), 2300.00, D2);
            Seller S3 = new Seller(3, "maria", "maria@gmail.com", new DateTime(1997, 04, 30), 2100.00, D3);
            Seller S4 = new Seller(4, "Raaby", "Raaby@gmail.com", new DateTime(1999, 03, 21), 3200.00, D2);
            Seller S5 = new Seller(5, "Marcio", "Marcio@gmail.com", new DateTime(1993, 05, 22), 1100.00, D4);
            Seller S6 = new Seller(6, "Carol", "Carol@gmail.com", new DateTime(1994, 07, 10), 2500.00, D4);
            Seller S7 = new Seller(7, "Jonas", "Jonas@gmail.com", new DateTime(1995, 11, 12), 2700.00, D1);
            Seller S8 = new Seller(8, "marcos", "marcos@gmail.com", new DateTime(1994, 12, 07), 2600.00, D2);
            Seller S9 = new Seller(9, "gustavo", "gustavo@gmail.com", new DateTime(1998, 02, 06), 2800.00, D4);
            Seller S10 = new Seller(10, "diego", "diego@gmail.com", new DateTime(1991, 01, 11), 3100.00, D3);


            SalesRecord R1 = new SalesRecord(1, new DateTime(2020, 09, 04), 250.00, SaleStatus.Billed, S1);
            SalesRecord R2 = new SalesRecord(2, new DateTime(2020, 08, 10), 112.00, SaleStatus.Billed, S2);
            SalesRecord R3 = new SalesRecord(3, new DateTime(2020, 07, 11), 320.00, SaleStatus.Billed, S3);
            SalesRecord R4 = new SalesRecord(4, new DateTime(2020, 01, 04), 2250.00, SaleStatus.Billed, S4);
            SalesRecord R5 = new SalesRecord(5, new DateTime(2020, 02, 05), 2220.00, SaleStatus.Billed, S5);
            SalesRecord R6 = new SalesRecord(6, new DateTime(2020, 01, 09), 1230.00, SaleStatus.Billed, S6);
            SalesRecord R7 = new SalesRecord(7, new DateTime(2020, 04, 20), 2322.00, SaleStatus.Billed, S7);
            SalesRecord R8 = new SalesRecord(8, new DateTime(2020, 07, 22), 1111.00, SaleStatus.Billed, S8);
            SalesRecord R9 = new SalesRecord(9, new DateTime(2020, 08, 15), 2431.00, SaleStatus.Billed, S9);
            SalesRecord R10 = new SalesRecord(10, new DateTime(2020, 06, 10), 123.00, SaleStatus.Billed, S10);
            SalesRecord R11 = new SalesRecord(11, new DateTime(2020, 11, 17), 2521.00, SaleStatus.Billed, S10);
            SalesRecord R12 = new SalesRecord(12, new DateTime(2020, 10, 13), 1321.00, SaleStatus.Billed, S1);
            SalesRecord R13 = new SalesRecord(13, new DateTime(2020, 11, 28), 1231.00, SaleStatus.Billed, S2);
            SalesRecord R14 = new SalesRecord(14, new DateTime(2020, 04, 24), 1210.00, SaleStatus.Billed, S3);
            SalesRecord R15 = new SalesRecord(15, new DateTime(2020, 07, 20), 2312.00, SaleStatus.Billed, S6);
            SalesRecord R16 = new SalesRecord(16, new DateTime(2020, 12, 22), 1675.00, SaleStatus.Billed, S4);
            SalesRecord R17 = new SalesRecord(17, new DateTime(2020, 11, 21), 1932.00, SaleStatus.Billed, S8);
            SalesRecord R18 = new SalesRecord(18, new DateTime(2020, 10, 30), 1942.00, SaleStatus.Billed, S2);

            _context.Department.AddRange(D1, D2, D3, D4);

            _context.Seller.AddRange(S1, S2, S3, S4, S5, S6, S7, S8, S9, S10);

            _context.SalesRecord.AddRange(R1, R2, R3, R4, R5, R6, R7, R8, R9, R10, 
                R11, R12, R13, R14, R15, R16, R17, R18);

            _context.SaveChanges();

        }

    }
}

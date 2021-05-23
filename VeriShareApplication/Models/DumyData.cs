using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace VeriShareApplication.Models
{
    public class DumyData
    {

        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            List<CustomerViewModel> listA = new List<CustomerViewModel>();
            listA.Add(new CustomerViewModel() { CustomerId = 1, FirstName = "Sanele", LastName = "BCK", Email = "Sanele@BCK", phone = "0238420831" });
            listA.Add(new CustomerViewModel() { CustomerId = 2, FirstName = "Alex", LastName = "TT", Email = "Alex@TT", phone = "0238420831" });
            listA.Add(new CustomerViewModel() { CustomerId = 3, FirstName = "Luke", LastName = "JYA", Email = "Luke@JYA", phone = "0238420831" });
            listA.Add(new CustomerViewModel() { CustomerId = 4, FirstName = "Johan", LastName = "LAY", Email = "Johan@LAY", phone = "0238420831" });
            listA.Add(new CustomerViewModel() { CustomerId = 5, FirstName = "Pita", LastName = "WYA", Email = "Pita@WYA", phone = "0238420831" });
            listA.Add(new CustomerViewModel() { CustomerId = 6, FirstName = "Geoge", LastName = "MAU", Email = "Geoge@MAU", phone = "0238420831" });
            return listA;
        }


        public async Task<List<AgreementTypeViewModel>> GetAlltypes()
        {
            List<AgreementTypeViewModel> listA = new List<AgreementTypeViewModel>();
            listA.Add(new AgreementTypeViewModel() { AgreementTypeId = 1, AgreementName = "Mortgage agreements" });
            listA.Add(new AgreementTypeViewModel() { AgreementTypeId = 2, AgreementName = "Credit facilities" });
            listA.Add(new AgreementTypeViewModel() { AgreementTypeId = 3, AgreementName = "Developmental credit agreements For development of a small business" });
            listA.Add(new AgreementTypeViewModel() { AgreementTypeId = 4, AgreementName = "Developmental credit agreements For low income housing (unsecured" });
            listA.Add(new AgreementTypeViewModel() { AgreementTypeId = 5, AgreementName = "Short term credit transactions" });
            listA.Add(new AgreementTypeViewModel() { AgreementTypeId = 6, AgreementName = "Other credit agreements" });
            return listA;
        }

    }
}
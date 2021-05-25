using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VeriShareApplication.Models;

namespace VeriShareApplication.Logic
{
    public class CustomerLoanService
    {


        public async Task<List<CustomerLoanViewModel>> GetAllCustomerLoans()
        {
            HttpClient client = new HttpClient();
            List<CustomerLoanViewModel> Customersobj = new List<CustomerLoanViewModel>();
            const string url = "http://localhost:50603/api/Customer";
            HttpResponseMessage response = await client.GetAsync($"{url}");
            // response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var CustomerResponse = response.Content.ReadAsStringAsync().Result;

                Customersobj = JsonConvert.DeserializeObject<List<CustomerLoanViewModel>>(CustomerResponse);
                return Customersobj;
            }
            //  return posts;
            return Customersobj;
        }


        public async Task<CustomerLoanViewModel> AddCustomerLoan(string Startdate, string Enddate, double Reporate, int AgreementTypeId, double Amount)
        {
            //{ Stardte}/{ Enddate}/{ Reporate}/{ AgreementTypeId}/{ Amount}
            HttpClient client = new HttpClient();
            CustomerLoanViewModel Customersobj = new CustomerLoanViewModel();
            const string url = "http://localhost:50603/api/CustomerLoan";
            HttpResponseMessage response = await client.GetAsync($"{url}/{Startdate}/{Enddate}/{Reporate}/{AgreementTypeId}/{Amount}");
            // response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var CustomerResponse = response.Content.ReadAsStringAsync().Result;

                Customersobj = JsonConvert.DeserializeObject<CustomerLoanViewModel>(CustomerResponse);
                return Customersobj;
            }
            //  return posts;
            return Customersobj;
        }

        public async Task<CustomerLoanViewModel> GetCustomerLoanById(int? CustomerId)
        {
            HttpClient client = new HttpClient();
            CustomerLoanViewModel CustomerLoanobj = new CustomerLoanViewModel();
            const string url = "http://localhost:53854/api/Customer";
            HttpResponseMessage response = await client.GetAsync($"{url}/{CustomerId}");
            // response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var CustomerLoanResponse = response.Content.ReadAsStringAsync().Result;

                CustomerLoanobj = JsonConvert.DeserializeObject<CustomerLoanViewModel>(CustomerLoanResponse);
                return CustomerLoanobj;
            }
            //  return posts;
            return CustomerLoanobj;
        }

    }
}
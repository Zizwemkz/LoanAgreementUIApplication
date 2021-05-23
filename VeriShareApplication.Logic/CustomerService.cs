using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VeriShareApplication.Models;
using System.Web;

namespace VeriShareApplication.Logic
{
    public class CustomerService
    {

        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            HttpClient client = new HttpClient();
            List<CustomerViewModel> Customersobj = new List<CustomerViewModel>();
            const string url = "http://localhost:50603/api/Customer";
            HttpResponseMessage response = await client.GetAsync($"{url}");
            // response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var CustomerResponse = response.Content.ReadAsStringAsync().Result;

                Customersobj = JsonConvert.DeserializeObject<List<CustomerViewModel>>(CustomerResponse);
                return Customersobj;
            }
            //  return posts;
            return Customersobj;
        }


        public async Task<bool> AddCustomer(CustomerViewModel model)
        {

            HttpClient client = new HttpClient();

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage respose = await client.PostAsync("http://localhost:50603/api/Customer", content);

            if (respose.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<CustomerViewModel> GetCustomersById(int? CustomerId)
        {
            HttpClient client = new HttpClient();
            CustomerViewModel Departmentobj = new CustomerViewModel();
            const string url = "http://localhost:53854/api/Customer";
            HttpResponseMessage response = await client.GetAsync($"{url}/{CustomerId}");
            // response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var DepartmenyResponse = response.Content.ReadAsStringAsync().Result;

                Departmentobj = JsonConvert.DeserializeObject<CustomerViewModel>(DepartmenyResponse);
                return Departmentobj;
            }
            //  return posts;
            return Departmentobj;
        }

    }
}
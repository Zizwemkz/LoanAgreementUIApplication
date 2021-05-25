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
    public class AgreementTypeService
    {


        public async Task<List<AgreementTypeViewModel>> GetAllAgreementTypes()
        {
            HttpClient client = new HttpClient();
            List<AgreementTypeViewModel> Customersobj = new List<AgreementTypeViewModel>();
            const string url = "http://localhost:50603/api/Customer";
            HttpResponseMessage response = await client.GetAsync($"{url}");
            // response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var CustomerResponse = response.Content.ReadAsStringAsync().Result;

                Customersobj = JsonConvert.DeserializeObject<List<AgreementTypeViewModel>>(CustomerResponse);
                return Customersobj;
            }
            //  return posts;
            return Customersobj;
        }


        public async Task<bool> AddAgreementType(AgreementTypeViewModel model)
        {

            HttpClient client = new HttpClient();

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage respose = await client.PostAsync("http://localhost:50603/api/AgreementType", content);

            if (respose.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<AgreementTypeViewModel> GetAgreementTypeById(int? AgreementId)
        {
            HttpClient client = new HttpClient();
            AgreementTypeViewModel AgreementTypeobj = new AgreementTypeViewModel();
            const string url = "http://localhost:53854/api/AgreementType";
            HttpResponseMessage response = await client.GetAsync($"{url}/{AgreementId}");
            // response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var AgreementTypeResponse = response.Content.ReadAsStringAsync().Result;

                AgreementTypeobj = JsonConvert.DeserializeObject<AgreementTypeViewModel>(AgreementTypeResponse);
                return AgreementTypeobj;
            }
            //  return posts;
            return AgreementTypeobj;
        }

    }
}
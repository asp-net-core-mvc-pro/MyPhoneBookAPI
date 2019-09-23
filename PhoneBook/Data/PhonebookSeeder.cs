using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data
{
    using Phonebook.Data.Entities;

    public class PhonebookSeeder
    {
        private readonly PhonebookContext _ctx;
        private readonly IHostingEnvironment _hosting;
        

        public PhonebookSeeder(PhonebookContext phonebookContext, IHostingEnvironment hosting)
        {
            this._ctx = phonebookContext;
            this._hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.PhoneContacts.Any())
            {
                //create sample data

                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/sampleData.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<PhoneContact>>(json);
                _ctx.PhoneContacts.AddRange(products);
            }
        }
    }
}

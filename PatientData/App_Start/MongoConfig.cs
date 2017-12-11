using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientData
{
    public class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientDb.Open();

            if (!patients.AsQueryable().Any(p => p.Name == "Scott"))
            {
                var data = new List<Patient>
                {
                    new Patient { Name = "Scott", Ailments =  new List<Ailment> { new Ailment { Name = "Bald"} }, Medications = new List<Medication> { new Medication { Name = "Mioxil", Dosage = "100mg" } } },
                    new Patient { Name = "Mili", Ailments =  new List<Ailment> { new Ailment { Name = "Crazy"} }, Medications = new List<Medication> { new Medication { Name = "Symbicort", Dosage = "100mg" } } },
                    new Patient { Name = "Baldie", Ailments =  new List<Ailment> { new Ailment { Name = "Balding"} }, Medications = new List<Medication> { new Medication { Name = "Rogaine", Dosage = "100mg" } } }
                };

                patients.InsertMany(data);
            }
        }
    }
}
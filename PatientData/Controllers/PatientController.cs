using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PatientData.Controllers
{ 
    public class PatientController : ApiController
    {
        private readonly IMongoCollection<Patient> ThePatientCollection;

        public PatientController()
        {
            ThePatientCollection = PatientDb.Open();
        }

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await ThePatientCollection.Find(_ => true).ToListAsync());
        }

        public async Task<IHttpActionResult> Get(string id)
        {
            var patient = await ThePatientCollection.FindAsync(p => p.Id == id);

            if (patient != null)
            {
                return Ok(patient.FirstOrDefault());
            }

            return NotFound();
        }

        [Route("api/patient/{id}/medications")]
        public async Task<IHttpActionResult> GetMedications(string id)
        {
            var patient = await ThePatientCollection.FindAsync(p => p.Id == id);

            if (patient != null)
            {
                return Ok(patient.FirstOrDefault().Medications);
            }

            return NotFound();
        }


    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiGTT.Models;
using System.Security.Cryptography.X509Certificates;

namespace ApiGTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly AppDBContext _context;

        public CertificateController(AppDBContext context)
        {
            this._context = context;
        }


        // GET: api/Certificate
        [HttpGet]
        public ActionResult<List<Certificates>> GetAll()
        {

            //Certificates cerT = this._context.Certificates.Find(id);
            var certs = new List<Certificates>();
            certs = this._context.Certificates.ToList();
            foreach(Certificates cerT in certs)
            {
                if (cerT != null)
                {
                    //Certificates cerT = new Certificates();


                    //X509Certificate2 x509 = new X509Certificate2("./SCD-colegiado-Ministerio.p12", "111111");
                    X509Certificate2 x509 = new X509Certificate2(Convert.FromBase64String(cerT.name), "111111");
                    /*Vigencia del CSD*/
                    string notAfter = x509.GetExpirationDateString();
                    cerT.vigencia = notAfter;

                    ///*No. de Serie del Certificado*/
                    string serialNumber = BitConverter.ToString(x509.GetSerialNumber().Reverse().ToArray());  //Convertir el array de bytes a string
                    cerT.nserie = serialNumber;

                    ///*Issuer*/
                    string issuer = x509.Issuer;
                    cerT.issue = issuer;

                    ///*El certificado incluye la llave privada?*/
                    //bool bExisteKey = oCSD.HasPrivateKey;
                    //Console.WriteLine("Contiene llave privada? - " + bExisteKey.ToString());
                    //Console.WriteLine();

                    ///*Subject*/
                    string subject = x509.Subject;
                    cerT.subject = subject;

                    ///*Thubprint*/
                    //string sThumprint = oCSD.Thumbprint;
                    //Console.WriteLine("Thumbprint: " + sThumprint);
                    //Console.WriteLine();

                    ///*Certificado en base 64*/
                    //string sCertRaw = Convert.ToBase64String(oCSD.Export(X509ContentType.Cert));
                    //Console.WriteLine("Certificado: " + sCertRaw);
                    //Console.WriteLine();


                    //this._context.Certificates.Add(cert);
                    //this._context.SaveChanges();


                    
                }
            }

            return certs;
        }

        // GET: api/Certificate/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public ActionResult<Certificates> Get(long id)
        {
            //this._context = context;

            Certificates cerT = this._context.Certificates.Find(id);

            if(cerT != null)
            {
                //Certificates cerT = new Certificates();


                //X509Certificate2 x509 = new X509Certificate2("./SCD-colegiado-Ministerio.p12", "111111");
                X509Certificate2 x509 = new X509Certificate2(Convert.FromBase64String(cerT.name), "111111");
                /*Vigencia del CSD*/
                string notAfter = x509.GetExpirationDateString();
                cerT.vigencia = notAfter;

                ///*No. de Serie del Certificado*/
                string serialNumber = BitConverter.ToString(x509.GetSerialNumber().Reverse().ToArray());  //Convertir el array de bytes a string
                cerT.nserie = serialNumber;

                ///*Issuer*/
                string issuer = x509.Issuer;
                cerT.issue = issuer;

                ///*El certificado incluye la llave privada?*/
                //bool bExisteKey = oCSD.HasPrivateKey;
                //Console.WriteLine("Contiene llave privada? - " + bExisteKey.ToString());
                //Console.WriteLine();

                ///*Subject*/
                string subject = x509.Subject;
                cerT.subject = subject;

                ///*Thubprint*/
                //string sThumprint = oCSD.Thumbprint;
                //Console.WriteLine("Thumbprint: " + sThumprint);
                //Console.WriteLine();

                ///*Certificado en base 64*/
                //string sCertRaw = Convert.ToBase64String(oCSD.Export(X509ContentType.Cert));
                //Console.WriteLine("Certificado: " + sCertRaw);
                //Console.WriteLine();


                //this._context.Certificates.Add(cert);
                //this._context.SaveChanges();


                return Ok(cerT);
            }

            return NoContent();
        }

        // POST: api/Certificate
        [HttpPost]
        public ActionResult<Certificates> Post([FromBody] Certificates value)
        {
            //value.name = value.name;
            
            this._context.Certificates.Add(value);
            this._context.SaveChanges();
            return Ok(value);
        }

        // PUT: api/Certificate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

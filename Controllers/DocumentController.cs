using asp.netAssement.Entities.Models;
using asp.netAssement.helpers;
using asp.netAssementDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace aspAssements.Controllers
{
    public class DocumentController : ApiController
    {
        DocumentDSL DocDSL = new DocumentDSL();
   
        public ICollection<Document> GetDocuments()
        {
            return DocDSL.GetAllDocument();
        }
  
        [ResponseType(typeof(Document))]
        public IHttpActionResult GetDocument(int docId)
        {
           return Ok(DocDSL.findDocument(docId));
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocument( Document doc,List< DocumentFiles> files, DocumentPriorities pri)
        {
            try
            {
                DocDSL.UpdateDocument(doc, pri, files);
            }
            catch (Exception ex)
            {
                Log.WriteToLog(ex.StackTrace);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
        [ResponseType(typeof(Document))]
        public IHttpActionResult PostDocument(Document doc, List<DocumentFiles> files, DocumentPriorities pri)
        {
            DocDSL.AddDocument(doc,pri,files);

            return CreatedAtRoute("DefaultApi", new { id = doc.Id }, doc);
        }

        // DELETE: api/Customers/5    
        [ResponseType(typeof(Document))]
        public IHttpActionResult DeleteDocument(int id)
        {
            DocDSL.delete(id);
            return Ok();
        }
    }
}

using static System.Environment;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
 
public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    string OriginUrl = req.Headers.GetValues("DISGUISED-HOST").FirstOrDefault(); 
    log.Info("RequestURI org: " + OriginUrl);
   
    //create response
    var response = req.CreateResponse(HttpStatusCode.MovedPermanently);
 
    if((OriginUrl.Contains("happy-meadow")) || 
       (OriginUrl.Contains("happy-meadow-04eb2030f.azurestaticapps.net"))) 
    { 
           response.Headers.Location = new Uri("https://www.gs1au.org/nlr");
    } 
    else
    {
       return req.CreateResponse(HttpStatusCode.InternalServerError);
    }
 
    return response;
}
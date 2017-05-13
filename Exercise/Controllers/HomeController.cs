using Exercise.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Exercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.states = Utilities.CreateStateListItem();
            return View();
        }

        [HttpPost]
        public async  Task<ActionResult> Index(AddressRequest addressModel)
        {
            List<ResultModel> resultCollection = new List<ResultModel>();
            try
            {
                ViewBag.states = Utilities.CreateStateListItem();
                if (!ModelState.IsValid)
                {
                    return View();
                }

                //call API               
                string zwsId = "X1-ZWz1dyb53fdhjf_6jziz";
                string query = string.Format("?zws-id={0}&address={1}&citystatezip={2} {3}", zwsId, addressModel.Address, addressModel.City, addressModel.State);
                query = System.Uri.EscapeUriString(query);
                string content = string.Empty;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://www.zillow.com/webservice/GetSearchResults.htm");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                    HttpResponseMessage response = await client.GetAsync(query);
                    response.EnsureSuccessStatusCode();
                    content = await response.Content.ReadAsStringAsync();

                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(content);

                    foreach (XmlNode node in xml.ChildNodes)
                    {
                        if (node == null || !string.Equals(node.Name, "SearchResults:searchresults", StringComparison.OrdinalIgnoreCase))
                            continue;

                        var responseNode = node.SelectSingleNode("response");
                        var results = responseNode?.SelectSingleNode("results");

                        if (results == null || !results.HasChildNodes)
                            return View("Result", resultCollection);

                        XmlNodeList resultList = results.SelectNodes("result");
                        if (resultList == null || resultList.Count == 0)
                        {
                            return View("result", resultCollection);
                        }

                        foreach (XmlNode resultNode in resultList)
                        {
                            /*gets zpid*/
                            ResultModel resultModel = new ResultModel();
                            resultModel.Zpid = resultNode.SelectSingleNode("zpid")?.InnerText;

                            /*gets links properties*/
                            Utilities.GetLinks(resultModel, resultNode);

                            /*gets address properties*/
                            Utilities.GetAddress(resultModel, resultNode);

                            /*get zestimate properties*/
                            Utilities.GetZestimate(resultModel, resultNode);

                            /*get local real state properties*/
                            Utilities.GetLocalRealState(resultModel, resultNode);                            

                            resultCollection.Add(resultModel);
                        }
                    }
                }

                return View("Result", resultCollection);
            }
            catch (Exception ex)
            {

                return View("Error", null);
            }
        }
    }
}
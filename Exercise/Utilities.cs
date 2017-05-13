using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml;
using Exercise.Models;

namespace Exercise
{
    public class Utilities
    {
        public static List<SelectListItem> CreateStateListItem()
        {
            List<SelectListItem> States = new List<SelectListItem>();
            States.Add(new SelectListItem() { Text = "--Select State--", Value = "" });
            States.Add(new SelectListItem() { Text = "Alabama", Value = "AL" });
            States.Add(new SelectListItem() { Text = "Alaska", Value = "AK" });
            States.Add(new SelectListItem() { Text = "Arizona", Value = "AZ" });
            States.Add(new SelectListItem() { Text = "Arkansas", Value = "AK" });
            States.Add(new SelectListItem() { Text = "California", Value = "CA" });
            States.Add(new SelectListItem() { Text = "Colorado", Value = "CO" });
            States.Add(new SelectListItem() { Text = "Connecticut", Value = "CT" });
            States.Add(new SelectListItem() { Text = "DC", Value = "DC" });
            States.Add(new SelectListItem() { Text = "Delaware", Value = "DE" });
            States.Add(new SelectListItem() { Text = "Florida", Value = "FL" });
            States.Add(new SelectListItem() { Text = "Georgia", Value = "GA" });
            States.Add(new SelectListItem() { Text = "Guam", Value = "GU" });
            States.Add(new SelectListItem() { Text = "Hawaii", Value = "HI" });
            States.Add(new SelectListItem() { Text = "Idaho", Value = "ID" });
            States.Add(new SelectListItem() { Text = "Illinois", Value = "IL" });
            States.Add(new SelectListItem() { Text = "Indiana", Value = "IN" });
            States.Add(new SelectListItem() { Text = "Iowa", Value = "IA" });
            States.Add(new SelectListItem() { Text = "Kansas", Value = "KS" });
            States.Add(new SelectListItem() { Text = "Kentucky", Value = "KY" });
            States.Add(new SelectListItem() { Text = "Louisiana", Value = "LA" });
            States.Add(new SelectListItem() { Text = "Maine", Value = "ME" });
            States.Add(new SelectListItem() { Text = "Maryland", Value = "MD" });
            States.Add(new SelectListItem() { Text = "Massachusetts", Value = "MA" });
            States.Add(new SelectListItem() { Text = "Michigan", Value = "MI" });
            States.Add(new SelectListItem() { Text = "Minnesota", Value = "MN" });
            States.Add(new SelectListItem() { Text = "Mississippi", Value = "MS" });
            States.Add(new SelectListItem() { Text = "Missouri", Value = "MO" });
            States.Add(new SelectListItem() { Text = "Montana", Value = "MT" });
            States.Add(new SelectListItem() { Text = "Nebraska", Value = "NE" });
            States.Add(new SelectListItem() { Text = "Nevada", Value = "NV" });
            States.Add(new SelectListItem() { Text = "New Hampshire", Value = "NH" });
            States.Add(new SelectListItem() { Text = "New Jersey", Value = "NJ" });
            States.Add(new SelectListItem() { Text = "New Mexico", Value = "NM" });
            States.Add(new SelectListItem() { Text = "New York", Value = "NY" });
            States.Add(new SelectListItem() { Text = "North Carolina", Value = "NC" });
            States.Add(new SelectListItem() { Text = "North Dakota", Value = "ND" });
            States.Add(new SelectListItem() { Text = "Ohio", Value = "OH" });
            States.Add(new SelectListItem() { Text = "Oklahoma", Value = "OK" });
            States.Add(new SelectListItem() { Text = "Oregon", Value = "OR" });
            States.Add(new SelectListItem() { Text = "Pennsylvania", Value = "PA" });
            States.Add(new SelectListItem() { Text = "Puerto Rico", Value = "PR" });
            States.Add(new SelectListItem() { Text = "Rhode Island", Value = "RI" });
            States.Add(new SelectListItem() { Text = "South Carolina", Value = "SC" });
            States.Add(new SelectListItem() { Text = "South Dakota", Value = "SD" });
            States.Add(new SelectListItem() { Text = "Tennessee", Value = "TN" });
            States.Add(new SelectListItem() { Text = "Texas", Value = "TX" });
            States.Add(new SelectListItem() { Text = "Utah", Value = "UT" });
            States.Add(new SelectListItem() { Text = "Vermont", Value = "VT" });
            States.Add(new SelectListItem() { Text = "Virginia", Value = "VA" });
            States.Add(new SelectListItem() { Text = "Washington", Value = "WA" });
            States.Add(new SelectListItem() { Text = "West Virginia", Value = "WV" });
            States.Add(new SelectListItem() { Text = "Wisconsin", Value = "WI" });
            States.Add(new SelectListItem() { Text = "Wyoming", Value = "WY" });
            return States;
        }

        internal static void GetLocalRealState(ResultModel resultModel, XmlNode resultNode)
        {
            decimal temp = 0; ;
            XmlNode localRealState = resultNode.SelectSingleNode("localRealEstate");
            if (localRealState != null || localRealState.HasChildNodes)
            {
                XmlNode regionNode = localRealState.SelectSingleNode("region");
                resultModel.LocalRealState = new LocalRealState();

                if (regionNode != null)
                {
                    resultModel.LocalRealState.Region = new RegionModel()
                    {
                        Id = regionNode.Attributes["id"]?.InnerText,
                        Name = regionNode.Attributes["name"]?.InnerText,
                        Type = regionNode.Attributes["type"]?.InnerText,
                        ZindexValue = decimal.TryParse(regionNode.SelectSingleNode("zindexValue")?.InnerText, out temp) ? (decimal?)temp : null
                };

                    XmlNode regionLinksNode = regionNode.SelectSingleNode("links");
                    if (regionLinksNode != null)
                    {
                        resultModel.LocalRealState.Region.Link = new Link()
                        {
                            OverView = regionLinksNode.SelectSingleNode("overview")?.InnerText,
                            ForSaleByOwner = regionLinksNode.SelectSingleNode("forSaleByOwner")?.InnerText,
                            ForSale = regionLinksNode.SelectSingleNode("forSale")?.InnerText
                        };
                    }
                }
            }
        }

        internal static void GetZestimate(ResultModel resultModel, XmlNode resultNode)
        {
            decimal temp;
            XmlNode zestimate = resultNode.SelectSingleNode("zestimate");
            if (zestimate != null && zestimate.HasChildNodes)
            {
                resultModel.Zestimate = new Zestimate()
                {
                    Amount = decimal.TryParse(zestimate.SelectSingleNode("amount")?.InnerText, out temp) ? (decimal?)temp : null,
                    LastUpdated = zestimate.SelectSingleNode("last-updated")?.InnerText,
                    OneWeekChange = zestimate.SelectSingleNode("oneWeekChange")?.Attributes["deprecated"]?.InnerText,
                    ValueChange = decimal.TryParse(zestimate.SelectSingleNode("valueChange")?.InnerText, out temp) ? (decimal?)temp : null,
                    Percentile = decimal.TryParse(zestimate.SelectSingleNode("percentile")?.InnerText, out temp) ? (decimal?)temp : null,
                };

                resultModel.Zestimate.ValuationRange = new ValuationRange()
                {
                    Low = decimal.TryParse(zestimate.SelectSingleNode("valuationRange")?.SelectSingleNode("low")?.InnerText, out temp) ? (decimal?)temp : null,
                    High = decimal.TryParse(zestimate.SelectSingleNode("valuationRange")?.SelectSingleNode("high")?.InnerText, out temp) ? (decimal?)temp : null
                };
            }
        }

        internal static void GetAddress(ResultModel resultModel, XmlNode resultNode)
        {
            XmlNode address = resultNode.SelectSingleNode("address");
            if (address != null && address.HasChildNodes)
            {
                resultModel.Address = new Address()
                {
                    Street = address.SelectSingleNode("street")?.InnerText,
                    Zip = address.SelectSingleNode("zipcode")?.InnerText,
                    City = address.SelectSingleNode("city")?.InnerText,
                    State = address.SelectSingleNode("state")?.InnerText,
                    Latitude = address.SelectSingleNode("latitude")?.InnerText,
                    Longitude = address.SelectSingleNode("longitude")?.InnerText
                };
            }
        }

        internal static void GetLinks(ResultModel resultModel, XmlNode resultNode)
        {
            XmlNode links = resultNode.SelectSingleNode("links");
            if (links != null && links.HasChildNodes)
            {
                resultModel.Link = new Link()
                {
                    HomeDetails = links.SelectSingleNode("homedetails")?.InnerText,
                    GraphsAndData = links.SelectSingleNode("graphsanddata")?.InnerText,
                    MapThisHome = links.SelectSingleNode("mapthishome")?.InnerText,
                    Comparables = links.SelectSingleNode("comparables")?.InnerText
                };
            }
        }
    }
}
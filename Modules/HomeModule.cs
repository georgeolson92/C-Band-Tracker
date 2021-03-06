using System.Collections.Generic;
using System;
using Nancy;
using BandTracker;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Band> allBands = Band.GetAll();
        List<Venue> allVenues = Venue.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("bands", allBands);
        model.Add("venues", allVenues);
        return View["index.cshtml", model];
      };
      Post["/bands/new"] = _ => {
        Band newBand = new Band(Request.Form["band-name"]);
        newBand.Save();
        List<Band> allBands = Band.GetAll();
        List<Venue> allVenues = Venue.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("bands", allBands);
        model.Add("venues", allVenues);
        return View["index.cshtml", model];
      };
      Post["/venues/new"] = _ => {
        Venue newVenue = new Venue(Request.Form["venue-name"]);
        newVenue.Save();
        List<Band> allBands = Band.GetAll();
        List<Venue> allVenues = Venue.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("bands", allBands);
        model.Add("venues", allVenues);
        return View["index.cshtml", model];
      };
      Get["/bands/{id}"] = parameters => {
        int SearchId = parameters.id;
        Band foundBand = Band.Find(SearchId);
        List<Venue> allVenues = Venue.GetAll();
        List<Venue> bandVenues = foundBand.GetVenues();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("band", foundBand);
        model.Add("bandVenues", bandVenues);
        model.Add("allVenues", allVenues);
        return View["band.cshtml", model];
      };
      Get["/venues/{id}"] = parameters => {
        int SearchId = parameters.id;
        Venue foundVenue = Venue.Find(SearchId);
        List<Band> allBands = Band.GetAll();
        List<Band> venueBands = foundVenue.GetBands();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("venue", foundVenue);
        model.Add("venueBands", venueBands);
        model.Add("allBands", allBands);
        return View["venue.cshtml", model];
      };
      Post["/bands/{id}/add-venue"] = parameters => {
        int SearchId = parameters.id;
        Band foundBand = Band.Find(SearchId);
        Venue newVenue = Venue.Find(Request.Form["venue-name"]);
        foundBand.AddVenue(newVenue);
        return View["success_band.cshtml", foundBand];
      };
      Post["/venues/{id}/add-band"] = parameters => {
        int SearchId = parameters.id;
        Venue foundVenue = Venue.Find(SearchId);
        Band newBand = Band.Find(Request.Form["band-name"]);
        foundVenue.AddBand(newBand);
        return View["success_venue.cshtml", foundVenue];
      };
      Delete["/bands/delete"] = _ => {
        int SearchId = Request.Form["band-id"];
        Band foundBand = Band.Find(SearchId);
        foundBand.Delete();
        return View["success.cshtml"];
      };
      Delete["/bands/delete-all"] = _ => {
        Band.DeleteAll();
        return View["success.cshtml"];
      };
      Delete["/venues/delete"] = _ => {
        int SearchId = Request.Form["venue-id"];
        Venue foundVenue = Venue.Find(SearchId);
        foundVenue.Delete();
        return View["success.cshtml"];
      };
      Delete["/venues/delete-all"] = _ => {
        Venue.DeleteAll();
        return View["success.cshtml"];
      };
      Get["/bands/{id}/edit"] = parameters => {
        int SearchId = parameters.id;
        Band foundBand = Band.Find(SearchId);
        return View["edit_band.cshtml", foundBand];
      };
      Get["/venues/{id}/edit"] = parameters => {
        int SearchId = parameters.id;
        Venue foundVenue = Venue.Find(SearchId);
        return View["edit_venue.cshtml", foundVenue];
      };
      Patch["/venues/{id}/"] = parameters => {
        int SearchId = parameters.id;
        Venue foundVenue = Venue.Find(SearchId);
        string newName = Request.Form["new-name"];
        foundVenue.Update(newName);
        List<Band> allBands = Band.GetAll();
        List<Band> venueBands = foundVenue.GetBands();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("venue", foundVenue);
        model.Add("venueBands", venueBands);
        model.Add("allBands", allBands);
        return View["venue.cshtml", model];
      };
      Patch["/bands/{id}/"] = parameters => {
        int SearchId = parameters.id;
        Band foundBand = Band.Find(SearchId);
        string newName = Request.Form["new-name"];
        foundBand.Update(newName);
        List<Venue> allVenues = Venue.GetAll();
        List<Venue> bandVenues = foundBand.GetVenues();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("band", foundBand);
        model.Add("bandVenues", bandVenues);
        model.Add("allVenues", allVenues);
        return View["band.cshtml", model];
      };
    }
  }
}

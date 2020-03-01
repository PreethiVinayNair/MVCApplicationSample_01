﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft;
using System.Threading.Tasks;

namespace MVCApplicationSample.Service
{
  public class NameDataService : INameDataService
  {


   public Task<object> CreateName(NameDataModel model)
    {
      var array = new[] { model };
      String json = Newtonsoft.Json.JsonConvert.SerializeObject(array);
      string path = @"C:\temp\";
      //// Write that JSON to txt file,  
      //var read = System.IO.File.ReadAllText(path + "output.json");
      System.IO.File.WriteAllText(path + "output.json", json);
      return Task.FromResult((object)new { });
    }
  }
}
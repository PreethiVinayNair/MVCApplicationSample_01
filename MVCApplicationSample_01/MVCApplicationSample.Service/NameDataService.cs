using System;
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
      try
      {
        var array = new[] { model };
        String json = Newtonsoft.Json.JsonConvert.SerializeObject(array);
        string path = @"C:\temp\";
        System.IO.File.WriteAllText(path + "output.json", json);
        return Task.FromResult((object)new { });
      }
      catch(Exception ex)
      {
        throw ex;
      }
    }
  }
}

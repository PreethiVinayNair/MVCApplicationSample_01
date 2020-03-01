using System;
using System.Threading.Tasks;

namespace MVCApplicationSample.Service
{
  public interface INameDataService
  {
    public Task<object> CreateName(NameDataModel model);
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjects.Services
{
    public interface IValidationResponse
    {
        bool IsValid(string propertyName);
        string GetValidationMessage(string propertyName);
    }
}

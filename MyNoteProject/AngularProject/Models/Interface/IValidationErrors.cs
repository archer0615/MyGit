using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Models.Interface
{
    public interface IValidationErrors
    {
        List<IBaseError> Errors { get; set; }
    }
}

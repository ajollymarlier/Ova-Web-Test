using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OVA.StellarXWebPortal.Presentation.Controllers.HttpResponses
{
    public class ErrorResponse
    {
        [Required] public string Message { get; set; }
        [Required] public IEnumerable<object> Errors { get; set; }
    }
}

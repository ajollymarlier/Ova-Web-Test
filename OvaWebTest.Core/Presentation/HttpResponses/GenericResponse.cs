using System.ComponentModel.DataAnnotations;

namespace OVA.StellarXWebPortal.Presentation.Controllers.HttpResponses
{
    public class GenericResponse
    {
        [Required] public string Message { get; set; }
    }
}

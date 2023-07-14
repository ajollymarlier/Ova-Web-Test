using System.Collections.Generic;

namespace OVA.StellarXWebPortal.Presentation.Controllers.HttpResponses
{
    public class HttpResponseAssembler
    {
        public GenericResponse AssembleGenericResponse(string message)
        {
            return new GenericResponse()
            {
                Message = message
            };
        }

        public ErrorResponse AssembleErrorResponse(string message, IEnumerable<object> errors)
        {
            return new ErrorResponse()
            {
                Message = message,
                Errors = errors
            };
        }
    }
}

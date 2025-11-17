namespace Intuit.Application.Errors;

public static class ErrorFactory
{
    public static ApplicationException ErrorOnRepositoryCall(string module, string errorText)
    {
        return new ApplicationException($"{module} - Ocurrio un error al utilizar el repositorio. Detalle: {errorText}");
    }
}
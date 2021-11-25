// Original file: https://github.com/thepirat000/Audit.NET/blob/9ee49b5295119ef7cc6648977f90c46ce39cc698/src/Audit.WebApi/AuditApiHelper.cs
// Jan Škoruba file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Helpers/HttpContextHelpers/HttpContextHelpers.cs
// Modified by Eirik Sjøløkken

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Eiromplays.AuditLogging.Helpers.HttpContext;

public class HttpContextHelpers
{
    public static IDictionary<string, string>? GetFormVariables(Microsoft.AspNetCore.Http.HttpContext? context)
    {
        if (context is not null && !context.Request.HasFormContentType)
        {
            return null;
        }

        IFormCollection? formCollection = null;

        try
        {
            if (context?.Request.Form is not null)
            {
                formCollection = context.Request.Form;
            }
        }
        catch (InvalidDataException)
        {
            // InvalidDataException could be thrown if the form count exceeds the limit, etc
            return null;
        }
        return ToDictionary(formCollection);
    }

    public static IDictionary<string, string>? ToDictionary(IEnumerable<KeyValuePair<string, StringValues>>? valuePairs)
    {
        if (valuePairs is null)
        {
            return null;
        }

        var dictionary = new Dictionary<string, string>();

        foreach (var (key, value) in valuePairs)
        {
            dictionary.Add(key, string.Join(", ", value));
        }

        return dictionary;
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class DateType : ValidationAttribute
{
    private readonly string _formato;

    public DateType(string formato)
    {
        _formato = formato;
        ErrorMessage = $"A data deve estar no formato {_formato}";
    }

    public override bool IsValid(object? value)
    {
        if (value is null) return true; // deixa passar se não for obrigatório

        if (value is string str && !string.IsNullOrWhiteSpace(str))
        {
            return DateTime.TryParseExact(
                str,
                _formato,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);
        }

        return false; // não é string ou está vazia
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class CepType : ValidationAttribute
{
    public CepType()
    {
        ErrorMessage = "O CEP deve estar no formato 00000-000";
    }

    public override bool IsValid(object? value)
    {
        if (value is null) return true;

        var cep = value as string;
        if (string.IsNullOrWhiteSpace(cep)) return true;

        return Regex.IsMatch(cep, @"^\d{5}-\d{3}$");
    }
}

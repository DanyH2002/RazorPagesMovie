using System;
using System.Data;
using FluentValidation;
using RazorPagesMovie.DTOs;
using RazorPagesMovie.Model;

namespace RazorPagesMovie.Validators;

public class MovieUpdateValidator : AbstractValidator<MovieUpdate>
{
    public MovieUpdateValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Debe contener un ID");
        RuleFor(x => x.Title).NotEmpty().WithMessage("El titulo es obligatorio");
        RuleFor(x => x.Description).MaximumLength(200).WithMessage("La descripcion no debe ser mayor a 200 caracteres");
        RuleFor(x => x.Gender).NotEmpty().WithMessage("El genero es obligatorio");
        RuleFor(x => x.Year).InclusiveBetween(1900, DateTime.Now.Year).WithMessage($"El año debe estar estar 1900 y {DateTime.Now.Year}");
    }
}

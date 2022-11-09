namespace TailwindTraders.Api.Core.Requests.Validators;

public class PostFileRequestValidator : AbstractValidator<PostFileRequest>
{
    public PostFileRequestValidator()
    {
        RuleFor(request => request)
            .NotNull();

        RuleFor(request => request.File)
            .NotNull();
    }
}
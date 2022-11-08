namespace TailwindTraders.Api.Core.Requests.Validators;

public class PostImagesRequestValidator : AbstractValidator<PostImagesRequest>
{
    public PostImagesRequestValidator()
    {
        RuleFor(request => request)
            .NotNull();

        RuleFor(request => request.imageFilePath)
            .NotNull();
    }
}
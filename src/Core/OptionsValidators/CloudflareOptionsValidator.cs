using Core.Options;
using Microsoft.Extensions.Options;

namespace Core.OptionsValidators;

[OptionsValidator]
public partial class CloudflareOptionsValidator : IValidateOptions<CloudflareOptions>
{
}

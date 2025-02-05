using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Forecaster.ApiService.Options
{
    public sealed class SomeOptions : IConfigureOptions<SomeOptions>, IValidateOptions<SomeOptions>
    {
        public const string SectionName = nameof(SomeOptions);

        [Range(0, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        public int? RetryCount { get; set; }

        [Required]
        public string PathToFile { get; set; } = string.Empty;

        public List<string> Lines { get; set; } = new();

        void IConfigureOptions<SomeOptions>.Configure(SomeOptions options)
        {
            options.Lines.Add("Came from method");
        }

        ValidateOptionsResult IValidateOptions<SomeOptions>.Validate(string? name, SomeOptions options)
        {
            return options.Lines == null ? ValidateOptionsResult.Fail("Lines cannot be null")
                : ValidateOptionsResult.Success; 
        }
    }
}

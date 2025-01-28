using System.ComponentModel.DataAnnotations;

namespace Forecaster.ApiService.Options
{
    public sealed class SomeOptions
    {
        public const string SectionName = nameof(SomeOptions);

        [Range(0, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        public int? RetryCount { get; set; }

        [Required]
        public string PathToFile { get; set; } = string.Empty;
    }
}

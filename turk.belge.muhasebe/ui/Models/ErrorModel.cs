namespace ui.Models
{
    public class ErrorModel
    {
        public ErrorModel(params string[] errorMessages)
        {
            ErrorMessages = errorMessages;
        }

        public string? RequestId { get; set; }
        public string[]? ErrorMessages { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

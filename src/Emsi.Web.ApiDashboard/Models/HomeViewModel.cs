using Emsi.Api.Dtos;

namespace Emsi.Web.ApiDashboard.Models
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public StatusDto? Status { get; set; }
        public MetaDto? Meta { get; set; }
        public bool IsAlert { get; set; }
        public string? Message { get; set; }
        public AlertType Type { get; set; } = AlertType.Warning;

        public HomeViewModel(string title) => Title = title;

        public string GetAlertType() => Type.ToString().ToLower();
    }

    public enum AlertType
    {
        Warning, Danger
    }
}

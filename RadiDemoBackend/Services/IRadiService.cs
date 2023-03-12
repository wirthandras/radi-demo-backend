using RadiDemoBackend.Responses;

namespace RadiDemoBackend.Services
{
    public interface IRadiService
    {
        Task<DashboardResponse> GetDashBoard();

        Task Genarate();

        Task Pay(long id);
    }
}

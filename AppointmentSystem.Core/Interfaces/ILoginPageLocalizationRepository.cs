namespace AppointmentSystem.Core.Interfaces
{
    public interface ILoginPageLocalizationRepository
    {
        Task<Dictionary<string, string>> GetLocalizedLoginPageFormLabelsAsync(CancellationToken cancellationToken);

    }
}

namespace Inspection
{
    public class InspectionService
    {
      private IDefibrillatorRepository defibrillatorRepository;

      public InspectionService(IDefibrillatorRepository defibrillatorRepository) {
        this.defibrillatorRepository = defibrillatorRepository;
      }

      public void Inspect(int defibrillatorId) {
        var defibrillator = this.defibrillatorRepository.FindBySerialNumber(defibrillatorId);

        defibrillator.Inspect();

        this.defibrillatorRepository.Save(defibrillator);
      }
    }
}

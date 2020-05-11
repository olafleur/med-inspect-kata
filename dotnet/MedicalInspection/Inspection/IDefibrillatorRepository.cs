namespace Inspection
{
  public interface IDefibrillatorRepository {
    Defibrillator FindBySerialNumber(int serialNumber);

    void Save(Defibrillator defibrillator);
  }
}

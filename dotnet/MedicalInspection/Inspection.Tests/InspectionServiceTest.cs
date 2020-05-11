using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Inspection.Tests
{
  [TestClass]
  public class InspectionServiceTest
  {
    private const int SERIAL_NUMBER = 1;

    private Mock<IDefibrillatorRepository> defibrillatorRepository;
    private Mock<Defibrillator> defibrillator;

    private InspectionService inspectionService;

    [TestInitialize]
    public void Setup() {
      defibrillatorRepository = new Mock<IDefibrillatorRepository>();

      defibrillator = new Mock<Defibrillator>();
      defibrillatorRepository.Setup(repo => repo.FindBySerialNumber(SERIAL_NUMBER)).Returns(defibrillator.Object);

      inspectionService = new InspectionService(defibrillatorRepository.Object);
    }

    [TestMethod]
    public void Inspect_ShouldInspectDefibrillator() {
      inspectionService.Inspect(SERIAL_NUMBER);

      defibrillator.Verify(d => d.Inspect());
    }

    [TestMethod]
    public void Inspect_ShouldSaveDefibrillator() {
      inspectionService.Inspect(SERIAL_NUMBER);

      defibrillatorRepository.Verify(repo => repo.Save(defibrillator.Object));
    }
  }
}

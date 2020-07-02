using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;

namespace Inspection.Tests
{
  [TestClass]
  public class DefibrillatorTest
  {
    private readonly DateTime A_DATE = DateTime.Now;

    [TestMethod]
    public void Status_ShouldBeInspected_WhenNextInspectionDueDateIsInMoreThanTwoWeeks()
    {
      var nextInspectionDueDate = DateTime.Now.AddDays(14);
      var defibrillator = new Defibrillator(1, nextInspectionDueDate);

      defibrillator.Status.Should().Be(DefibrillatorStatus.INSPECTED);
    }

    [TestMethod]
    public void Status_ShouldBeToBeInspected_WhenNextInspectionDueDateIsInLessThanTwoWeeks()
    {
      var nextInspectionDueDate = DateTime.Now.AddDays(13);
      var defibrillator = new Defibrillator(1, nextInspectionDueDate);

      defibrillator.Status.Should().Be(DefibrillatorStatus.TO_BE_INSPECTED);
    }

    [TestMethod]
    public void Status_ShouldBeNotInspected_WhenNextInspectionDueDateIsInThePast()
    {
      var nextInspectionDueDate = DateTime.Now.AddDays(-1);
      var defibrillator = new Defibrillator(1, nextInspectionDueDate);

      defibrillator.Status.Should().Be(DefibrillatorStatus.NOT_INSPECTED);
    }

    [TestMethod]
    public void Status_ShouldBeToBeInspected_WhenNextInspectionDueDateIsNow()
    {
      var nextInspectionDueDate = A_DATE;
      var defibrillator = new Defibrillator(1, nextInspectionDueDate);

      defibrillator.Status.Should().Be(DefibrillatorStatus.TO_BE_INSPECTED);
    }

    [TestMethod]
    public void Inspect_ShouldMoveNextInspectionDueDateInOneMonth() {
      var defibrillator = new Defibrillator(1, A_DATE);

      defibrillator.Inspect();

      defibrillator.NextInspectionDueDate.Should().Be(DateTime.Now.AddMonths(1).Date);
    }
  }
}

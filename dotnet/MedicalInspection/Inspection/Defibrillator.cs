using System;

namespace Inspection
{
  public class Defibrillator
  {
    private DateTime _nextInspectionDueDate;

    public int SerialNumber { get; }

    public DateTime NextInspectionDueDate {
      get { return _nextInspectionDueDate.Date; }
    }

    public DefibrillatorStatus Status {
      get {
        if (NextInspectionDueDate < DateTime.Now.Date) {
          return DefibrillatorStatus.NOT_INSPECTED;
        }

        if (NextInspectionDueDate < DateTime.Now.AddDays(14).Date) {
          return DefibrillatorStatus.TO_BE_INSPECTED;
        }

        return DefibrillatorStatus.INSPECTED;
      }
    }

    public Defibrillator(int id, DateTime nextInspectionDueDate) {
      this.SerialNumber = id;
      _nextInspectionDueDate = nextInspectionDueDate;
    }

    public Defibrillator() {
      // Empty constructor for testing
    }

    public virtual void Inspect() {
      _nextInspectionDueDate = NextInspectionDueDate.AddMonths(1);
    }
  }
}

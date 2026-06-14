Here is the refined tactical design isolated exclusively for the **Booking & Scheduling** and **Medical Consultation** contexts, structured to clearly showcase how internal entities protect the aggregate root rules.

---

## 1. Booking & Scheduling Context

### Aggregate Root: `DoctorSchedule`

* **Definition:** Manages a single doctor’s availability timeline. It enforces the critical business rule (invariant) that a doctor cannot have overlapping or double-booked time slots.
* **Internal Entities:**
* `AvailabilitySlot`: This is modeled as an internal entity because each slot has its own local identity (`SlotID`) and passes through clear state transitions (`Available` $\rightarrow$ `Held` $\rightarrow$ `Booked`). It cannot be modified directly from outside this aggregate.


* **Value Objects:**
* `TimeRange`: A collection of attributes containing the explicit `StartTime` and `EndTime`.


* **Domain Events:**
* `DoctorAvailabilityPublished`: Fired when a doctor opens up a new set of slots.
* `AvailabilitySlotReserved`: Fired when a patient temporarily locks a slot during checkout.



### Aggregate Root: `Appointment`

* **Definition:** The operational contract and reservation record connecting a patient to a doctor. It governs the timeline from initial request up to the point of clinical intake.
* **Internal Entities:**
* *None* (Kept highly performant and small to prevent database record locking).


* **Value Objects:**
* `AppointmentSlotSnapshot`: An immutable copy of the selected date and time data copied from the schedule.
* `BookingStatus`: An immutable state indicator (`PendingPayment`, `Confirmed`, `Canceled`).


* **Domain Events:**
* `AppointmentRequested`: Fired immediately when a user attempts a booking.
* `AppointmentConfirmed`: Fired once payment or validation clears, authorizing the scheduling.
* `AppointmentCanceled`: Fired if either party cancels the slot.



---

## 2. Medical Consultation Context

### Aggregate Root: `Consultation`

* **Definition:** The official medical encounter session. It encapsulates everything that happens during the actual visit. It is entirely separate from the `Appointment` aggregate because its data privacy, data structures, and auditing lifecycles are completely different.
* **Internal Entities:**
* `PrescriptionLine`: If the doctor issues medication during the consult, each line item requires an individual identity (`LineID`). This allows the doctor to add, edit, or delete specific items (e.g., changing a dosage or frequency) before finalizing the overall record.


* **Value Objects:**
* `ConsultationDetails`: Immutable text blocks encapsulating `Symptoms`, `DoctorDescription`, and official `Diagnosis`.
* `MedicalNote`: Private clinical thoughts or internal references not exposed directly to the patient's public portal view.
* `Duration`: An immutable time span tracking how long the session lasted.


* **Domain Events:**
* `ConsultationStarted`: Fired when the doctor initiates the active medical session.
* `ConsultationCompleted`: Fired when the doctor locks, signs off, and finalizes the clinical notes.
* `PatientHistoryUpdated`: Emitted to notify downstream archival and profile contexts to update the patient's continuous medical record file.



---


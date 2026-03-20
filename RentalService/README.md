# University Equipment Rental Service

## Project description
This project is a simple console application for managing equipment rentals at a university.
It allows adding users and equipment, renting and returning items, and checking availability and overdue rentals

---

## Project structure
I divided the project into `Entities`, `Service`, and `Program`
Entities store data like users, equipment, and rentals, while services handle the logic like renting or calculating penalties.  
This helped me keep the main program clean and easier to read

---

## Design decisions
I separated classes based on what they do
For example, `LendingService` handles renting, and `PenaltyCalc` is responsible only for penalties.  
This made it easier to change parts of the program without breaking everything

---

## Cohesion, coupling, and responsibilities
I tried to keep each class focused on one task, like `ReportService` only printing summaries.  
Services use other classes instead of doing everything in one place, which reduces dependency between parts.  
This made the code more organized and easier to understand while I was working on it
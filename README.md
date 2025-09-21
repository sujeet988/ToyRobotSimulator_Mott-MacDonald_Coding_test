# Toy Robot Simulator

A **C# console application** that simulates a toy robot moving on a 5×5 tabletop.  
The robot can be placed, moved, rotated, and report its position, while ensuring it never falls off.  

---

## Problem Summary
- Table size: **5×5** units  
- Supported commands:
  - `PLACE X,Y,F` → Place robot at `(X,Y)` facing `NORTH | SOUTH | EAST | WEST`
  - `MOVE` → Move one unit forward
  - `LEFT` / `RIGHT` → Rotate 90°
  - `REPORT` → Output current position and direction
- Rules:
  - First valid command must be `PLACE`
  - Invalid moves are ignored
  - Commands before `PLACE` are ignored

---

## Project Structure

- **Core** → Contracts (`IRobot`, `ITable`, `ICommand`), models (`Position`, `Direction`), and main logic (`Robot`, `Table`).  
- **Services** → Implements commands (`MoveCommand`, `LeftCommand`, `RightCommand`, `PlaceCommand`, `ReportCommand`) and parsing (`CommandProcessor`).  
- **Client** → Console interface that reads and executes commands.  
- **Tests** → Unit tests to validate all behaviors.  

---

## Run the App

dotnet build
dotnet run --project ToyRobotSimulator.Client

PARAMETERS:
PLACE 0,0,NORTH
MOVE
REPORT

## Run Tests

dotnet test
- **Example Scenarios : 
**Input:** 			
 PLACE 0,0,NORTH
 MOVE
 REPORT
**Output:** : 
 0,1,NORTH

## Tech & Design

- C# .NET 7

- MSTest for testing

- Command Pattern → each command is its own class (ICommand)

- Interfaces → IRobot, ITable, ICommand for testability and extensibility

- Clean architecture → Core logic, Services, and Client separated


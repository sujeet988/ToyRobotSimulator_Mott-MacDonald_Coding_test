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

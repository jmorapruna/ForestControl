# Welcome to Forest Control!

This is the forest control project.

The project consists of a tool to calculate the position and final orientation of a set of drones sent with a list of instructions over a delimited area.

Functional considerations:
---
**The implementation has been carried out using positions with a minimum of 1, not 0.**
The requirements indicated in one example that the positioning of the drones began with 0. In contrast, in the examples of inputs and outputs they suggested that the numbering was from 1. The position example "0 0 N" was assumed to be incorrect.

**It has been assumed that exceeding one position the area of ​​the drones results in a position on the opposite side of the crossed border.**
The requirements did not explicitly indicate how this behavior should be treated. the chosen behavior is compatible with the requirements tests.

**It has been assumed that the data entry will be done in a correct format and that no prior validation is required.**

Technical considerations:
---
  
The application of SOLID principles has been a priority.  

The developed code is largely self-explanatory. In some specific cases, some comments have been added to improve its readability.

The solutuion consists of these Net Core projects:
- **ForestControl.ConsoleApp** (Presentation layer) 
- **ForestControl.Core:** (Domain layer)
- **ForestControl.Core.Tests:** (Domain layer unit tests)

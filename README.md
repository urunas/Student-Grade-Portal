# Student Grade Portal

A console-based C# application for calculating student grades, assigning letter grades, and generating basic class statistics.

> This was my first programming project, created just two months after I started studying Computer Programming. Looking back at it while writing this README reminds me how much progress I have made since then. Although it is a simple project, it represents an important starting point in my learning journey.

## Overview

Student Grade Portal is a console-based educational project built to practice C# fundamentals. The application asks for student information, validates user input, calculates weighted averages, assigns letter grades, and prints a class summary.

## Features

- Collects student number, full name, midterm grade, and final grade
- Validates required names and numeric inputs
- Ensures grades are between 0 and 100
- Calculates weighted averages using midterm and final grades
- Assigns letter grades from the calculated average
- Displays a summary table for all students
- Shows the students with the highest and lowest averages
- Calculates and displays the class average

## Grade Calculation Formula

```text
Average = (Midterm * 0.40) + (Final * 0.60)
```

## Letter-Grade Scale

| Average range | Letter grade |
| --- | --- |
| 85 - 100 | AA |
| 70 - 84.99 | BA |
| 60 - 69.99 | BB |
| 50 - 59.99 | CB |
| 40 - 49.99 | CC |
| 30 - 39.99 | DC |
| 20 - 29.99 | DD |
| 10 - 19.99 | FD |
| 0 - 9.99 | FF |

## Technologies

- C#
- .NET 9
- Console application

## Project Structure

```text
.
├── Program.cs
├── StudentGradePortal.csproj
├── StudentGradePortal.sln
├── README.md
└── .gitignore
```

## Requirements

- .NET SDK 9.0 or later

Check your installed SDK version:

```bash
dotnet --version
```

## Installation

Clone the repository:

```bash
git clone https://github.com/urunas/Student-Grade-Portal.git
cd Student-Grade-Portal
```

Restore dependencies:

```bash
dotnet restore
```

## Running the Application

Run from the repository root:

```bash
dotnet run
```

You can also run the solution build first:

```bash
dotnet build
dotnet run --project StudentGradePortal.csproj
```

## Example Usage

```text
Student Grade Portal
--------------------
Enter the number of students: 2

Student 1
Student number: 101
Full name: Ada Lovelace
Midterm grade (0-100): 80
Final grade (0-100): 90
Average: 86.00 | Letter grade: AA

Student 2
Student number: 102
Full name: Alan Turing
Midterm grade (0-100): 70
Final grade (0-100): 60
Average: 64.00 | Letter grade: BB

Class Summary
-------------
No         Full Name                 Midterm    Final   Average   Letter
---------------------------------------------------------------------------
101        Ada Lovelace                   80       90     86.00       AA
102        Alan Turing                    70       60     64.00       BB
---------------------------------------------------------------------------
Class average: 75.00
Highest average: 86.00 (Ada Lovelace)
Lowest average: 64.00 (Alan Turing)
```

## Input Validation

- Student count must be a positive number.
- Student number must be a positive number.
- Full name cannot be empty.
- Midterm and final grades must be valid numbers between 0 and 100.
- Invalid inputs are rejected and the user is asked to enter the value again.

## Learning Objectives

- Practice console input and output
- Use loops and conditional statements
- Validate user input with `int.TryParse`
- Store related data in a simple record
- Work with collections and basic class statistics
- Organize a small C# console application repository

## Possible Future Improvements

- Export the summary to a text or CSV file
- Add duplicate student number checks
- Allow editing a student before printing the summary
- Add simple unit tests for grade calculation

## Author

Created by [urunas](https://github.com/urunas).

# Clock Calculator API

A .NET API that calculates the angle between hour and minute hands on an analog clock.

## Overview

The Clock Calculator API provides endpoints to calculate the sum of the hour hand and minute hand angles on an analog clock. In this calculation:
- 12:00 represents 0 degrees
- 3:00 represents 90 degrees
- 6:00 represents 180 degrees
- 9:00 represents 270 degrees

## Technology Stack

- .NET 9.0
- ASP.NET Core Minimal API
- xUnit for unit testing
- Docker for containerization

## Project Structure

- **ClockCalculator.Api**: The main API project
  - `Services/`: Contains the clock calculation logic
  - `Program.cs`: API endpoint definitions
  - `Dockerfile`: Container definition
- **ClockCalculator.Tests**: Unit tests for the calculation logic

## API Endpoints

The API provides two endpoints:

1. `/api/calculatetimeangle?hours={hours}&minutes={minutes}`
   - Parameters: `hours` (int), `minutes` (int)
   - Example: `/api/calculatetimeangle?hours=3&minutes=15`

2. `/api/calculatetimeangle/{time}`
   - Parameter: `time` (string in HH:MM format)
   - Example: `/api/calculatetimeangle/3:15`

Both endpoints return the sum of the hour and minute hand angles.

## Building and Running the Project

### Prerequisites

- .NET 9.0 SDK or later
- Docker (optional, for containerization)

### Running Locally

1. Clone the repository
2. Navigate to the project directory
```bash
cd ClockCalculator
```

3. Build and run the API project
```bash
dotnet build
dotnet run --project ClockCalculator.Api
```

The API will be available at:
- HTTP: http://localhost:5276

### Using Docker

1. Build the Docker image
```bash
cd ClockCalculator.Api
docker build -t clockcalculator-api .
```

2. Run the container
```bash
docker run -d -p 5276:5276 --name clockcalculator-container clockcalculator-api
```

The API will be available at:
- HTTP: http://localhost:5276

## Running Tests

To run the unit tests:

```bash
dotnet test ClockCalculator.Tests
```

To run tests with coverage report:

```bash
dotnet test ClockCalculator.Tests /p:CollectCoverage=true /p:CoverletOutputFormat=lcov
```

## Example Calculations

- **3:00** = 90° (hour hand) + 0° (minute hand) = 90°
- **6:30** = 180° (hour hand) + 15° (for 30 minutes) + 180° (minute hand) = 375°
- **9:45** = 270° (hour hand) + 22.5° (for 45 minutes) + 270° (minute hand) = 562.5°
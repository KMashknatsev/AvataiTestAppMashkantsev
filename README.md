# AvataiTestAppMashkantsev

.NET MAUI application for demonstrating a test task for a developer position.

---

## About the project

The application contains several pages with navigation implemented through Shell, and uses the MVVM pattern with separation into Core and UI layers.

Main functionality:
- Loading and displaying a list with infinite scrolling.
- Going to the details page with highlighting the selected item.
- Form with validation and sending data.
- WebView with URL switching and loading indicator.
- Local notifications.
- Logging and error reporting.

---

## Solution structure

- `AvataiTestAppMashkantsev.Core` — business logic, models, services, ViewModel.
- `AvataiTestAppMashkantsev` — UI project on MAUI, pages, XAML, DI registration.
- `AvataiTestAppMashkantsev.Tests` — unit tests with mocks for the main ViewModel.

---

## Technologies

- .NET MAUI
- CommunityToolkit.MVVM
- Microsoft.Extensions.Logging
- Dependency Injection (Microsoft.Extensions.DependencyInjection)
- xUnit + Moq for tests

---

## Launching the project

1. Open the solution in Rider (version with MAUI support).
2. Install the necessary SDK and tools (MAUI workload).
3. Launch the project on the desired platform (Android, iOS).
4. The project implements the main scenarios, navigation and data loading.

---

## Testing

- Unit tests are in the `AvataiTestAppMashkantsev.Tests` project.
- To run tests, open Test Explorer in Rider and run all tests.

---

## Contacts

If you have questions, suggestions or need help, please contact:
kirilleon1911@gmail.com
---

## License

This project is intended to demonstrate a test task.

All rights reserved.

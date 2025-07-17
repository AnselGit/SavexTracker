# SavexTracker

SavexTracker is a C# WinForms application designed to help users track, analyze, and manage their savings and expenses. It provides a modern, user-friendly interface for recording financial transactions, visualizing spending and saving trends, and organizing records with advanced search and archiving features. This app solves the problem of manual, error-prone expense tracking by offering a centralized, efficient, and visually appealing solution for personal finance management.

---

## Screenshots

![Screenshot 7](assets/S%20(7).png)
![Screenshot 6](assets/S%20(6).png)
![Screenshot 5](assets/S%20(5).png)
![Screenshot 4](assets/S%20(4).png)
![Screenshot 3](assets/S%20(3).png)
![Screenshot 2](assets/S%20(2).png)
![Screenshot 1](assets/S%20(1).png)

---

## Features

- Add, update, and delete savings and expenses
- Archive and restore records (with batch operations)
- Advanced search: Filter by month, year, type, amount, and note (multi-term, any order)
- Owner-drawn panels for a modern, responsive UI
- Pie and line charts for visualizing your finances
- History log for all actions
- Goal tracking
- Batch delete and archive
- Robust error handling (e.g., database lock prevention)

---

## Getting Started

### Prerequisites
- Windows 10/11
- .NET Framework 4.8

### Running from Source
1. **Clone the repository:**
   ```sh
   git clone https://github.com/yourusername/SavexTracker.git
   cd SavexTracker
   ```
2. **Open `SavexTracker.sln` in Visual Studio**
3. **Restore NuGet packages** (if prompted)
4. **Build and run** (F5 or Ctrl+F5)

### Publishing as an EXE
1. In Visual Studio, right-click the project and select **Publish**
2. Choose **Folder** or **Self-contained** deployment for a portable EXE
3. Follow the wizard to generate your distributable EXE

---

## Project Structure

- `forms/` — All WinForms UI forms (main, add, update, archive, etc.)
- `CustomClasses/` — Custom controls (owner-drawn panels, rounded panels, etc.)
- `database/` — SQLite database logic and config
- `Models/` — Data models (Expense, Saving, ArchiveItem, etc.)
- `assets/` — Icons, images, and UI assets (add your screenshot here!)
- `Program.cs` — App entry point
- `App.config` — App configuration

---

## Packages and Libraries Used

- **RJControls** (RJCodeAdvance.RJControls) — Modern WinForms UI controls (buttons, textboxes, etc.)
- **System.Data.SQLite** — SQLite database provider for .NET
- **OpenTK** — For advanced chart/graph rendering
- **.NET Framework 4.8** — Application framework
- **Other NuGet packages** as listed in `packages.config`

---

## Technologies Used
- C# WinForms
- SQLite
- Custom owner-draw controls
- Modern UI assets

---

This project is for portfolio/demo purposes and is not intended for open source contribution or redistribution.
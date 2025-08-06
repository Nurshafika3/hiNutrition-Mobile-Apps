# hiNutrition Mobile Apps

A Unity-based mobile AR application focused on nutrition education.

## Project Overview

This is a Unity project that creates an educational mobile application about nutrition using Augmented Reality (AR) features. The app includes interactive elements to help users learn about healthy eating and nutrition facts.

## Features

- **AR Experience**: Uses Vuforia for augmented reality functionality
- **Interactive UI**: Multiple scenes including menu, quiz, and AR experiences
- **Educational Content**: Nutrition and fruity quiz sections
- **3D Models**: Includes various 3D models for educational purposes
- **Audio Integration**: Sound effects and background music

## Project Structure

```
Assets/
├── Scenes/          # Unity scenes (Menu, AR, Quiz, etc.)
├── Scripts/         # C# scripts for game logic
├── Resources/       # Images, UI elements, and configuration files
├── Sound/           # Audio files
└── TextMesh Pro/    # Text rendering assets
```

## Technologies Used

- **Unity Engine**: Game development platform
- **Vuforia**: AR development platform
- **TextMesh Pro**: Advanced text rendering
- **C#**: Programming language for scripts

## Setup Instructions

1. Open the project in Unity
2. Ensure Vuforia package is properly imported
3. Configure Vuforia license key in the configuration assets
4. Build for Android platform

## Scenes

- `Menu.unity`: Main menu screen
- `AR.unity` & `AR2.unity`: Augmented reality experiences
- `QuizMenu.unity`: Quiz selection screen
- `QuizFruity.unity`: Fruit-related quiz
- `QuizNutrition.unity`: Nutrition quiz

## Scripts

- `Menu.cs`: Main menu functionality
- `GameManager.cs`: Game state management
- `QuizMenu.cs`: Quiz navigation
- `ARButton.cs`: AR interaction handlers
- `ScoreManager.cs`: Score tracking
- `rotateobject.cs`: 3D object rotation

## Build Notes

- Some large assets (>100MB) are excluded from this repository
- Vuforia package may need to be re-imported
- Configure build settings for target mobile platform

## License

This project is for educational purposes.

# Bounce Dash

**Bounce Dash** is a hyper-casual 2D arcade-style game where the player controls a bouncing ball that dodges obstacles and collects coins to score as many points as possible before hitting an obstacle.

---

## Core Gameplay

- The player controls a bouncing ball that automatically bounces vertically.
- Move the ball left or right using:
  - Keyboard: `A/D` or `←/→` keys
  - Touch buttons (for mobile)
- The level scrolls vertically as the ball climbs.
- Obstacles like rotating blades and spikes challenge the player.
- Collectibles include coins to increase the score.
- Game Over occurs when hitting any obstacle.
- The goal is to achieve the highest score possible.

---

## Game Mechanics

- Bouncing physics using `Rigidbody2D` and `Physics Material`.
- Smooth horizontal movement for responsive control.
- Dynamic spawning of obstacles and collectibles.
- Scoring system based on:
  - Time survived
  - Coins collected

---

## UI & UX

- Main Menu with Play and Quit options
- Game Over Screen showing:
  - Final score
  - Restart and Main Menu buttons
- UI Animations created using Unity's `Timeline` system

---

## Technical Details

- Engine: Unity 6
- Input: Unity's New Input System (supports mobile & keyboard)
- Scriptable Objects: Used scriptable objects for efficient data management.
- Architecture & Code Quality:
  - MVC Architecture (Model is replaced by scriptable objects)
  - Service Locator and Dependency Injection
  - Observer Pattern for event management
  - Object Pooling for efficient obstacle/coin spawning
  - Commented and well-structured C# scripts

---

## Setup

- Clone the repository.
- Open this project in Unity 6+.
- Press Play or Build to your target platform.

---

## Optimization Approach

To ensure smooth gameplay and performance across devices, especially mobile platforms, the following optimizations were implemented:

- **Object Pooling**: Reused obstacle and coin objects instead of repeatedly instantiating and destroying them. This reduced memory allocation and minimized garbage collection overhead.
- **MVC Architecture & Modular Code**: Structured the codebase using the Model-View-Controller pattern along with Dependency Injection and the Service Locator pattern. This enhanced maintainability and allowed efficient communication between systems.
- **Physics Management**: Confined physics-related logic to `FixedUpdate` and avoided unnecessary physics calculations. Rigidbody2D was used efficiently to simulate bouncing while keeping physics interactions lightweight.
- **Event-Driven Design**: Applied the Observer Pattern to handle game events like player death event. This decoupled systems and reduced the need for constant checks or polling.

---

## Play Here

https://outscal.com/utkarshsharan99/game/play-bounce-dash-game

---

## Watch Here

https://www.loom.com/share/b583a85522c843049d748eab16f44fa0?sid=6ff6f119-138f-4104-82b0-c5df34bcf3d4

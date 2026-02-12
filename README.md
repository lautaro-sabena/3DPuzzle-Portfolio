🧩 Modular FPS Puzzle Prototype (Unity)

A short first-person puzzle experience built in Unity with a strong focus on clean architecture, modular systems, and production-ready code practices.

This project was developed as a technical portfolio piece to demonstrate programming quality, system design, and gameplay architecture rather than visual polish.

🎯 Project Purpose

The primary goal of this project is to showcase:

Clean and modular C# architecture

Decoupled gameplay systems

Proper use of UnityEvents and interfaces

CharacterController-compatible moving platforms

Scalable puzzle design structure

Production-oriented problem solving

This is not a “feature-heavy” game — it is a focused technical implementation of reusable gameplay systems.

🎮 Gameplay Overview

The player navigates a small first-person puzzle environment featuring:

Interactive buttons

Moving platforms

Sequenced environmental logic

Trigger-based fail states and respawn

Each puzzle is designed to demonstrate:

Event-driven architecture

Modular object interaction

Clear separation between level logic and system logic

🧠 Technical Architecture
🔹 1. Interaction System (Interface-Based)

All interactable objects implement a shared interface.

public interface IInteractable
{
    void Interact();
}


The player uses a raycast-based detection system to identify and interact with objects without tight coupling.

Benefits:

Extensible

Scalable

Clean separation of responsibilities

No hardcoded object references

🔹 2. Event-Driven Puzzle Logic

Buttons do not contain gameplay logic.

Instead, they expose:

public UnityEvent OnPressed;


Puzzle behavior is configured directly in the Unity Inspector using UnityEvents.

Why this matters:

Decoupled systems

Designer-friendly workflow

No cross-script dependencies

Easily reusable components

🔹 3. Moving Platform System (CharacterController Compatible)

Unity’s CharacterController does not inherit transform motion from parent objects correctly.

To solve this:

Platforms compute their frame-to-frame delta movement

That delta is manually applied to the player via CharacterController.Move()

This avoids:

Parenting issues

Physics inconsistencies

Movement slowdown bugs

This demonstrates handling of real production edge cases.

🔹 4. Modular Platform Movement

Platforms move between defined points:

PointA

PointB

Exposed public methods:

MoveToA()

MoveToB()

These are triggered via UnityEvents from buttons.

🔹 5. Respawn System (Trigger-Based)

Instead of checking position every frame, the project uses:

Kill Zones (Trigger Colliders)

Dedicated PlayerRespawn component

This approach is:

Level-driven

Performant

Production-friendly

Scalable for checkpoints

🗺️ Puzzle Design Philosophy

Each puzzle follows a simple rule:

One core mechanic per room.

Design principles used:

Clear visual readability

Visible cause → visible effect

Minimal instructions

Spatial reasoning over text explanation

🎮 Controls
Action	Key
Move	WASD
Look	Mouse
Jump	Space
Sprint	Shift
Interact	E
Unlock Cursor (WebGL)	Escape
🌐 WebGL Build

This project includes a WebGL build compatible with itch.io.

Special considerations implemented:

Cursor locking for browser environments

Input System compatibility

Correct WebGL compression configuration

🏗️ Technologies Used

Unity (URP compatible)

C#

Unity Input System

CharacterController

UnityEvents

WebGL build pipeline

📦 Project Structure (Simplified)
Scripts/
├── Core/
|    ├── Events/
|               ├── GameEvent.cs
|    ├── Interfaces/
|               ├── IInteractable.cs
|
├── Environment/
|   ├── ButtonInteractable.cs
|   ├── Door.cs
|   ├── DoorState.cs
|   ├── KillZone
|   ├── MovingPlatform.cs
|   ├── PlatformMover.cs
│
├── Gameplay/
|   ├── FinishLine.cs
|   ├── WebGLCursorFix.cs
|
├── Player/
│   ├── PlatformMotor.cs
│   ├── PlayerInteraction.cs
│   ├── PlayerRespawn.cs
│
├── UI/
│   ├── InteractionUI.cs
│   ├── MainMenu.cs
│
└── 

The structure reflects intentional separation of gameplay domains.

🚀 Why This Project Matters

This prototype demonstrates:

Understanding of Unity engine constraints

Problem-solving in real gameplay scenarios

Architectural thinking over feature stacking

Clean, readable C# code

Production-aware design decisions

It reflects how I approach game development:

Build core systems first

Solve technical constraints properly

Keep systems modular

Design with scalability in mind

👤 Author

Lautaro Sabena
Unity Developer

This project was built as part of an ongoing effort to create strong, technically focused portfolio pieces.

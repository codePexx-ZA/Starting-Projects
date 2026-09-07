# C# Learning Activities (ITEHA / exam prep)

Small C# drills and exam-style sketches written while studying enterprise C# (Eduvos ITEHA).

These are **learning exercises**, not production apps. They show practice with:

- Classes, lists, null checks
- Password hashing (`HMACSHA256`) + mock JWT
- ASP.NET Core Web API controller shapes
- `[Authorize(Roles = "...")]` (RBAC)
- Short “exam sketch” style answers

## Folder map

| Folder | What is inside |
|---|---|
| `practice/` | Language drills (threads, lock, interface injection) |
| `drills/` | Short refresher drills (constructor, SRP) |
| `structure/` | Blank-sheet design practice |
| `exam/` | Exam minis, combos, and API/RBAC sketches |
| `recap/` | Spaced-repetition recap sessions |
| `lecture-notes/` | Lecture/example code kept for reference |

## How to browse

Open any `.cs` file in the folder that matches what you want to see. Prefer:

1. `exam/` for auth, hashing, mock JWT, and API/RBAC sketch answers  
2. `practice/` and `drills/` for language fundamentals  
3. `structure/` for inventing models from a blank sheet  

API sketches that use `Microsoft.AspNetCore.Mvc` are **exam sketches** (readable code for marks). They are not all wired into a runnable host.

## Note for recruiters / reviewers

Expect beginner-to-intermediate exam prep code. Naming and structure were cleaned for readability. Comments were removed so the code stands alone.

# NonAllocFlagGenerator
An efficient solution for flag checking in C# and Unity

## Benefits of NonAllocFlagGenerator
- Solves the boxing issue of the default `HasFlag` method
- Improves performance by minimizing garbage generation
- Easy to use

## Installation

### NuGet
1. Open the NuGet Package Manager in your IDE (e.g., Visual Studio)
2. Search for `NonAllocFlagGenerator` in the NuGet Gallery
3. Install the package  
---
1. Open the terminal in your IDE
2. Run the following command to install the package:  
   `dotnet add package NonAllocFlagGenerator --version 1.3.1`

### Unity Package Manager
1. Open the Package Manager in Unity (Window > Package Manager)
2. Add the NonAllocFlagGenerator package using the following Git URL:  
  `https://github.com/KBluePurple/NonAllocFlagGenerator.git?path=/Plugins#master`

## How It Works
NonAllocFlagGenerator uses C# Source Generators to automatically generate efficient extension methods for enums marked with the [Flags] attribute. Here's a detailed breakdown of the process:

1. **Source Generation**: At compile time, the generator scans your codebase for any enum types decorated with the [Flags] attribute.

2. **Extension Method Creation**: For each flagged enum it finds, the generator automatically creates specialized extension methods that perform flag checking operations without allocating memory on the heap.

3. **Compile-Time Processing**: All the code generation happens during compilation, which means:
   - There's no runtime overhead for generating the methods
   - The generated code is type-safe and checked by the compiler
   - You get IDE support like IntelliSense for the generated methods

4. **Zero Allocation Design**: The generated extension methods use bitwise operations instead of boxing/unboxing, ensuring that no garbage is generated during flag checks.

## Usage Example
```cs
[Flags]
public enum PlayerState
{
   None = 0,
   Idle = 1 << 0,
   Walking = 1 << 1,
   Running = 1 << 2,
   Jumping = 1 << 3,
   All = ~0
}
```
```cs
var currentState = PlayerState.Idle | PlayerState.Walking;
// Efficient flag checking using NonAllocFlagGenerator
if (currentState.HasFlagNonAlloc(PlayerState.Idle))
{
    // Handle Idle state
}
if (currentState.HasFlagNonAlloc(PlayerState.Walking))
{
    // Handle Walking state
}
```

With NonAllocFlagGenerator, you can easily check flags while writing readable code without compromising performance.
Apply NonAllocFlagGenerator to your project today and experience efficient flag checking!

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
NonAllocFlagGenerator uses C# Source Generators to automatically generate efficient extension methods for enums marked with the `[Flags]` attribute. For the generator to process an assembly, the assembly must be explicitly marked. Here's a detailed breakdown of the process:

1.  **Assembly Opt-In**: To enable the generator for your project, add the `[assembly: NonAllocFlags.Generator.NonAllocFlagGenerator]` attribute to one of your C# files (e.g., `AssemblyInfo.cs` or any other source file). This signals the generator to scan this specific assembly.

2.  **Enum Scanning**: Once an assembly is opted-in, the generator scans it at compile time for any enum types decorated with the `[Flags]` attribute.

3.  **Extension Method Creation**: For each `[Flags]` enum found in an opted-in assembly, the generator automatically creates specialized extension methods (like `HasFlagNonAlloc` and `HasAnyFlag`) that perform flag checking operations without allocating memory on the heap.

4.  **Compile-Time Processing**: All code generation happens during compilation. This means:
    * There's no runtime overhead for generating the methods.
    * The generated code is type-safe and checked by the compiler.
    * You get IDE support like IntelliSense for the generated methods.

5.  **Zero Allocation Design**: The generated extension methods use bitwise operations, avoiding the boxing that occurs with the standard `Enum.HasFlag` method, ensuring that no garbage is generated during flag checks.

## Usage Example

To use NonAllocFlagGenerator:

1.  **Enable the generator for your assembly:**
    Add the following line to any C# file in your project, for example, in `AssemblyInfo.cs` or at the top of a relevant code file:
    ```csharp
    [assembly: NonAllocFlags.Generator.NonAllocFlagGenerator]
    ```

2.  **Define your enum with the `[Flags]` attribute:**
    ```csharp
    using System; // Required for [Flags]

    [Flags]
    public enum PlayerState
    {
       None = 0,
       Idle = 1 << 0,
       Walking = 1 << 1,
       Running = 1 << 2,
       Jumping = 1 << 3,
       All = ~0 // Example of all flags set
    }
    ```

3.  **Use the generated extension methods:**
    ```csharp
    var currentState = PlayerState.Idle | PlayerState.Walking;

    // Efficient flag checking using NonAllocFlagGenerator
    if (currentState.HasFlagNonAlloc(PlayerState.Idle))
    {
        // Handle Idle state
        Console.WriteLine("Player is Idle.");
    }

    if (currentState.HasAnyFlag(PlayerState.Running | PlayerState.Jumping))
    {
        // Handle if any of the specified flags (Running or Jumping) are set
        Console.WriteLine("Player is either Running or Jumping (or both).");
    }

    if (currentState.HasFlagNonAlloc(PlayerState.Walking))
    {
        // Handle Walking state
        Console.WriteLine("Player is Walking.");
    }
    ```

With NonAllocFlagGenerator, you can easily check flags while writing readable code without compromising performance.
Apply NonAllocFlagGenerator to your project today and experience efficient flag checking!

## Star History

<a href="https://www.star-history.com/#KBluePurple/NonAllocFlagGenerator&Date">
 <picture>
   <source media="(prefers-color-scheme: dark)" srcset="https://api.star-history.com/svg?repos=KBluePurple/NonAllocFlagGenerator&type=Date&theme=dark" />
   <source media="(prefers-color-scheme: light)" srcset="https://api.star-history.com/svg?repos=KBluePurple/NonAllocFlagGenerator&type=Date" />
   <img alt="Star History Chart" src="https://api.star-history.com/svg?repos=KBluePurple/NonAllocFlagGenerator&type=Date" />
 </picture>
</a>
# NonAllocFlagGenerator

An efficient solution for flag checking in C# and Unity

## Benefits of NonAllocFlagGenerator

- Solves the boxing issue of the default `HasFlag` method
- Improves performance by minimizing garbage generation
- Easy to use

## Installation

1. Open the Package Manager in Unity (Window > Package Manager)
2. Add the NonAllocFlagGenerator package using the following Git URL:  
  `https://github.com/KBluePurple/NonAllocFlagGenerator.git?path=/Plugins#master`

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

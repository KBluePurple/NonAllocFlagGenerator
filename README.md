# NonAllocFlagGenerator
Simple HasFlagNonAlloc Method generator for C# & Unity

## Why use NonAllocFlag?
The default implementation of HasFlag in C# accepts arguments of type object, causing boxing of value types like enums, which leads to garbage generation.

## Quick start
Window > Package Manager > Add > Add package from git URL... > Put below url and press Enter  
`https://github.com/KBluePurple/NonAllocFlagGenerator.git?path=/Plugins#master`

## Usage
```cs
[Flags]
public enum MoveType
{
    None = 0,
    Custom = 1 << 0,
    All = ~0
}
```
```cs
var moveType = MoveType.Custom;
moveType.HasFlagNonAlloc(MoveType.Custom); // true
```

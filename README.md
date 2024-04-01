# NonAllocFlagGenerator
Simple NonAllocHasFlag Method generator for C# & Unity

## Quick start
Window > Package Manager > Add > Add package from git URL...
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
MoveType.HasFlagNonAlloc(MoveType.Custom);
```

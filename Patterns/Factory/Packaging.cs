namespace Patterns.Factory;

public enum Packaging
{
    None = 0,
    BubbleWrap = 1,
    Box = 2,
    BubbleWrapAndBox = BubbleWrap | Box,
}

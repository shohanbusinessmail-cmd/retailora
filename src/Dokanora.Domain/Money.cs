namespace Dokanora.Domain;

/// <summary>Explicit BDT minor-unit conversion. Never use floating-point for money.</summary>
public static class Money
{
    public static decimal Round(decimal amount) => decimal.Round(amount, 2, MidpointRounding.AwayFromZero);

    public static long ToMinorUnits(decimal amount) => checked((long)(Round(amount) * 100m));

    public static decimal FromMinorUnits(long amount) => amount / 100m;
}

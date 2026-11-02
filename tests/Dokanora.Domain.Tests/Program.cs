using Dokanora.Domain;

// Dependency-free smoke tests until the test framework and package review are established.
var failures = 0;
void Check(string name, Action action)
{
    try { action(); Console.WriteLine($"PASS {name}"); }
    catch (Exception e) { failures++; Console.Error.WriteLine($"FAIL {name}: {e.Message}"); }
}
void Equal<T>(T expected, T actual) where T : IEquatable<T>
{
    if (!expected.Equals(actual)) throw new Exception($"Expected {expected}, got {actual}");
}
void Throws<T>(Action action) where T : Exception
{
    try { action(); } catch (T) { return; }
    throw new Exception($"Expected {typeof(T).Name}");
}
Check("money round trip", () => Equal(123.45m, Money.FromMinorUnits(Money.ToMinorUnits(123.45m))));
Check("positive midpoint", () => Equal(101L, Money.ToMinorUnits(1.005m)));
Check("negative midpoint", () => Equal(-101L, Money.ToMinorUnits(-1.005m)));
Check("large amount overflow", () => Throws<OverflowException>(() => Money.ToMinorUnits(decimal.MaxValue)));
Check("balanced journal", () => Journal.Validate([new("cash", EntrySide.Debit, 100), new("sales", EntrySide.Credit, 100)]));
Check("unbalanced journal", () => Throws<ArgumentException>(() => Journal.Validate([new("cash", EntrySide.Debit, 100), new("sales", EntrySide.Credit, 99)])));
Check("empty journal", () => Throws<ArgumentException>(() => Journal.Validate([])));
Check("invalid side", () => Throws<ArgumentException>(() => Journal.Validate([new("cash", (EntrySide)5, 100), new("sales", EntrySide.Credit, 100)])));
Check("zero line", () => Throws<ArgumentException>(() => Journal.Validate([new("cash", EntrySide.Debit, 0), new("sales", EntrySide.Credit, 100)])));
Check("sum overflow", () => Throws<OverflowException>(() => Journal.Validate([new("a", EntrySide.Debit, long.MaxValue), new("b", EntrySide.Debit, 1), new("c", EntrySide.Credit, long.MaxValue)])));
return failures == 0 ? 0 : 1;

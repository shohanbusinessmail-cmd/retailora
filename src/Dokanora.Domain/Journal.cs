namespace Dokanora.Domain;

public enum EntrySide { Debit, Credit }

/// <summary>A positive amount in paisa on one side of a journal.</summary>
public sealed record JournalLine(string AccountCode, EntrySide Side, long AmountMinor);

/// <summary>Validates a proposed entry; persistence and posting authorization are not implemented.</summary>
public static class Journal
{
    public static void Validate(IEnumerable<JournalLine> lines)
    {
        ArgumentNullException.ThrowIfNull(lines);
        long debits = 0, credits = 0;
        int count = 0;
        foreach (var line in lines)
        {
            if (line is null || string.IsNullOrWhiteSpace(line.AccountCode) || line.AmountMinor <= 0)
                throw new ArgumentException("A journal line requires an account and a positive amount.", nameof(lines));
            checked
            {
                switch (line.Side)
                {
                    case EntrySide.Debit: debits += line.AmountMinor; break;
                    case EntrySide.Credit: credits += line.AmountMinor; break;
                    default: throw new ArgumentException("Invalid journal side.", nameof(lines));
                }
            }
            count++;
        }
        if (count < 2 || debits == 0 || debits != credits)
            throw new ArgumentException("A journal must have matching nonzero debits and credits.", nameof(lines));
    }
}

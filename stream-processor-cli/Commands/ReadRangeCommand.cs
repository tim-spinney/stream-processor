using System.Text.RegularExpressions;

namespace StreamProcessorCli.Commands;

public class ReadRangeCommand : ICommand
{
    private string _partitionKey;
    private uint _minIndexInclusive;
    private uint _numMessages;

    public ReadRangeCommand(string partitionKey, uint minIndexInclusive, uint numMessages)
    {
        _partitionKey = partitionKey;
        this._minIndexInclusive = minIndexInclusive;
        this._numMessages = numMessages;
    }

    public void Apply(PartitionStream partitionStream)
    {
        throw new NotImplementedException();
    }
}

public class ReadRangeCommandFactory : CommandFactory
{
    protected override Regex Pattern { get; } = new("^read_range (.*) (\\d) (\\d)$", RegexOptions.Compiled);
    protected override ICommand ParseCommand(Match match)
    {
        return new ReadRangeCommand(
            match.Groups[1].Value, 
            uint.Parse(match.Groups[2].Value), 
            uint.Parse(match.Groups[3].Value)
        );
    }
}
using System.Text.RegularExpressions;

namespace StreamProcessorCli.Commands;

public class AddMessageCommand : ICommand
{
    private string _partitionKey;
    private string _message;

    public AddMessageCommand(string partitionKey, string message)
    {
        _partitionKey = partitionKey;
        _message = message;
    }

    public void Apply(PartitionStream partitionStream)
    {
        throw new NotImplementedException();
    }
}

public class AddMessageCommandFactory : CommandFactory
{
    protected override Regex Pattern { get; } = new("^add_message (.*) (.*)$", RegexOptions.Compiled);
    
    protected override ICommand ParseCommand(Match match)
    {
        return new AddMessageCommand(match.Groups[1].Value, match.Groups[2].Value);
    }
}
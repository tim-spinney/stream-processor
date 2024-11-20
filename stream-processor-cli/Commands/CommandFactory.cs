using System.Text.RegularExpressions;

namespace StreamProcessorCli.Commands;

public abstract class CommandFactory
{
    protected abstract Regex Pattern { get; }
    
    public ICommand? TryParseCommand(string command)
    {
        Match match = Pattern.Match(command);
        if (match.Success)
        {
            return ParseCommand(match);
        }
        return null;
    }
    
    protected abstract ICommand ParseCommand(Match match);
}
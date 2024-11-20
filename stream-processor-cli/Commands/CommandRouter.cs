using System.Text.RegularExpressions;

namespace StreamProcessorCli.Commands;

public class CommandRouter
{
    private List<CommandFactory> commands = new();

    public CommandRouter WithCommand(CommandFactory command)
    {
        commands.Add(command);
        return this;
    }

    public ICommand? TryParseCommand(string commandText)
    {
        foreach (CommandFactory factory in commands)
        {
            ICommand? maybeCommand = factory.TryParseCommand(commandText);
            if (maybeCommand != null)
            {
                return maybeCommand;
            }
        }

        return null;
    }
}
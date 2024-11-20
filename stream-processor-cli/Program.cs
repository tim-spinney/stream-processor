using System.Text.Json;
using StreamProcessorCli.Commands;

namespace StreamProcessorCli;

class Program
{
    static void Main(string[] args)
    {
        PartitionStreamParameters parameters = PartitionStreamParameters.FromFile(args[0]);

        using PartitionStream partitionStream = new PartitionStreamFactory().FromParameters(parameters);
        
        CommandRouter commandRouter = new CommandRouter()
            .WithCommand(new AddMessageCommandFactory())
            .WithCommand(new ReadRangeCommandFactory());

        while (true)
        {
            ICommand? command = commandRouter.TryParseCommand(Console.ReadLine()!);
            if (command == null)
            {
                Console.WriteLine("Invalid command");
            }
            else
            {
                try
                {
                    command.Apply(partitionStream);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
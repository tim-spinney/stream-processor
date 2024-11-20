namespace StreamProcessorCli.Commands;

public interface ICommand
{
    void Apply(PartitionStream partitionStream);
}
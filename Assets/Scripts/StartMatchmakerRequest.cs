using System.Collections.Generic;

internal class StartMatchmakerRequest
{
    public string QueueName { get; set; }
    public Dictionary<string, string> PlayerAttributes { get; set; }
    public string TicketId { get; set; }
}
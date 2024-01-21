namespace TrackerX.Services.Accounts.Invitations.Models;

public class InvitationModel
{
    public int InvitationId { get; set; }

    public string Code { get; set; }        

    public bool IsInvitationAborted { get; set; }

    public DateTime? ValideDueDate { get; set; }

    public DateTime? AcceptedDate { get; set; }

    public string UserName { get; set; }
}

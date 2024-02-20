using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;
using TrackerX.Service.Proposals.Models;

namespace TrackerX.Service.Proposals;

public sealed class ProposalService : IProposalService
{
    private readonly IProposalRepository _proposalRepository;
    private readonly ISongRepository _songRepository;

    public ProposalService(IProposalRepository proposalRepository, ISongRepository songRepository)
    {
        _proposalRepository = proposalRepository;
        _songRepository = songRepository;
    }

    public async Task<IEnumerable<ProposalView>> GetUserProposals(ProposalSearchArgs searchArgs, int userId)
    {
        IEnumerable<Proposal> proposals = await _proposalRepository.SearchAsync(userId, searchArgs.Status);
        IEnumerable<Song> songs = await _songRepository.SearchAsync(searchArgs.SongPattern, searchPublic: false);

        return proposals.Join(
                songs,
                p => p.AssetId,
                s => s.SongId,
                (pr, s) => new ProposalView()
                {
                    ProposalId = pr.ProposalId
                    AlbumName = s.Album.AlbumName,
                    BandName = s.Band.BandName,
                    SongName = s.SongName,
                    Status = pr.ProposalStatus.ProposalStatusName,
                    Message = pr.ResponseMessage,
                    OpenedDate = pr.CreatedDateTimeUtc!.Value,
                    UpdatedDate = pr.ModifiedDateTimeUtc!.Value,
                });
    }

    public async Task OpenProposalAsync(OpenProposalModel model)
    {
        int proposalStatusOpened = 1;

        var proposal = new Proposal()
        {
            AssetId = model.AssetId,
            AssetType = model.AssetType,
            ProposalAssigneeId = model.UserId,
            ProposalStatusId = proposalStatusOpened
        };

        _proposalRepository.Create(proposal);

        await _proposalRepository.SaveChangesAsync();
    }
}

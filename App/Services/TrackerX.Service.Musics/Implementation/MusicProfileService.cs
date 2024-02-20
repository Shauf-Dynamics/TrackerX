﻿using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;
using TrackerX.Service.Musics.Models;

namespace TrackerX.Service.Musics.Implementation;

internal class MusicProfileService : IMusicProfileService
{
    private readonly IMusicProfileRepository _musicProfileRepository;
    private readonly ISongRepository _songRepository;
    private readonly ICustomMusicRepository _customMusicRepository;

    public MusicProfileService(
        IMusicProfileRepository musicProfileRepository,
        ISongRepository songRepository,
        ICustomMusicRepository customMusicRepository)
    {
        _musicProfileRepository = musicProfileRepository;
        _songRepository = songRepository;
        _customMusicRepository = customMusicRepository;
    }

    public async Task<IEnumerable<MusicProfileView>> GetUserOwnMusic(MusicProfileSearchModel searchModel, int userId)
    {
        IEnumerable<MusicProfileView> songs = Enumerable.Empty<MusicProfileView>();
        IEnumerable<MusicProfileView> custom = Enumerable.Empty<MusicProfileView>();

        IEnumerable<MusicProfile> musicProfiles = await _musicProfileRepository.GetWhereAsync(x => x.InitiatorUserId == userId);
        if (searchModel.IncludePublished.HasValue)
        {
            musicProfiles = musicProfiles.Where(x => x.IsPublished == searchModel.IncludePublished.Value);
        }

        if (searchModel.Type == MusicProfileTypeEnum.Both || searchModel.Type == MusicProfileTypeEnum.Song)
        {
            songs = await GetSongProfiles(musicProfiles, searchModel.DescriptionPattern);
        }

        if (searchModel.Type == MusicProfileTypeEnum.Both || searchModel.Type == MusicProfileTypeEnum.Custom)
        {
            custom = await GetCustomMusicProfiles(musicProfiles, searchModel.DescriptionPattern);
        }

        return Enumerable.Concat(songs, custom)
            .OrderBy(x => x.AssetAddedDate);
    }

    private async Task<IEnumerable<MusicProfileView>> GetSongProfiles(IEnumerable<MusicProfile> musicProfiles, string descriptionPattern)
    {
        return (await _songRepository
                .SearchBySongNameAsync(descriptionPattern ?? ""))
                .Join(musicProfiles,
                s => s.SongId,
                p => p.AssetId,
                (s, p) => new MusicProfileView()
                {
                    MusicProfileId = p.MusicProfileId,
                    Description = $"{s.Band.BandName} -  {s.SongName}",
                    Album = s.Album.AlbumName,
                    Author = null,
                    AssetAddedDate = s.CreatedDateTimeUtc!.Value,
                    IsPublished = p.IsPublished,
                    Type = MusicProfileTypeEnum.Song.ToString()
                });
    }

    private async Task<IEnumerable<MusicProfileView>> GetCustomMusicProfiles(IEnumerable<MusicProfile> musicProfiles, string descriptionPattern)
    {
        return (await _customMusicRepository
                .GetWhereAsync(x => x.CustomMusicDescription.StartsWith(descriptionPattern ?? "")))
                .Join(musicProfiles,
                    c => c.CustomMusicId,
                    p => p.AssetId,
                    (c, p) => new MusicProfileView()
                    {
                        MusicProfileId = p.MusicProfileId,
                        Description = c.CustomMusicDescription,
                        Album = null,
                        Author = c.AuthorName,
                        AssetAddedDate = c.CreatedDateTimeUtc!.Value,
                        IsPublished = p.IsPublished,
                        Type = MusicProfileTypeEnum.Custom.ToString()
                    });
    }
}

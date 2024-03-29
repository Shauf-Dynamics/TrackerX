﻿using TrackerX.Service.Lessons.Infrastructure;
using TrackerX.Service.Musics.Infrastructure;
using TrackerX.Service.Bands.Infrastructure;
using TrackerX.Service.Albums.Infrastructure;
using TrackerX.Service.Accounts.Infrastructure;
using TrackerX.Service.Proposals.Infrastructure;

namespace TrackerX.Web.Moduls;

public static class ServicesCollectionExtension
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddMusicServices();
        services.AddLessonServices();
        services.AddBandServices();
        services.AddAlbumServices();
        services.AddAccountServices();
        services.AddProposalServices();
    }
}

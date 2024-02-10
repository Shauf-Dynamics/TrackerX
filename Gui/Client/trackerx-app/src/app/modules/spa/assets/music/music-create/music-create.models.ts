export class MusicBase {
    public genreId: number;
    public tempo: number = 120;
    public IsInstrumental: boolean = false;
}

export class SongCreateModel extends MusicBase {
    public songName: string;
    public bandId: number;
    public albumId: number;
    public isAgreedToPublish: boolean = false;
}

export class CustomMusicCreateModel extends MusicBase {
    public description: string;
    public author: string;
}

export class GenreModel {
    public genreId: number;
    public parentGenreId: number | null;
    public genreName: string;
}

export class BandSuggestionResult {
    public bandId: number;
    public bandName: string;
}

export class AlbumSuggestionResult {
    public albumId: number;
    public albumName: string;
}

export enum MusicType {
    Song,
    Custom
}
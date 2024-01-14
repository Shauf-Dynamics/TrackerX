export class SongModel {
    public name: string;
    public bandId: number;
    public albumId?: number;
    public genreId: number | null;
    public isInstrumental: boolean;
    public isAgreedToPublish: boolean;    
}

export class GenreModel {
    public genreId: number;
    public parentGenreId: number | null;
    public genreName: string;
}

export enum MusicType {
    Song,
    Custom
}
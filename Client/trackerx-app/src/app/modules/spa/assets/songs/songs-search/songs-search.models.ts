export class SongModel {
    public id: number;
    public name: string;
    public album: string;
    public band: string;
    public year: Date;
}

export class SearchModel {
    public searchText: string;
    public searchBy: string;
}
export class MusicModel {
    public musicId: number;
    public musicName: string;
    public album: string;
    public band: string;
    public year: number;
}

export class MusicDetailsModel {
    public musicId: number;
    public name: string;
    public band: string;
    public album: string;
    public tempo: number;
    public isInstrumental: boolean;
    public genre: string;
    public subgenre: string;
}

export class SearchModel {
    public searchText: string;
    public searchBy: string;
}